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

namespace MainProj.AccountManage
{
    public partial class ShowAllUsersFrm : Form
    {
        public ShowAllUsersFrm()
        {
            InitializeComponent();
            RefreshUsersInfo();
            SetColumnsProperties();
        }

        private void RefreshUsersInfo()
        {
            RefreshData();
        }

        private void SetColumnsProperties()
        {
            dgvUsersInfo.Columns[0].HeaderCell.Value = "用户名";
            dgvUsersInfo.Columns[1].HeaderCell.Value = "真实姓名";
            dgvUsersInfo.Columns[2].HeaderCell.Value = "密码";
            dgvUsersInfo.Columns[3].HeaderCell.Value = "MAC地址";
            dgvUsersInfo.Columns[0].ReadOnly = true;
            dgvUsersInfo.Columns[1].ReadOnly = true;
            dgvUsersInfo.Columns[2].ReadOnly = true;
            dgvUsersInfo.Columns[3].ReadOnly = true;
            dgvUsersInfo.Columns[2].Visible = false;
        }

        private void RefreshData()
        {
            RecvDataFromDBHelper recvData = new RecvDataFromDBHelper();
            var data = recvData.ReveiveAllUserInfo();
            dgvUsersInfo.DataSource = data;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetColumnsProperties();
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPwd_Click(object sender, EventArgs e)
        {
            dgvUsersInfo.Columns[2].Visible = true;
        }

        private void btnDisVisible_Click(object sender, EventArgs e)
        {
            dgvUsersInfo.Columns[2].Visible = false;
        }
    }
}
