using MainProj.AccountManage;
using MainProj.ConfigConnectionString;
using MainProj.PictureManage;
using MainProj.ShowLeaveMessage;
using MainProj.SignInfoManage;
using SeverToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFSocket.CommunicateManager;

namespace MainProj
{
    public partial class SeviceFrm : Form
    {
        public SeviceFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Thread th = new Thread(() =>
             {
                 while (true)
                 {
                     if (DBConnectConfigFrm.isConnect)
                     {
                         b = true;
                     }
                     else
                     {
                         b = false;
                     }
                 }
             });
            th.IsBackground = true;
            th.Start();
        }

        private bool SecurityCheck()
        {
            AuthenticFrm authenticFrm = new AuthenticFrm();
            authenticFrm.StartPosition = FormStartPosition.CenterParent;
            authenticFrm.ShowDialog();
            return authenticFrm.isManager;
        }

        private void tSMICreateAccount_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                CreateAccountFrm createAccount = new CreateAccountFrm();
                createAccount.StartPosition = FormStartPosition.CenterParent;
                createAccount.ShowDialog();
            }
        }

        private void tSMIDeleteAccount_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                DeleteAccountFrm deleteAccount = new DeleteAccountFrm();
                deleteAccount.StartPosition = FormStartPosition.CenterParent;
                deleteAccount.ShowDialog();
            }
        }

        private bool CheckConnect()
        {
            if (b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool b = false;

        private void tSMIDBConfig_Click(object sender, EventArgs e)
        {
            DBConnectConfigFrm dBConnectConfigFrm = DBConnectConfigFrm.GetSingle();
            dBConnectConfigFrm.StartPosition = FormStartPosition.CenterParent;
            dBConnectConfigFrm.ShowDialog();
        }

        private void tSMIViewTimeTable_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先连接数据库！");
                return;
            }
            if (SecurityCheck())
            {
                RefreshTxtMsg("正在查询用户课表...");
                ShowPictureFrm showPictureFrm = new ShowPictureFrm();
                showPictureFrm.StartPosition = FormStartPosition.CenterParent;
                showPictureFrm.ShowDialog();
            }
        }

        private void tSMIViewAllSignInfo_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                RefreshTxtMsg("正在查询全部用户签到信息...");
                AllSignInfoFrm allSignInfoFrm = new AllSignInfoFrm();
                allSignInfoFrm.StartPosition = FormStartPosition.CenterParent;
                allSignInfoFrm.ShowDialog();
            }
        }

        private void tSMIViewUser_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                RefreshTxtMsg("正在查询全部用户信息...");
                ShowAllUsersFrm showAllUsersFrm = new ShowAllUsersFrm();
                showAllUsersFrm.StartPosition = FormStartPosition.CenterParent;
                showAllUsersFrm.ShowDialog();
            }
        }

        private void RefreshTxtMsg(string msg)
        {
            this.BeginInvoke(new Action(() => { txtShowMsg.Text += msg + DateTime.Now.ToString() + "\r\n"; }));
        }

        bool b2 = false;
        private void tSMIStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (b2 == true && b3 == false)
                {
                    MessageBox.Show("服务正在运行中...");
                    return;
                }
                if (ServerOperation.SetConnectionToClient())
                {
                    RefreshTxtMsg("成功开启服务!");
                    b2 = true;
                    b3 = false;
                    UserChanged += ShowUsersOnline;
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    RefreshTxtMsg("开启服务失败!" + ServerOperation.ErrorMsg);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SeviceFrm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(602, 377);
        }

        private void tSMITodaySignInfo_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                SignInfoToday signInfoToday = new SignInfoToday();
                signInfoToday.StartPosition = FormStartPosition.CenterParent;
                signInfoToday.ShowDialog();
            }
        }

        private void tSMIViewMessage_Click(object sender, EventArgs e)
        {
            if (!CheckConnect())
            {
                MessageBox.Show("请先配置数据库连接！");
                return;
            }
            if (SecurityCheck())
            {
                ShowLeaveMsgFrm showLeaveMsgFrm = new ShowLeaveMsgFrm();
                showLeaveMsgFrm.StartPosition = FormStartPosition.CenterParent;
                showLeaveMsgFrm.ShowDialog();
            }
        }

        private event Action UserChanged;
        static int Count = 0;
        static List<Person> people = null;

        private void ShowUsersOnline()
        {
            dataGridView1.DataSource = PersonIPEndPointCollection.GetUsersMsg(people);
            try
            {
                dataGridView1.Columns["UserRealName"].HeaderCell.Value = "用户姓名";
                dataGridView1.Columns["UserIP"].HeaderCell.Value = "IP地址";
                dataGridView1.Columns["UserPoint"].HeaderCell.Value = "端口号";
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                this.dataGridView1.ClearSelection();
                this.dataGridView1.TabStop = false;
            }
            catch
            {
                dataGridView1.DataSource = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            people = ServerOperation.ReceiveClientInfo();
            var nums = people.Count;
            UserChanged();
        }

        private bool b3 = false;
        private void 关闭服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerOperation.CloseConnectionToClient())
            {
                RefreshTxtMsg("成功关闭服务!");
                b3 = true;
                dataGridView1.DataSource = null;
            }
            else
            {
                RefreshTxtMsg("关闭服务失败!" + ServerOperation.ErrorMsg);
            }
        }
    }
}
