using PublicBaseClassProj;
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

namespace MainProj.SignInfoManage
{
    public partial class AllSignInfoFrm : Form
    {
        public AllSignInfoFrm()
        {
            InitializeComponent();
        }

        private void AllSignInfoFrm_Load(object sender, EventArgs e)
        {
            ShowSignInfo();
            SetColumns();
            this.MinimumSize = new Size(655, 421);
        }

        RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
        private void ShowSignInfo()
        {
            try
            {
                var data = recvDataFromDBHelper.ReceiveAllSignInfo();
                data = data.OrderByDescending(x => x.SignTime).ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowSignInfo();
            SetColumns();
        }

        private void SetColumns()
        {
            SetIDColumn();
            //var count = dataGridView1.ColumnCount;
            dataGridView1.Columns["UserNickName"].HeaderCell.Value = "用户名";
            dataGridView1.Columns["SignTime"].HeaderCell.Value = "时间";
            dataGridView1.Columns["IsSign"].HeaderCell.Value = "是否签到";
            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.Columns["UserNickName"].DisplayIndex = 1;
            dataGridView1.Columns["IsSign"].DisplayIndex = 2;
            dataGridView1.Columns["SignTime"].DisplayIndex = 3;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
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
            try
            {
                var count = dataGridView1.Rows.Count;
                for (int i = 1; i <= count; i++)
                {
                    dataGridView1.Rows[i - 1].Cells["ID"].Value = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            var nickName = textBox1.Text;
            var data = recvDataFromDBHelper.ReceiveAllSignInfo();
            List<PersonSignInfo> datas = new List<PersonSignInfo>();
            foreach (var item in data)
            {
                if (item.UserNickName == nickName)
                    datas.Add(item);
            }
            if (datas.Count == 0)
            {
                MessageBox.Show("未找到该用户的签到信息！");
                return;
            }
            dataGridView1.DataSource = datas;
            SetIDColumn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
