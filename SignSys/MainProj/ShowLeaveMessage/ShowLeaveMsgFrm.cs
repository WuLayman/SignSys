using SeverToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PublicBaseClassProj;

namespace MainProj.ShowLeaveMessage
{
    public partial class ShowLeaveMsgFrm : Form
    {
        public ShowLeaveMsgFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            var newData = GetBaseData();
            dataGridView1.DataSource = newData;
            SetAllColumns();
        }

        private static List<LeaveMessage> GetBaseData()
        {
            RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
            var data = recvDataFromDBHelper.ReceiveLeaveMsg();
            var newData = data.OrderByDescending(x => x.LeaveTime).ToList();
            return newData;
        }

        private void btnViewToday_Click(object sender, EventArgs e)
        {
            var newData = GetBaseData();
            List<LeaveMessage> data = new List<LeaveMessage>();
            foreach (var item in newData)
            {
                if (item.LeaveTime.ToString("yyyyMMdd") == DateTime.Today.ToString("yyyyMMdd"))
                {
                    data.Add(item);
                }
            }
            if (data.Count == 0)
            {
                MessageBox.Show("今日还未有人请假！");
                return;
            }
            else
            {
                dataGridView1.DataSource = data;
                SetAllColumns();
            }
        }

        private void SetAllColumns()
        {
            SetIDColumn();
            dataGridView1.Columns["RealName"].HeaderCell.Value = "真实姓名";
            dataGridView1.Columns["LeaveState"].HeaderCell.Value = "状态";
            dataGridView1.Columns["LeaveTime"].HeaderCell.Value = "离开时间";
            dataGridView1.Columns["Message"].HeaderCell.Value = "请假信息";
            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.Columns["RealName"].DisplayIndex = 1;
            dataGridView1.Columns["LeaveState"].DisplayIndex = 2;
            dataGridView1.Columns["LeaveTime"].DisplayIndex = 3;
            dataGridView1.Columns["Message"].DisplayIndex = 4;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
        }

        int count = 0;
        private void SetIDColumn()
        {
            DataGridViewTextBoxColumn dgv = new DataGridViewTextBoxColumn();
            dgv.Name = "ID";
            dgv.HeaderText = "序号";
            if (count == 0)
            {
                dataGridView1.Columns.Add(dgv);
            }
            count++;
            SetID();
        }

        private void SetID()
        {
            var count = dataGridView1.Rows.Count;
            for (int i = 1; i <= count; i++)
            {
                dataGridView1.Rows[i - 1].Cells["ID"].Value = i;
            }
        }
    }
}
