﻿namespace MainProj
{
    partial class SeviceFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tSMIAccountManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMICreateAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIView = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewTimeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewSignInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewAllSignInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMITodaySignInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMITools = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIStartListen = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIDBConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.txtShowMsg = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.关闭服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIAccountManage,
            this.tSMIView,
            this.tSMITools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tSMIAccountManage
            // 
            this.tSMIAccountManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMICreateAccount,
            this.tSMIDeleteAccount});
            this.tSMIAccountManage.Name = "tSMIAccountManage";
            this.tSMIAccountManage.Size = new System.Drawing.Size(68, 21);
            this.tSMIAccountManage.Text = "账户管理";
            // 
            // tSMICreateAccount
            // 
            this.tSMICreateAccount.Name = "tSMICreateAccount";
            this.tSMICreateAccount.Size = new System.Drawing.Size(124, 22);
            this.tSMICreateAccount.Text = "用户注册";
            this.tSMICreateAccount.Click += new System.EventHandler(this.tSMICreateAccount_Click);
            // 
            // tSMIDeleteAccount
            // 
            this.tSMIDeleteAccount.Name = "tSMIDeleteAccount";
            this.tSMIDeleteAccount.Size = new System.Drawing.Size(124, 22);
            this.tSMIDeleteAccount.Text = "用户注销";
            this.tSMIDeleteAccount.Click += new System.EventHandler(this.tSMIDeleteAccount_Click);
            // 
            // tSMIView
            // 
            this.tSMIView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIViewTimeTable,
            this.tSMIViewSignInfo,
            this.tSMIViewMessage,
            this.tSMIViewUser});
            this.tSMIView.Name = "tSMIView";
            this.tSMIView.Size = new System.Drawing.Size(44, 21);
            this.tSMIView.Text = "查看";
            // 
            // tSMIViewTimeTable
            // 
            this.tSMIViewTimeTable.Name = "tSMIViewTimeTable";
            this.tSMIViewTimeTable.Size = new System.Drawing.Size(148, 22);
            this.tSMIViewTimeTable.Text = "查看课表";
            this.tSMIViewTimeTable.Click += new System.EventHandler(this.tSMIViewTimeTable_Click);
            // 
            // tSMIViewSignInfo
            // 
            this.tSMIViewSignInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIViewAllSignInfo,
            this.tSMITodaySignInfo});
            this.tSMIViewSignInfo.Name = "tSMIViewSignInfo";
            this.tSMIViewSignInfo.Size = new System.Drawing.Size(148, 22);
            this.tSMIViewSignInfo.Text = "查看打卡信息";
            // 
            // tSMIViewAllSignInfo
            // 
            this.tSMIViewAllSignInfo.Name = "tSMIViewAllSignInfo";
            this.tSMIViewAllSignInfo.Size = new System.Drawing.Size(148, 22);
            this.tSMIViewAllSignInfo.Text = "全部打卡信息";
            this.tSMIViewAllSignInfo.Click += new System.EventHandler(this.tSMIViewAllSignInfo_Click);
            // 
            // tSMITodaySignInfo
            // 
            this.tSMITodaySignInfo.Name = "tSMITodaySignInfo";
            this.tSMITodaySignInfo.Size = new System.Drawing.Size(148, 22);
            this.tSMITodaySignInfo.Text = "今日打卡结算";
            this.tSMITodaySignInfo.Click += new System.EventHandler(this.tSMITodaySignInfo_Click);
            // 
            // tSMIViewUser
            // 
            this.tSMIViewUser.Name = "tSMIViewUser";
            this.tSMIViewUser.Size = new System.Drawing.Size(148, 22);
            this.tSMIViewUser.Text = "全部用户";
            this.tSMIViewUser.Click += new System.EventHandler(this.tSMIViewUser_Click);
            // 
            // tSMIViewMessage
            // 
            this.tSMIViewMessage.Name = "tSMIViewMessage";
            this.tSMIViewMessage.Size = new System.Drawing.Size(148, 22);
            this.tSMIViewMessage.Text = "查看请假信息";
            this.tSMIViewMessage.Click += new System.EventHandler(this.tSMIViewMessage_Click);
            // 
            // tSMITools
            // 
            this.tSMITools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIStartListen,
            this.关闭服务ToolStripMenuItem,
            this.tSMIDBConfig});
            this.tSMITools.Name = "tSMITools";
            this.tSMITools.Size = new System.Drawing.Size(44, 21);
            this.tSMITools.Text = "工具";
            // 
            // tSMIStartListen
            // 
            this.tSMIStartListen.Name = "tSMIStartListen";
            this.tSMIStartListen.Size = new System.Drawing.Size(160, 22);
            this.tSMIStartListen.Text = "开启服务";
            this.tSMIStartListen.Click += new System.EventHandler(this.tSMIStartListen_Click);
            // 
            // tSMIDBConfig
            // 
            this.tSMIDBConfig.Name = "tSMIDBConfig";
            this.tSMIDBConfig.Size = new System.Drawing.Size(160, 22);
            this.tSMIDBConfig.Text = "数据库连接配置";
            this.tSMIDBConfig.Click += new System.EventHandler(this.tSMIDBConfig_Click);
            // 
            // txtShowMsg
            // 
            this.txtShowMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShowMsg.Location = new System.Drawing.Point(6, 20);
            this.txtShowMsg.Multiline = true;
            this.txtShowMsg.Name = "txtShowMsg";
            this.txtShowMsg.ReadOnly = true;
            this.txtShowMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShowMsg.Size = new System.Drawing.Size(591, 116);
            this.txtShowMsg.TabIndex = 1;
            this.txtShowMsg.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(591, 174);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线用户列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtShowMsg);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态栏";
            // 
            // 关闭服务ToolStripMenuItem
            // 
            this.关闭服务ToolStripMenuItem.Name = "关闭服务ToolStripMenuItem";
            this.关闭服务ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关闭服务ToolStripMenuItem.Text = "关闭服务";
            this.关闭服务ToolStripMenuItem.Click += new System.EventHandler(this.关闭服务ToolStripMenuItem_Click);
            // 
            // SeviceFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 382);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SeviceFrm";
            this.Text = "服务端";
            this.Load += new System.EventHandler(this.SeviceFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMIAccountManage;
        private System.Windows.Forms.ToolStripMenuItem tSMICreateAccount;
        private System.Windows.Forms.ToolStripMenuItem tSMIDeleteAccount;
        private System.Windows.Forms.ToolStripMenuItem tSMIView;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewTimeTable;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewSignInfo;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewAllSignInfo;
        private System.Windows.Forms.ToolStripMenuItem tSMITools;
        private System.Windows.Forms.ToolStripMenuItem tSMIStartListen;
        private System.Windows.Forms.ToolStripMenuItem tSMIDBConfig;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewUser;
        private System.Windows.Forms.TextBox txtShowMsg;
        private System.Windows.Forms.ToolStripMenuItem tSMITodaySignInfo;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem 关闭服务ToolStripMenuItem;
    }
}

