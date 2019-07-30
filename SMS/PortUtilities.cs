using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;

namespace SmsManager
{
    public class PortUtilities
    {
        public delegate void OnMessageLog(object sender, PortUtilitiesEventArgs e);
        public event OnMessageLog OnMessageLogged;

        /// <summary>
        /// Finds all ports
        /// </summary>
        /// <returns>Port names (CSV)</returns>
        public string FindPorts()
        {
            string pNames="";
            foreach (string pName in SerialPort.GetPortNames())
            {
                pNames += pName + ",";
            }
            if (pNames.Length > 2) { return pNames.Substring(0, pNames.Length - 2); } else { return ""; }
        }

        /// <summary>
        /// Opens the supplied port number is the port is not already open
        /// </summary>
        /// <param name="portName">The Name of the port, "COM?"</param>
        /// <param name="pinNumber">The Pin Number for the GSM Modem SIM Card</param>
        /// <returns>Opened Serial Port Object</returns>
        public SerialPort OpenPort(string portName, string pinNumber)
        {
            SerialPort serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            try
            {
                serialPort.Handshake = Handshake.RequestToSend;
                serialPort.ReadTimeout = 5000;
                if (!serialPort.IsOpen) { serialPort.Open(); }
                IsModemReady(serialPort);
                PINNumber(serialPort, pinNumber);
                ConfigSMSTextMode(serialPort);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
            }
            return serialPort;
        }
        /// <summary>
        /// Opens the supplied port number is the port is not already open
        /// </summary>
        /// <param name="portName">The Name of the port, "COM?"</param>
        /// <returns>Opened Serial Port Object</returns>
        public SerialPort OpenPortSerial(string portName)
        {
            SerialPort serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            try
            {
                serialPort.Handshake = Handshake.RequestToSend;
                serialPort.ReadTimeout = 5000;
                if (!serialPort.IsOpen) { serialPort.Open(); }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
            }
            return serialPort;
        }
        /// <summary>
        /// Opens the supplied port number is the port is not already open
        /// </summary>
        /// <param name="portName">The Name of the port, "COM?"</param>
        /// <param name="pinNumber">The Pin Number for the GSM Modem SIM Card</param>
        /// <param name="handshake">Handshake setting</param>
        /// <param name="baudRate">BaudRate</param>
        /// <param name="parity">Parity</param>
        /// <param name="dataBits">DataBits</param>
        /// <param name="stopBits">StopBits</param>
        /// <returns></returns>
        public  SerialPort OpenPort(string portName, string pinNumber, Handshake handshake, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            SerialPort serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                serialPort.Handshake = handshake;
                serialPort.ReadTimeout = 5000;
                if (!serialPort.IsOpen) { serialPort.Open(); }
                IsModemReady(serialPort);
                PINNumber(serialPort, pinNumber);
                ConfigSMSTextMode(serialPort);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
            }
            return serialPort;
        }
        /// <summary>
        /// Send the messge to the supplied mobile number via the supplied serialport
        /// </summary>
        /// <param name="serialPort">Port to use to send message</param>
        /// <param name="mobileNumber">The GSM Modem Phone Number for send the message to,</param>
        /// <param name="message">The message to be sent</param>
        /// <returns>True if successful</returns>
        public  bool SendSMS(SerialPort serialPort, string mobileNumber, string message)
        {
            LogMessage(message, EventLogEntryType.Error);
            if (!SendCMGSCommand(serialPort, mobileNumber)) { return false; }
            if (!SendSerialMessage(serialPort, message)) { return false; }
            if (!sendCTRLZ(serialPort)) { return false; }
            return true;
        }
        /// <summary>
        /// Sends an AT Command to the supplied port
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <returns>True if successful</returns>
        private  bool IsModemReady(SerialPort serialPort)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("AT Command timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("OK"));
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Sets the Pin for the device is it is not already set.
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <param name="pinNumber">The Pin Number for the GSM Modem SIM Card</param>
        /// <returns>True if successful</returns>
        private  bool PINNumber(SerialPort serialPort, string pinNumber)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            //Check if need to enter PIN
            try
            {
                serialPort.Write("AT+CPIN?" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("AT+CPIN? Command timed out without receiving 'READY' or 'SIM PIN'.");
                    }
                }
                while ((!buffer.Contains("READY")) && (!buffer.Contains("SIM PIN")));
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
                return false;
            }
            if (buffer.Contains("SIM PIN"))
            {
                try
                {
                    serialPort.Write("AT+CPIN=\"" + pinNumber + "\"" + (char)13);
                    buffer = "";
                    do
                    {
                        buffer += serialPort.ReadExisting();
                        if (DateTime.Now > timeout)
                        {
                            throw new Exception("AT+CPIN Command timed out without receiving 'OK'.");
                        }
                    }
                    while (!buffer.Contains("OK"));
                }
                catch (Exception ex)
                {
                    LogMessage(ex.Message, EventLogEntryType.Error);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Sends the CMGFCommand to set the input type
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <returns>True if successful</returns>
        private  bool ConfigSMSTextMode(SerialPort serialPort)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CMGF=1" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("AT+CMGF=1 Command timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("OK"));
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Get battery status
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <returns>Battery status</returns>
        public string GetBatteryStatus(SerialPort serialPort)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CBC" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("CBC timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("\r\nOK\r\n"));
            }
            catch (Exception ex)
            {
                IsModemReady(serialPort);
                LogMessage("Failed to retrieve message from modem: " + ex.Message, EventLogEntryType.Error);
                return string.Empty;
            }
            return buffer;
        }
        /// <summary>
        /// Get battery status
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <returns>Battery status</returns>
        public string GetCharge(SerialPort serialPort)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CSQ" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("CSQ timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("\r\nOK\r\n"));
            }
            catch (Exception ex)
            {
                IsModemReady(serialPort);
                LogMessage("Failed to retrieve message from modem: " + ex.Message, EventLogEntryType.Error);
                return string.Empty;
            }
            return buffer;
        }
        /// <summary>
        /// Initiates the GSM Modem to send a message to the supplied mobile number
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <param name="mobileNumber">The mobile number to send the message to</param>
        /// <returns>True if successful</returns>
        private  bool SendCMGSCommand(SerialPort serialPort, string mobileNumber)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CMGS=\"" + mobileNumber + "\"" + (char)13);
                buffer = "";

                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("CMGS Command timed out without receiving '>'.");
                    }
                }
                while (!buffer.Contains("\r\n>"));
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Sends the message to the waiting cursor
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <param name="message">The message to be sent</param>
        /// <returns>True if successful</returns>
        public  bool SendSerialMessage(SerialPort serialPort, string message)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write(message + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("Message timed out without receiving '>'.");
                    }
                }
                while (!buffer.Contains(">"));
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, EventLogEntryType.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Finalises message send routing by sending the messge to the mobile number
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <returns>True if successful</returns>
        private  bool sendCTRLZ(SerialPort serialPort)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("" + (char)26);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("Message timed out without receiving '+CMGS:'.");
                    }
                }
                while (!buffer.Contains("+CMGS:"));
            }
            catch (Exception ex)
            {
                LogMessage("Failed to Send CTRL+Z Command: " + ex.Message, EventLogEntryType.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Sends CGML command to list messages on the GSM Modem
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <param name="messageType">The messges to be read as a string, eg. "ALL", "REC UNREAD"</param>
        /// <returns>The response form the GSM Modem</returns>
        public  string ListSMS(SerialPort serialPort, string messageType)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CMGL=\"" + messageType + "\"" + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("CMGL timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("\r\nOK\r\n"));
            }
            catch (Exception ex)
            {
                IsModemReady(serialPort);
                LogMessage("Failed to retrieve message from modem: " + ex.Message, EventLogEntryType.Error);
                return string.Empty;
            }
            return buffer;
        }
        /// <summary>
        /// Sends the CMGDCommand to delete SMS
        /// </summary>
        /// <param name="serialPort">Port to use to send command</param>
        /// <param name="messageID">The ID's messges to be deletes"</param>
        /// <returns>The response form the GSM Modem</returns>
        public string DeleteSMS(SerialPort serialPort, string messageID)
        {
            DateTime timeout = DateTime.Now.AddMinutes(1);
            string buffer = "";
            try
            {
                serialPort.Write("AT+CMGD=" + messageID + (char)13);
                buffer = "";
                do
                {
                    buffer += serialPort.ReadExisting();
                    if (DateTime.Now > timeout)
                    {
                        throw new Exception("CMGD timed out without receiving 'OK'.");
                    }
                }
                while (!buffer.Contains("\r\nOK\r\n"));
            }
            catch (Exception ex)
            {
                IsModemReady(serialPort);
                LogMessage("Failed to retrieve message from modem: " + ex.Message, EventLogEntryType.Error);
                return string.Empty;
            }
            return buffer;
        }
        /// <summary>
        /// Rec Logs
        /// </summary>
        private  void LogMessage(string message, EventLogEntryType eventLogEntryType)
        {
            PortUtilitiesEventArgs e = new PortUtilitiesEventArgs();
            e.Message = message;
            e.EventLogEntryType = eventLogEntryType;
            if (OnMessageLogged != null)
            {
                OnMessageLogged(new object(), e);
            }
        }
    }
    public class PortUtilitiesEventArgs : EventArgs
    {
        public string Message;
        public EventLogEntryType EventLogEntryType;
    }
}
