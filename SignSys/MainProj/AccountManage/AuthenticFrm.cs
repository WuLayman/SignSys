using AllInterfaceProj.ServerInterface;
using SeverToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj.AccountManage
{
    public partial class AuthenticFrm : Form
    {
        public bool isManager = false;

        public AuthenticFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isManager = false;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckInputInfo())
            {
                try
                {
                    RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
                    if (recvDataFromDBHelper.JudgeIfManagerExist(GetManager()))
                    {

                        MessageBox.Show("身份验证通过！");
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Close();
                        }));
                        isManager = true;
                    }
                    else
                    {
                        MessageBox.Show("验证未通过！身份信息错误！");
                        isManager = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    isManager = false;
                }
            }
        }

        private Manager GetManager()
        {
            return new Manager()
            {
                ManagerNickName = txtManagerID.Text,
                Password = txtPassword.Text
            };
        }

        private bool CheckInputInfo()
        {
            if (txtManagerID.Text == null || txtManagerID.Text == "")
            {
                MessageBox.Show("管理员ID不能为空！");
                return false;
            }
            if (txtPassword.Text == null || txtPassword.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return false;
            }
            return true;
        }
    }
}
