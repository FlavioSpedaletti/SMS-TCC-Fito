using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using SmsManager;

namespace WindowsApplication1
{
    public class SMS
    {
        private string _Type;

        public string Type
        {
            get
            {
                return _Type; 
            }
            set
            {
                _Type = value;
            }
        }

        public bool Send(SerialPort Port, string MobilePhone, string Message)
        {
            bool enviou;
            PortUtilities SP = new PortUtilities();
            enviou=SP.SendSMS(Port, MobilePhone, Message);
            return enviou;
        }

        public string Receive(SerialPort Port, string TypeSMS)
        {
            string SMSs;
            PortUtilities SP = new PortUtilities();
            SMSs = SP.ListSMS(Port, TypeSMS);       
            return SMSs;
        }

        public bool Consult()
        {
            throw new System.NotImplementedException();
        }
    }
}
