namespace MainProj.AccountManage
{
    partial class ShowAllUsersFrm
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
            this.dgvUsersInfo = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnShowPwd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDisVisible = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsersInfo
            // 
            this.dgvUsersInfo.AllowUserToAddRows = false;
            this.dgvUsersInfo.AllowUserToDeleteRows = false;
            this.dgvUsersInfo.AllowUserToResizeColumns = false;
            this.dgvUsersInfo.AllowUserToResizeRows = false;
            this.dgvUsersInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUsersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersInfo.Location = new System.Drawing.Point(12, 12);
            this.dgvUsersInfo.Name = "dgvUsersInfo";
            this.dgvUsersInfo.RowTemplate.Height = 23;
            this.dgvUsersInfo.Size = new System.Drawing.Size(593, 301);
            this.dgvUsersInfo.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(428, 330);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 22);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowPwd
            // 
            this.btnShowPwd.Location = new System.Drawing.Point(266, 330);
            this.btnShowPwd.Name = "btnShowPwd";
            this.btnShowPwd.Size = new System.Drawing.Size(75, 23);
            this.btnShowPwd.TabIndex = 2;
            this.btnShowPwd.Text = "显示密码";
            this.btnShowPwd.UseVisualStyleBackColor = true;
            this.btnShowPwd.Click += new System.EventHandler(this.btnShowPwd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(518, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDisVisible
            // 
            this.btnDisVisible.Location = new System.Drawing.Point(347, 330);
            this.btnDisVisible.Name = "btnDisVisible";
            this.btnDisVisible.Size = new System.Drawing.Size(75, 23);
            this.btnDisVisible.TabIndex = 4;
            this.btnDisVisible.Text = "隐藏密码";
            this.btnDisVisible.UseVisualStyleBackColor = true;
            this.btnDisVisible.Click += new System.EventHandler(this.btnDisVisible_Click);
            // 
            // ShowAllUsersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 363);
            this.Controls.Add(this.btnDisVisible);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowPwd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUsersInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ShowAllUsersFrm";
            this.Text = "用户信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowPwd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDisVisible;
    }
}