using SeverToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj.PictureManage
{
    public partial class ShowPictureFrm : Form
    {
        public ShowPictureFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.MaximizeBox = false;
            cboChooseType.Items.Add("课程表");
            cboChooseType.Items.Add("实验表");
            cboChooseType.SelectedIndex = 0;
            textBox1.Text = "请填写真实姓名";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            var RealName = textBox1.Text;
            var type = "";
            if (cboChooseType.SelectedItem.ToString() == "实验表")
            {
                type = "experiment";
            }
            if (cboChooseType.SelectedItem.ToString() == "课程表")
            {
                type = "course";
            }
            RecvDataFromDBHelper recvDataFromDBHelper = new RecvDataFromDBHelper();
            var pictures = recvDataFromDBHelper.ReveicePicture(RealName, type);
            if (pictures == null)
            {
                MessageBox.Show("未找到信息表！");
                return;
            }
            if (pictures.Count == 1)
            {
                //将图片显示
                var picture = pictures.First().Picture;
                //将字节数组转换为图片并加以显示
                MemoryStream ms = new MemoryStream(picture);
                Image image = Image.FromStream(ms);
                picTimeTable.Image = image;
            }
        }

        private bool CheckInput()
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名！");
                return false;
            }
            return true;
        }

        private void ShowPictureFrm_Load(object sender, EventArgs e)
        {
            Size newSize = new Size(660, 415);
            this.MinimumSize = newSize;
        }

        bool b = true;
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (b)
            {
                textBox1.ResetText();
                b = false;
            }
        }
    }
}
