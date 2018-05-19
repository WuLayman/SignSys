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

namespace MainProj.AccountManage
{
    public partial class DeleteAccountFrm : Form
    {
        public DeleteAccountFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CheckInputInfo();
            try
            {
                SendInfoToDB send = new SendInfoToDB();
                if (send.SendDeleteUserInfoToDB(GetPerson()))
                {
                    MessageBox.Show("注销成功！");
                }
                else
                {
                    MessageBox.Show("注销失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private PersonInfo GetPerson()
        {
            return new PersonInfo()
            {
                UserNickName = txtNickName.Text,
                UserRealName = txtRealName.Text
            };
        }

        private void CheckInputInfo()
        {
            if (txtNickName.Text == null || txtNickName.Text == "")
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            if (txtRealName.Text == null || txtRealName.Text == "")
            {
                MessageBox.Show("真实姓名不能为空!");
                return;
            }
        }
    }
}
