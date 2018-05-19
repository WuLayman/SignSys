using PublicBaseClassProj;
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

namespace MainProj.SignInfoManage
{
    public partial class SignInfoToday : Form
    {
        public SignInfoToday()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void SignInfoToday_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(597, 372);
            ShowSignInfo();
            SetColumns();
        }

        private void SetColumns()
        {
            SetIDColumn();
            dataGridView1.Columns[0].HeaderCell.Value = "用户名";
            dataGridView1.Columns[1].HeaderCell.Value = "签到时间";
            dataGridView1.Columns[2].HeaderCell.Value = "是否签到";
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Columns[1].DisplayIndex = 4;
            dataGridView1.Columns[2].DisplayIndex = 3;
            dataGridView1.Columns[3].DisplayIndex = 2;
            dataGridView1.Columns[4].DisplayIndex = 0;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        int count1 = 0;
        private void SetIDColumn()
        {
            //添加序号列
            var newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = "ID";
            newColumn.HeaderText = "序号";
            if (count1 == 0)
                dataGridView1.Columns.Add(newColumn);
            count1++;
            SetID();
        }

        private void SetID()
        {
            RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
            var count = recvDataFromDBHelper.ReveiveAllUserInfo().ToList().Count;
            for (int i = 1; i <= count; i++)
            {
                dataGridView1.Rows[i - 1].Cells["ID"].Value = i;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSignInfo();
            //SetColumns();
            SetID();
        }

        int count = 0;
        //当前只显示用户名未显示用户真实姓名
        private void ShowSignInfo()
        {
            try
            {
                RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
                var users = recvDataFromDBHelper.ReveiveAllUserInfo();
                var signInfos = recvDataFromDBHelper.ReceiveTodaySignInfo();
                var data = new List<PersonSignInfo>();

                foreach (var item in users)
                {
                    var signInfo = new PersonSignInfo();
                    foreach (var item1 in signInfos)
                    {
                        if (item.UserNickName == item1.UserNickName)
                        {
                            signInfo.UserNickName = item.UserNickName;
                            signInfo.SignTime = item1.SignTime;
                            signInfo.IsSign = true;
                            data.Add(signInfo);
                            break;
                        }
                    }
                    if (signInfo.UserNickName == null)
                    {
                        signInfo.UserNickName = item.UserNickName;
                        signInfo.IsSign = false;
                        data.Add(signInfo);
                    }
                }
                dataGridView1.DataSource = data;

                //显示真实姓名
                var nickNames = new List<string>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    nickNames.Add(item.Cells["UserNickName"].Value.ToString());
                }
                var newColumn = new DataGridViewTextBoxColumn();
                if (dataGridView1.Columns["RealName"] == null)
                {
                    //获取到真实姓名
                    newColumn.HeaderText = "真实姓名";
                    newColumn.Name = "RealName";
                }
                var RealNames = recvDataFromDBHelper.ReceiveRealName(nickNames);
                if (count == 0)
                    dataGridView1.Columns.Add(newColumn);
                count++;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["RealName"].Value = RealNames[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
