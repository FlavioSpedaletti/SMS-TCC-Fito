namespace WindowsApplication1
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoMensagem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.lblTimeToRefresh = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolbox1 = new WindowsApplication1.frmMain.DemoToolbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textButton3 = new CustomButtons.TextButton();
            this.textButton2 = new CustomButtons.TextButton();
            this.textButton1 = new CustomButtons.TextButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new DotNetSkin.SkinControls.SkinButton();
            this.skinImage1 = new DotNetSkin.SkinControls.SkinImage();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.chkRespostaAutomatica = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pgbSignal = new System.Windows.Forms.ProgressBar();
            this.lblBtSt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textButton4 = new CustomButtons.TextButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Receber SMSs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(297, 224);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(123, 29);
            this.button22.TabIndex = 1;
            this.button22.Text = "Mandar SMS";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Location = new System.Drawing.Point(289, 73);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(413, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Text = "93559352";
            // 
            // txtMensagem
            // 
            this.txtMensagem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensagem.Location = new System.Drawing.Point(289, 118);
            this.txtMensagem.MaxLength = 100;
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(553, 100);
            this.txtMensagem.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mensagem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número";
            // 
            // cmbTipoMensagem
            // 
            this.cmbTipoMensagem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTipoMensagem.FormattingEnabled = true;
            this.cmbTipoMensagem.Location = new System.Drawing.Point(289, 316);
            this.cmbTipoMensagem.Name = "cmbTipoMensagem";
            this.cmbTipoMensagem.Size = new System.Drawing.Size(553, 21);
            this.cmbTipoMensagem.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de mensagem a ser recebida";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(793, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "LED";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(289, 443);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "Enviar pela serial";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(289, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Comando";
            // 
            // txtComando
            // 
            this.txtComando.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComando.Location = new System.Drawing.Point(289, 415);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(553, 20);
            this.txtComando.TabIndex = 10;
            // 
            // lblTimeToRefresh
            // 
            this.lblTimeToRefresh.AutoSize = true;
            this.lblTimeToRefresh.BackColor = System.Drawing.Color.White;
            this.lblTimeToRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToRefresh.Location = new System.Drawing.Point(289, 663);
            this.lblTimeToRefresh.Name = "lblTimeToRefresh";
            this.lblTimeToRefresh.Size = new System.Drawing.Size(96, 13);
            this.lblTimeToRefresh.TabIndex = 12;
            this.lblTimeToRefresh.Text = "iTimeToRefresh";
            this.lblTimeToRefresh.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CRDFLE07.ICO");
            this.imageList1.Images.SetKeyName(1, "sav.ico");
            this.imageList1.Images.SetKeyName(2, "3d closed.ico");
            this.imageList1.Images.SetKeyName(3, "LOCKEYS2.ICO");
            this.imageList1.Images.SetKeyName(4, "wallet.ico");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(561, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 60);
            this.panel1.TabIndex = 16;
            // 
            // toolbox1
            // 
            this.toolbox1.AllowDrop = true;
            this.toolbox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolbox1.BackColorGradientEnd = System.Drawing.Color.White;
            this.toolbox1.BackColorGradientStart = System.Drawing.Color.Gainsboro;
            this.toolbox1.Location = new System.Drawing.Point(83, 48);
            this.toolbox1.Name = "toolbox1";
            this.toolbox1.SelectedCategory = "";
            this.toolbox1.ShowPointer = false;
            this.toolbox1.Size = new System.Drawing.Size(192, 648);
            this.toolbox1.TabColorStyle = IP.Components.Toolbox.ColorStyle.Darker;
            this.toolbox1.TabIndex = 17;
            this.toolbox1.Text = "toolbox1";
            this.toolbox1.DoubleClick += new System.EventHandler(this.OnToolboxDoubleClick);
            this.toolbox1.SelectItem += new System.EventHandler<IP.Components.ItemSelectionEventArgs>(this.OnItemSelected);
            this.toolbox1.Click += new System.EventHandler(this.OnToolboxClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textButton3);
            this.panel2.Controls.Add(this.textButton2);
            this.panel2.Controls.Add(this.textButton1);
            this.panel2.Location = new System.Drawing.Point(793, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(53, 18);
            this.panel2.TabIndex = 21;
            // 
            // textButton3
            // 
            this.textButton3.BackColor = System.Drawing.Color.White;
            this.textButton3.DefaultText = "_";
            this.textButton3.DisabledColor = System.Drawing.Color.Transparent;
            this.textButton3.DisabledText = "_";
            this.textButton3.DownText = "_";
            this.textButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.textButton3.ForeColor = System.Drawing.Color.Navy;
            this.textButton3.HoverColor = System.Drawing.Color.CadetBlue;
            this.textButton3.HoverText = "_";
            this.textButton3.Location = new System.Drawing.Point(-3, -5);
            this.textButton3.Margin = new System.Windows.Forms.Padding(4);
            this.textButton3.Name = "textButton3";
            this.textButton3.ShadowColor = System.Drawing.Color.Transparent;
            this.textButton3.Size = new System.Drawing.Size(21, 18);
            this.textButton3.TabIndex = 18;
            this.textButton3.Click += new System.EventHandler(this.textButton3_Click);
            // 
            // textButton2
            // 
            this.textButton2.BackColor = System.Drawing.Color.White;
            this.textButton2.DefaultText = "x";
            this.textButton2.DisabledColor = System.Drawing.Color.Transparent;
            this.textButton2.DisabledText = "x";
            this.textButton2.DownText = "x";
            this.textButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textButton2.ForeColor = System.Drawing.Color.Navy;
            this.textButton2.HoverColor = System.Drawing.Color.CadetBlue;
            this.textButton2.HoverText = "x";
            this.textButton2.Location = new System.Drawing.Point(30, -2);
            this.textButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textButton2.Name = "textButton2";
            this.textButton2.ShadowColor = System.Drawing.Color.Transparent;
            this.textButton2.Size = new System.Drawing.Size(21, 18);
            this.textButton2.TabIndex = 17;
            this.textButton2.Click += new System.EventHandler(this.textButton2_Click);
            // 
            // textButton1
            // 
            this.textButton1.BackColor = System.Drawing.Color.White;
            this.textButton1.DefaultText = "";
            this.textButton1.DisabledColor = System.Drawing.Color.Silver;
            this.textButton1.DisabledText = "";
            this.textButton1.DownText = "";
            this.textButton1.Enabled = false;
            this.textButton1.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textButton1.ForeColor = System.Drawing.Color.Silver;
            this.textButton1.HoverColor = System.Drawing.Color.CadetBlue;
            this.textButton1.HoverText = "";
            this.textButton1.Location = new System.Drawing.Point(13, -6);
            this.textButton1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.textButton1.Name = "textButton1";
            this.textButton1.ShadowColor = System.Drawing.Color.Transparent;
            this.textButton1.Size = new System.Drawing.Size(22, 23);
            this.textButton1.TabIndex = 16;
            this.textButton1.Click += new System.EventHandler(this.textButton1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Olive;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 47);
            this.panel3.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(19, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(751, 25);
            this.panel5.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(289, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 28);
            this.button2.TabIndex = 23;
            this.button2.Text = "Mandar SMS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // skinImage1
            // 
            this.skinImage1.Scheme = DotNetSkin.SkinControls.Schemes.Plex;
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(292, 493);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(550, 160);
            this.lstLog.TabIndex = 24;
            // 
            // chkRespostaAutomatica
            // 
            this.chkRespostaAutomatica.AutoSize = true;
            this.chkRespostaAutomatica.BackColor = System.Drawing.Color.White;
            this.chkRespostaAutomatica.Location = new System.Drawing.Point(716, 73);
            this.chkRespostaAutomatica.Name = "chkRespostaAutomatica";
            this.chkRespostaAutomatica.Size = new System.Drawing.Size(126, 17);
            this.chkRespostaAutomatica.TabIndex = 25;
            this.chkRespostaAutomatica.Text = "Resposta automática";
            this.chkRespostaAutomatica.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pgbSignal);
            this.panel4.Controls.Add(this.lblBtSt);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.textButton4);
            this.panel4.Location = new System.Drawing.Point(24, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(754, 23);
            this.panel4.TabIndex = 26;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // pgbSignal
            // 
            this.pgbSignal.BackColor = System.Drawing.Color.Gainsboro;
            this.pgbSignal.Location = new System.Drawing.Point(177, 1);
            this.pgbSignal.Maximum = 30;
            this.pgbSignal.Name = "pgbSignal";
            this.pgbSignal.Size = new System.Drawing.Size(100, 17);
            this.pgbSignal.Step = 1;
            this.pgbSignal.TabIndex = 26;
            // 
            // lblBtSt
            // 
            this.lblBtSt.AutoSize = true;
            this.lblBtSt.Location = new System.Drawing.Point(49, 4);
            this.lblBtSt.Name = "lblBtSt";
            this.lblBtSt.Size = new System.Drawing.Size(0, 13);
            this.lblBtSt.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(578, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "SISTEMA DE AUTOMAÇÃO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 16);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // textButton4
            // 
            this.textButton4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textButton4.DefaultText = "~";
            this.textButton4.DisabledColor = System.Drawing.Color.Transparent;
            this.textButton4.DisabledText = "~";
            this.textButton4.DownText = "~";
            this.textButton4.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.textButton4.ForeColor = System.Drawing.Color.Navy;
            this.textButton4.HoverColor = System.Drawing.Color.CadetBlue;
            this.textButton4.HoverText = "~";
            this.textButton4.Location = new System.Drawing.Point(149, 0);
            this.textButton4.Margin = new System.Windows.Forms.Padding(4);
            this.textButton4.Name = "textButton4";
            this.textButton4.ShadowColor = System.Drawing.Color.Transparent;
            this.textButton4.Size = new System.Drawing.Size(21, 16);
            this.textButton4.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Olive;
            this.panel6.Location = new System.Drawing.Point(0, 43);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(50, 666);
            this.panel6.TabIndex = 27;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 704);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chkRespostaAutomatica);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTimeToRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtComando);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoMensagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Automação";
            this.TransparencyKey = System.Drawing.Color.Olive;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoMensagem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.Label lblTimeToRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        //private IP.Components.Toolbox toolbox1;
        private frmMain.DemoToolbox toolbox1;
        private System.Windows.Forms.Panel panel2;
        private CustomButtons.TextButton textButton3;
        private CustomButtons.TextButton textButton2;
        private CustomButtons.TextButton textButton1;
        private System.Windows.Forms.Panel panel3;
        private DotNetSkin.SkinControls.SkinButton button2;
        private DotNetSkin.SkinControls.SkinImage skinImage1;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.CheckBox chkRespostaAutomatica;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButtons.TextButton textButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblBtSt;
        private System.Windows.Forms.ProgressBar pgbSignal;
    }
}

