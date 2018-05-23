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

        public static DBConnectConfigFrm _FormSingle;//创建一个静态字段

        public static DBConnectConfigFrm FormSingle//静态字段属性
        {
            get { return DBConnectConfigFrm._FormSingle; }
            set { DBConnectConfigFrm._FormSingle = value; }
        }

        public static DBConnectConfigFrm GetSingle()//创建对象的方法
        {
            if (FormSingle == null)//为空创建一个新对象
            {
                FormSingle = new DBConnectConfigFrm();
            }
            return FormSingle;//否则返回原对象
        }

        public static bool isConnect;

        private void Init()
        {
            this.MaximizeBox = false;
            this.button1.Enabled = false;
            cboDBType.Items.Add("Oracle数据库");
            cboDBType.SelectedIndex = 0;
            cboProtocalType.Items.Add("TCP");
            cboProtocalType.SelectedIndex = 0;
            TestDBConnected();
        }

        Entities1 dbContext = EntityHelper.GetEntities();
        private void TestDBConnected()
        {
            Thread th = new Thread(() =>
            {
                while(true)
                {
                    var state = dbContext.Database.Connection.State;
                    if (state == ConnectionState.Closed)
                    {
                        isConnect = false;
                    }
                    if (state == ConnectionState.Open)
                    {
                        isConnect = true;
                    }
                }
            });
            th.IsBackground = true;
            th.Start();
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
                return;
            }

            if (dbContext.Database.Connection.State == ConnectionState.Open || dbContext.Database.Connection.State == ConnectionState.Connecting)
            {
                dbContext.Database.Connection.Close();
            }
            dbContext.Database.Connection.ConnectionString = entityConnStr;
            //Console.WriteLine(entities2.Database.Connection.ConnectionString);

            //数据库连接验证操作
            var state = dbContext.Database.Connection.State;
            try
            {
                dbContext.Database.Connection.Open();
                //成功
                if (dbContext.Database.Connection.State == ConnectionState.Open)
                {
                    isConnect = true;
                    MessageBox.Show("连接成功！");
                    btnConnect.Enabled = false;
                    button1.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var state = dbContext.Database.Connection.State;
            if (state == ConnectionState.Open)
            {
                dbContext.Database.Connection.Close();
                btnConnect.Enabled = true;
                button1.Enabled = false;
            }
        }
    }
}
