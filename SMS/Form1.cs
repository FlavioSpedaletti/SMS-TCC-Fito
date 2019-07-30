using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using SmsManager;
using System.Threading;
using System.IO;
using System.Xml;

//Namespaces necessários para a toolbox
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using IP.Components;

namespace WindowsApplication1
{
    public partial class frmMain : Form
    {
        #region object vars
        PortUtilities PortUt = new PortUtilities();
        SMS SMS = new SMS();
        SerialPort SP = new SerialPort();
        SerialPort SPSerial = new SerialPort();        
        #endregion
        #region normal vars
        string SMSs;
        string[] aSMSs;
        bool bLower;
        string sSMSId;          
        string sPhoneNumber;
        string[] sSMSParts;
        int iLen;
        int iTimeToRefresh = 10;
        bool b_ModemPortOpen=true;
        bool b_MicPortOpen=true;
        Thread tHeapTrd;
        Thread tExecTrd;
        Point mouse_offset;
        bool bExecuting;
        #endregion
        
        delegate void LstDelegateLst(string msg);
        delegate void LstDelegateLbl(Label lbl);

        public struct TipoMensagem
        {
            public const string REC_READ = "Lidos" ;
            public const string REC_UNREAD = "Não lidos";
            public const string STO_SENT = "Enviados";
            public const string STO_UNSEND = "Rascunho";
            public const string ALL = "Todos";
        }

        public frmMain()
        {
            InitializeComponent();

            tHeapTrd = new Thread(Heap_ON_OFF);
            tHeapTrd.IsBackground = true;
            tExecTrd = new Thread(new ThreadStart(Execute));
            tExecTrd.IsBackground = true;

            //Esse método, por padrão, contém o valor "true" para evitar
            //a utilização de um mesmo controle por dois ou mais threads
            //ao mesmo tempo, o que pode levá-lo a um estado inválido.
            //Form1.CheckForIllegalCrossThreadCalls = false;

            //panel
            this.panel1.Left = 50;
            this.panel1.Top = panel3.Height;
            this.panel1.Height = this.Height - panel3.Height;
            this.panel1.Width = this.Width - 50;
            this.panel1.SendToBack();
            //toolbox
            this.toolbox1.Left = 51;
            this.toolbox1.Top = panel1.Top + 1;
            this.toolbox1.Height = this.panel1.Height - 3;
            this.toolbox1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X-18 , -e.Y-15);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mousePos;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Ajustar função para achar porta do modem automaticamente
            //string testeTxt = LerTxtIni(Application.StartupPath + "\\testeTxt.txt", "global");
            //string testeXML = LerXMLIni(Application.StartupPath + "\\testeXML.xml", "global");
            //MessageBox.Show (PortUt.FindPorts());
            SP = PortUt.OpenPort("COM9", "3636");
            if (SP.IsOpen) { b_ModemPortOpen = true; getLog("Porta de comunicação com o modem aberta com sucesso."); } else { b_ModemPortOpen = false; getLog("Falha na abertura da porta de comunicação com o modem."); }
            SPSerial = PortUt.OpenPortSerial("COM19");
            if (SPSerial.IsOpen) { b_MicPortOpen = true; getLog("Porta de comunicação com o microcontrolador aberta com sucesso."); } else { b_MicPortOpen = false; getLog("Falha na abertura da porta de comunicação com o microcontrolador."); }

            if (b_MicPortOpen || !b_ModemPortOpen)
            {
                if (DialogResult.No == MessageBox.Show("As portas de comunicação não foram abertas corretamente." + (char)13 + "Deseja abrir o programa em modo de segurança?", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Warning ))
                {
                    this.Close();
                }
                else
                {
                    getLog("Programa aberto em modo de segurança.");
                }
            }
            else
            {
                getLog("Programa aberto em modo normal.");
                lblTimeToRefresh.Visible = true;
                lblTimeToRefresh.Text = "A thread vai ser atualizada em: 10 seg.";
                tExecTrd.Start();
            }
            PopulateToolBox();
            PopuleCombo_SMSState();
            tHeapTrd.Start();
        }

        //Delegate para método com parâmetros
        private void getLog(string msg)
        {
            if (this.InvokeRequired)
            {
                Invoke(new LstDelegateLst(getLog), new object[] { msg });
                //OU
                //LstDelegateLst d = new LstDelegateLst(this.AddItem);
                //lstLog.Invoke(d, lstLog, msg);
            }
            else
            {
                lstLog.Items.Add(DateTime.Now + " - " + msg);
            }
        }

        //Delegate para método sem parâmetros
        private void getBatteryStatus()
        {
            if (this.InvokeRequired)
            {
                lblBtSt.Invoke(new MethodInvoker(getBatteryStatus));
                return;
            }

            string sRet;
            string sReceivingCharge;
            float fBtCharge;
            sRet = PortUt.GetBatteryStatus(SP)/**100/6*/;
            sRet = sRet.Replace("\r", "").Replace("\n", "");
            sRet = sRet.Substring(sRet.IndexOf(",") - 1, 4);
            sReceivingCharge = sRet.Substring(0, 1);
            fBtCharge = float.Parse(sRet.Substring(2, 2));
            lblBtSt.Text = fBtCharge.ToString();
            if (int.Parse(sReceivingCharge) == 1) { lblBtSt.Text += " - Carregando..."; }
        }

        //Delegate para método sem parâmetros
        private void getSignalStrength()
        {
            if (this.InvokeRequired)
            {
                lblBtSt.Invoke(new MethodInvoker(getSignalStrength));
                return;
            }

            string sSignal;
            double dSignal;
            int iSignal;
            sSignal = PortUt.GetCharge(SP);
            sSignal = sSignal.Replace("\r", "").Replace("\n", "");
            sSignal = sSignal.Substring(sSignal.IndexOf("CSQ:") + 5, sSignal.IndexOf("OK") - 1 - (sSignal.IndexOf("CSQ:") + 5));
            dSignal = float.Parse(sSignal);
            dSignal = Math.Round(dSignal, 0);
            pgbSignal.Value = Convert.ToInt32(dSignal);
        }

        private string  LerTxtIni(string psDirNomArquivo, string psVar)
        {
            StreamReader sValor = new StreamReader(psDirNomArquivo,Encoding.ASCII);
            string sLinha;
            List<string> _lListaLinhas = new List<string>();

            while ((sLinha = sValor.ReadLine())!= null) 
            {
                sLinha = sValor.ReadLine();
                _lListaLinhas.Add(sLinha);
                if (sLinha.Contains(psVar)) { sValor.Close(); return sLinha.Substring(sLinha.IndexOf(psVar) + psVar.Length + 1); }
            }
            sValor.Close();
            return "";
        }

        private string LerXMLIni(string psDirNomArquivo, string psVar)
        {
            XmlTextReader xReader = new XmlTextReader(psDirNomArquivo);

            while (xReader.Read())
            {
                if (xReader.MoveToContent() == XmlNodeType.Element && xReader.Name == psVar)
                {
                    return xReader.ReadString(); 
                }
            }
            return "";
        }

        private void AddItem(ListBox lst, string msg)
        {
            lst.Items.Add(DateTime.Now + " - " + msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SMSs;
            SMSs = SMS.Receive(SP, "REC UNREAD");                     
            if (SMSs == string.Empty) { MessageBox.Show("SMSs não recebidos"); }
            else
            {
                MessageBox.Show(SMSs);
                if (SMSs.Contains("APAGAR LED")) { button3.BackColor = Color.Red; }
                if (SMSs.Contains("ACENDER LED")) { button3.BackColor = Color.Green; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool enviou;
            enviou=SMS.Send(SP, txtNumero.Text, txtMensagem.Text);
            if (!enviou) { MessageBox.Show("Msg não enviada"); } else { MessageBox.Show("Msg enviada com sucesso"); }
            Thread.Sleep(1000);
        }

        public void Heap_ON_OFF()
        {
            do
            {
                Thread.Sleep(1000);
                Bitmap bitmap = new Bitmap(Resource1.pilha_off);
                if (iTimeToRefresh%2 == 0) { bitmap = (Resource1.pilha_on); } else { bitmap = (Resource1.pilha_off); }
                pictureBox1.Image = bitmap;
                if (iTimeToRefresh > 0) { iTimeToRefresh = iTimeToRefresh - 1; } else { iTimeToRefresh = 10; }
            } while (true);
        }

        public void Execute()
        {
            try
            {
                int iDataSMSPos, iSMSPos, iCont, iNumMsgs;
                do
                {
                    Thread.Sleep(1000);
                    /*Adjust precision*/
                    if (iTimeToRefresh == 0)
                    {
                        bExecuting = true;
                        getBatteryStatus();
                        getSignalStrength();
                        SMSs = SMS.Receive(SP, "REC UNREAD");
                        SMSs = SMSs.Replace("\r\n", "\n");
                        SMSs = SMSs.Replace("\r", "\n");

                        if (SMSs == string.Empty) { getLog("SMSs não recebidos."); }
                        else
                        {
                            aSMSs = SMSs.Split(new char[] { '\n' });
                            bLower = aSMSs.GetLength(0) < 5;
                            if (!bLower)
                            {
                                //VARIÁVEL DE DECREMENTO
                                iCont = 0;
                                iNumMsgs = (aSMSs.Length - 4) / 2;
                                do
                                {
                                    iDataSMSPos = aSMSs.Length - 4 - iCont;
                                    iSMSPos = aSMSs.Length - 3 - iCont;
                                    //PEGA SEMPRE OS DADOS DA ÚLTIMA MENSAGEM
                                    sSMSParts = aSMSs[iDataSMSPos].Split(new char[] { ',' });
                                    sSMSId = sSMSParts[0].Substring(7);
                                    iLen = sSMSParts[2].Length - 3;
                                    sPhoneNumber = sSMSParts[2].Substring(2, iLen);
                                    //PEGA SEMPRE A ÚLTIMA MENSAGEM
                                    if (aSMSs[iSMSPos].ToUpper().Contains("APAGAR LED"))
                                    {
                                        button3.BackColor = Color.Red;
                                        PortUt.DeleteSMS(SP, sSMSId);
                                        if (chkRespostaAutomatica.Checked) { SMS.Send(SP, txtNumero.Text, "*SISTEMA DE AUTOMACAO* Led apagado por " + sPhoneNumber + " em " + DateTime.Now); }
                                        PortUt.SendSerialMessage(SPSerial, "0");
                                        getLog("Led apagado por " + sPhoneNumber);
                                    }
                                    if (aSMSs[iSMSPos].ToUpper().Contains("ACENDER LED"))
                                    {
                                        button3.BackColor = Color.Green;
                                        PortUt.DeleteSMS(SP, sSMSId);
                                        if (chkRespostaAutomatica.Checked) { SMS.Send(SP, txtNumero.Text, "*SISTEMA DE AUTOMACAO* Led aceso por " + sPhoneNumber + " em " + DateTime.Now); }
                                        PortUt.SendSerialMessage(SPSerial, "1");
                                        getLog("Led aceso por " + sPhoneNumber);
                                    }
                                    iCont = iCont + 2;
                                } while (iCont / 2 < iNumMsgs);
                            }
                        }
                    }
                    bExecuting = false;
                    //tExecTrd.Abort();
                } while (true);
            }
            catch (Exception ex)
            {
                getLog("Thread não executada em " + DateTime.Now + ". Motivo: " + ex.Message + ".");
                Execute();
            }
        }

        public void Timer1Tick(object sender, EventArgs e)
        {
            if (iTimeToRefresh == 0)
            {
                lblTimeToRefresh.Text = "Executando...";
                //iTimeToRefresh = 10;  
            }
            else
            {
                //iTimeToRefresh = iTimeToRefresh - 1 ;
            }
            if (bExecuting) { lblTimeToRefresh.Text = "Executando thread..."; } else { lblTimeToRefresh.Text = "A thread vai ser atualizada em: " + iTimeToRefresh + " seg."; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool SMSs;
            SMSs = PortUt.SendSerialMessage(SPSerial, txtComando.Text);
        }

        private void textButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void textButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        void PopuleCombo_SMSState()
        {
            //Popula a combo com os tipos de mensagem
            DataTable dtWork = new DataTable();
            dtWork.Columns.Add("Nome");
            dtWork.Columns.Add("Cod");
            cmbTipoMensagem.Items.Add(TipoMensagem.STO_SENT);
            cmbTipoMensagem.Items.Add(TipoMensagem.STO_UNSEND);
            cmbTipoMensagem.Items.Add(TipoMensagem.REC_READ);
            cmbTipoMensagem.Items.Add(TipoMensagem.REC_UNREAD);
            cmbTipoMensagem.Items.Add(TipoMensagem.ALL);
        }

        #region Toolbox methods

        private void PopulateToolBox()
        {
            int countI;
            string[] tabNames = new string[] { "Usuários","Equipamentos","Mensagens","Logs"};
            string[,] itemNames = new string[10,2];
            itemNames[0,0] = "Usuários";
            itemNames[0,1] = "Cadastro";
            itemNames[1,0] = "Usuários";
            itemNames[1,1] = "Relatórios";
            itemNames[2,0] = "Equipamentos";
            itemNames[2,1] = "Cadastro";
            itemNames[3,0] = "Equipamentos";
            itemNames[3,1] = "Relatórios";
            itemNames[4,0] = "Mensagens";
            itemNames[4,1] = "Cadastro";
            itemNames[5,0] = "Logs";
            itemNames[5,1] = "Relatórios";

            //Popula tabs
            foreach (string tName in tabNames)
            {
                Toolbox.Tab tab = new Toolbox.Tab();
                tab.AllowDelete = false;
                tab.Opened = true;
                tab.Text = tName;
                this.toolbox1.Categories.Add(tab);
            }

            //Popula itens
            for (countI = 0; countI <= 5; countI++)
            {
                ToolboxItem item = new ToolboxItem();
                item.DisplayName = itemNames[countI, 1];
                this.toolbox1.AddToolboxItem(item, itemNames[countI, 0]);
            }

            //item.Bitmap = Resource1.LOCKEYS2;
            
            


            //Bitmap bitmap = new Bitmap(Properties.Resources.TimeStart);
            //Toolbox.Item myItem = new Toolbox.Item("Time Starter", bitmap, bitmap.GetPixel(0, 0));
            //this.toolbox1.Categories["Toolbox"].Items.Add(myItem);
        }

        private void disableAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Checked)
                toolbox1.EnableItems();
            else
                toolbox1.DisableItems();
            menuItem.Checked = !menuItem.Checked;
        }

        private void hideTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Checked)
                toolbox1.ShowTabs();
            else
                toolbox1.HideTabs();
            menuItem.Checked = !menuItem.Checked;
        }

        private void OnItemSelected(object sender, ItemSelectionEventArgs e)
        {
            //if (toolbox1.SelectedItem != null)
            //    _itemLabel.Text = toolbox1.SelectedItem.Text;
            //else
            //    _itemLabel.Text = "[None]";
        }

        private void OnToolboxDoubleClick(object sender, EventArgs e)
        {
            //Toolbox.Item item = this.toolbox1.SelectedItem;
            //if (item != null && item.Text == "Usuários")
            //{
            //    MessageBox.Show("It's OK!");
            //}
        }

        private void OnToolboxClick(object sender, EventArgs e)
        {
            Toolbox.Item item = this.toolbox1.SelectedItem;
            if (item != null && item.Text == "Usuários")
            {
                MessageBox.Show("It's OK!");
            }
        }

        private void OnSaveToolbox(object sender, EventArgs e)
        {
            this.toolbox1.Save("toolbox.xml");
        }

        private void OnLoadToolbox(object sender, EventArgs e)
        {
            this.toolbox1.Load("toolbox.xml");
        }

        class DemoToolbox : HostToolbox
        {
            public DemoToolbox()
                : base(false)
            {
            }

            public void AddToolboxItem(Type itemType, string tabName)
            {
                AddToolboxItem(new ToolboxItem(itemType), tabName);
            }

            public void AddToolboxItem(ToolboxItem item, string tabName)
            {
                Toolbox.Tab tab = this.Categories[tabName];
                if (tab == null)
                {
                    tab = new Tab(tabName);
                    this.Categories.Add(tab);
                }

                tab.Items.Add(new HostToolbox.HostItem(item));
            }

            public void DisableItems()
            {
                ChangeItemsState(false);
            }

            public void EnableItems()
            {
                ChangeItemsState(true);
            }

            public void HideTabs()
            {
                ChangeTabsState(false);
            }

            public void ShowTabs()
            {
                ChangeTabsState(true);
            }

            private void ChangeItemsState(bool enable)
            {
                foreach (Tab tab in Categories)
                {
                    foreach (Item item in tab.Items)
                        item.Enabled = enable;
                    tab.PointerItem.Enabled = enable;
                }
                Invalidate();
            }

            private void ChangeTabsState(bool show)
            {
                foreach (Tab tab in Categories)
                {
                    if (tab != GeneralCategory)
                    {
                        tab.Visible = show;
                    }
                }
            }
        }
        #endregion

    }
}
