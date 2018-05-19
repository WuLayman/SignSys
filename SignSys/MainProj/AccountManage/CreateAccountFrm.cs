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

namespace MainProj.AccountManage
{
    public partial class CreateAccountFrm : Form
    {
        public CreateAccountFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxt();
        }

        private void ResetTxt()
        {
            txtUserNickName.ResetText();
            txtUserRealName.ResetText();
            txtPwd1.ResetText();
            txtPwd2.ResetText();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputInfo())
                {
                    PersonInfo person = new PersonInfo()
                    {
                        UserNickName = txtUserNickName.Text,
                        UserRealName = txtUserRealName.Text,
                        PassWord = txtPwd2.Text
                    };
                    DataHelper data = new DataHelper();
                    if (data.SendNewPersonInfoToDB(person))
                    {
                        MessageBox.Show("注册成功！");
                    }
                    else
                    {
                        MessageBox.Show("注册失败！");
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckInputInfo()
        {
            if (txtUserNickName.Text == null || txtUserNickName.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return false;
            }
            if (txtUserRealName.Text == null || txtUserRealName.Text == "")
            {
                MessageBox.Show("真实姓名不能为空！");
                return false;
            }
            if (txtPwd1.Text == null || txtPwd1.Text == "")
            {
                MessageBox.Show("密码输入不能为空！");
                return false;
            }
            if (txtPwd2.Text == null || txtPwd2.Text == "")
            {
                MessageBox.Show("密码输入不能为空!");
                return false;
            }
            if (txtPwd1.Text != txtPwd2.Text)
            {
                MessageBox.Show("密码不一致!");
                return false;
            }
            return true;
        }

        private void cbShowOrNot_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPwd1.PasswordChar == '*' && txtPwd1.PasswordChar == '*')
            {
                txtPwd1.PasswordChar = new char();
                txtPwd2.PasswordChar = new char();
            }
            else
            {
                txtPwd1.PasswordChar = '*';
                txtPwd2.PasswordChar = '*';
            }
        }
    }
}
