using Oracle.ManagedDataAccess.Client;
using SeverToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj.ConfigConnectionString
{
    public partial class DBConnectConfigFrm : Form
    {
        public DBConnectConfigFrm()
        {
            InitializeComponent();
            Init();
        }

        public static bool isConnect;

        private void Init()
        {
            this.MaximizeBox = false;
            cboDBType.Items.Add("Oracle数据库");
            cboDBType.SelectedIndex = 0;
            cboProtocalType.Items.Add("TCP");
            cboProtocalType.SelectedIndex = 0;
            this.btnCloseConnect.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool b = false;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (b)
            {
                MessageBox.Show("正在连接中...请稍后");
                return;
            }
            var entityConnStr = GetconnStr("Entity");
            if (entityConnStr == null)
            {
                MessageBox.Show("连接字符串为空！");
                return;
            }

            Entities1 entities2 = EntityHelper.GetEntities();
            entities2.Database.Connection.ConnectionString = entityConnStr;
            Console.WriteLine(entities2.Database.Connection.ConnectionString);

            //数据库连接验证操作
            var state = entities2.Database.Connection.State;
            try
            {
                entities2.Database.Connection.Open();
                //成功
                if (entities2.Database.Connection.State == ConnectionState.Open)
                {
                    isConnect = true;
                    MessageBox.Show("连接成功！");
                    this.btnCloseConnect.Enabled = true;
                    this.btnConnect.Enabled = false;
                    //btnConnect.Enabled = false;
                    this.Close();
                }
                else
                {
                    //失败
                    MessageBox.Show("连接失败!");
                    isConnect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetconnStr(string type)
        {
            ConnStrHelper connStr = new ConnStrHelper();
            connStr.Protocal = cboProtocalType.SelectedItem.ToString();
            connStr.Host = txtSeverIP.Text;
            connStr.Port = txtSeverPort.Text;
            connStr.ServiceName = txtSeverName.Text;
            connStr.UserID = txtUserID.Text;
            connStr.Password = txtPassWord.Text;

            if (CheckInputInfo(connStr))//校验
            {
                if (type == "Entity")
                    return connStr.GetEntityConnStr();
                if (type == "Config")
                    return connStr.GetConnStr();
            }
            return null;
        }

        private void EncryptAndSaveConnStr(string connStr)
        {
            EncryptionHelper encryption = new EncryptionHelper();
            encryption.EncrytAndSave(connStr);
        }

        private bool CheckInputInfo(ConnStrHelper connStr)
        {
            try
            {
                if (connStr.Host == null || connStr.Host == "")
                {
                    MessageBox.Show("服务器IP不可为空");
                    return false;
                }
                if (connStr.Port == null || connStr.Port == "")
                {
                    MessageBox.Show("端口号不可为空");
                    return false;
                }
                if (int.Parse(connStr.Port) <= 0 || int.Parse(connStr.Port) > 65535)
                {
                    MessageBox.Show("端口号不在正确范围内");
                    return false;
                }
                if (connStr.ServiceName == null || connStr.ServiceName == "")
                {
                    MessageBox.Show("服务器名不可为空");
                    return false;
                }
                if (connStr.UserID == null || connStr.UserID == "")
                {
                    MessageBox.Show("用户名不可为空");
                    return false;
                }
                if (connStr.Password == null || connStr.Password == "")
                {
                    MessageBox.Show("密码不可为空");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void btnCloseConnect_Click(object sender, EventArgs e)
        {
            Entities1 entities2 = EntityHelper.GetEntities();
            entities2.Database.Connection.Close();
            var state = entities2.Database.Connection.State;
            this.btnCloseConnect.Enabled = false;
            this.btnConnect.Enabled = true;
            isConnect = false;
        }
    }
}
