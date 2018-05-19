namespace MainProj.ConfigConnectionString
{
    partial class DBConnectConfigFrm
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
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.btnCloseConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtSeverName = new System.Windows.Forms.TextBox();
            this.lblSeverName = new System.Windows.Forms.Label();
            this.txtSeverPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeverIP = new System.Windows.Forms.TextBox();
            this.lblSeverIP = new System.Windows.Forms.Label();
            this.cboProtocalType = new System.Windows.Forms.ComboBox();
            this.lblProtocal = new System.Windows.Forms.Label();
            this.lblConnStrConfig = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboDBType = new System.Windows.Forms.ComboBox();
            this.lblDBType = new System.Windows.Forms.Label();
            this.grpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConfig
            // 
            this.grpConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfig.Controls.Add(this.btnCloseConnect);
            this.grpConfig.Controls.Add(this.label2);
            this.grpConfig.Controls.Add(this.txtPassWord);
            this.grpConfig.Controls.Add(this.lblPassword);
            this.grpConfig.Controls.Add(this.txtUserID);
            this.grpConfig.Controls.Add(this.lblUserName);
            this.grpConfig.Controls.Add(this.txtSeverName);
            this.grpConfig.Controls.Add(this.lblSeverName);
            this.grpConfig.Controls.Add(this.txtSeverPort);
            this.grpConfig.Controls.Add(this.label1);
            this.grpConfig.Controls.Add(this.txtSeverIP);
            this.grpConfig.Controls.Add(this.lblSeverIP);
            this.grpConfig.Controls.Add(this.cboProtocalType);
            this.grpConfig.Controls.Add(this.lblProtocal);
            this.grpConfig.Controls.Add(this.lblConnStrConfig);
            this.grpConfig.Controls.Add(this.btnClose);
            this.grpConfig.Controls.Add(this.btnConnect);
            this.grpConfig.Controls.Add(this.cboDBType);
            this.grpConfig.Controls.Add(this.lblDBType);
            this.grpConfig.Location = new System.Drawing.Point(12, 6);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(452, 318);
            this.grpConfig.TabIndex = 1;
            this.grpConfig.TabStop = false;
            // 
            // btnCloseConnect
            // 
            this.btnCloseConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseConnect.Location = new System.Drawing.Point(198, 280);
            this.btnCloseConnect.Name = "btnCloseConnect";
            this.btnCloseConnect.Size = new System.Drawing.Size(75, 23);
            this.btnCloseConnect.TabIndex = 19;
            this.btnCloseConnect.Text = "断开连接";
            this.btnCloseConnect.UseVisualStyleBackColor = true;
            this.btnCloseConnect.Click += new System.EventHandler(this.btnCloseConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 18;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassWord.Location = new System.Drawing.Point(77, 227);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(358, 21);
            this.txtPassWord.TabIndex = 17;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 230);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "密码：";
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Location = new System.Drawing.Point(77, 197);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(358, 21);
            this.txtUserID.TabIndex = 15;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(18, 200);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "用户名：";
            // 
            // txtSeverName
            // 
            this.txtSeverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeverName.Location = new System.Drawing.Point(77, 167);
            this.txtSeverName.Name = "txtSeverName";
            this.txtSeverName.Size = new System.Drawing.Size(358, 21);
            this.txtSeverName.TabIndex = 13;
            this.txtSeverName.Text = "orcl";
            // 
            // lblSeverName
            // 
            this.lblSeverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeverName.AutoSize = true;
            this.lblSeverName.Location = new System.Drawing.Point(7, 170);
            this.lblSeverName.Name = "lblSeverName";
            this.lblSeverName.Size = new System.Drawing.Size(65, 12);
            this.lblSeverName.TabIndex = 12;
            this.lblSeverName.Text = "服务器名：";
            // 
            // txtSeverPort
            // 
            this.txtSeverPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeverPort.Location = new System.Drawing.Point(77, 137);
            this.txtSeverPort.Name = "txtSeverPort";
            this.txtSeverPort.Size = new System.Drawing.Size(358, 21);
            this.txtSeverPort.TabIndex = 11;
            this.txtSeverPort.Text = "1521";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "端口号：";
            // 
            // txtSeverIP
            // 
            this.txtSeverIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeverIP.Location = new System.Drawing.Point(78, 107);
            this.txtSeverIP.Name = "txtSeverIP";
            this.txtSeverIP.Size = new System.Drawing.Size(357, 21);
            this.txtSeverIP.TabIndex = 9;
            // 
            // lblSeverIP
            // 
            this.lblSeverIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeverIP.AutoSize = true;
            this.lblSeverIP.Location = new System.Drawing.Point(6, 110);
            this.lblSeverIP.Name = "lblSeverIP";
            this.lblSeverIP.Size = new System.Drawing.Size(65, 12);
            this.lblSeverIP.TabIndex = 8;
            this.lblSeverIP.Text = "服务器IP：";
            // 
            // cboProtocalType
            // 
            this.cboProtocalType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProtocalType.FormattingEnabled = true;
            this.cboProtocalType.Location = new System.Drawing.Point(78, 77);
            this.cboProtocalType.Name = "cboProtocalType";
            this.cboProtocalType.Size = new System.Drawing.Size(357, 20);
            this.cboProtocalType.TabIndex = 7;
            this.cboProtocalType.Text = "TCP";
            // 
            // lblProtocal
            // 
            this.lblProtocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProtocal.AutoSize = true;
            this.lblProtocal.Location = new System.Drawing.Point(31, 80);
            this.lblProtocal.Name = "lblProtocal";
            this.lblProtocal.Size = new System.Drawing.Size(41, 12);
            this.lblProtocal.TabIndex = 6;
            this.lblProtocal.Text = "协议：";
            // 
            // lblConnStrConfig
            // 
            this.lblConnStrConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnStrConfig.AutoSize = true;
            this.lblConnStrConfig.Location = new System.Drawing.Point(6, 50);
            this.lblConnStrConfig.Name = "lblConnStrConfig";
            this.lblConnStrConfig.Size = new System.Drawing.Size(101, 12);
            this.lblConnStrConfig.TabIndex = 5;
            this.lblConnStrConfig.Text = "连接字符串配置：";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(360, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(279, 280);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboDBType
            // 
            this.cboDBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDBType.FormattingEnabled = true;
            this.cboDBType.Location = new System.Drawing.Point(78, 14);
            this.cboDBType.Name = "cboDBType";
            this.cboDBType.Size = new System.Drawing.Size(357, 20);
            this.cboDBType.TabIndex = 1;
            this.cboDBType.Text = "Oracle数据库";
            // 
            // lblDBType
            // 
            this.lblDBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDBType.AutoSize = true;
            this.lblDBType.Location = new System.Drawing.Point(6, 17);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(77, 12);
            this.lblDBType.TabIndex = 0;
            this.lblDBType.Text = "数据库类型：";
            // 
            // DBConnectConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 328);
            this.Controls.Add(this.grpConfig);
            this.Name = "DBConnectConfigFrm";
            this.Text = "数据库连接配置";
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtSeverName;
        private System.Windows.Forms.Label lblSeverName;
        private System.Windows.Forms.TextBox txtSeverPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeverIP;
        private System.Windows.Forms.Label lblSeverIP;
        private System.Windows.Forms.ComboBox cboProtocalType;
        private System.Windows.Forms.Label lblProtocal;
        private System.Windows.Forms.Label lblConnStrConfig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboDBType;
        private System.Windows.Forms.Label lblDBType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCloseConnect;
    }
}