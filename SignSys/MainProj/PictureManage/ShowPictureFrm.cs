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
        private const double step = 0.1;
        //是否正在拖拽 
        bool isDrag = false;
        //鼠标按下坐标（control控件的相对坐标） 
        Point mouseDownPoint = Point.Empty;
        //将被拖动的控件 
        private Control control;

        public ShowPictureFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cboChooseType.Items.Add("课程表");
            cboChooseType.Items.Add("实验表");
            cboChooseType.SelectedIndex = 0;
            textBox1.Text = "请填写真实姓名";
            this.picTimeTable.MouseWheel += new MouseEventHandler(PicTimeTable_MouseWheel);
            this.picTimeTable.MouseMove += new MouseEventHandler(PicTimeTable_MouseMove);
            this.picTimeTable.MouseDown += new MouseEventHandler(PicTimeTable_MouseDown);
            this.picTimeTable.MouseUp += new MouseEventHandler(PicTimeTable_MouseUp);
        }

        private void PicTimeTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                isDrag = false;
            }
        }

        private void PicTimeTable_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            control = picTimeTable;
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = picTimeTable.Location;
            }
        }

        private void PicTimeTable_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                Point mousePos = new Point(control.Location.X, control.Location.Y);
                mousePos.Offset(e.X, e.Y);
                mousePos.X -= this.control.Width / 2;
                mousePos.Y -= this.control.Height / 2;
                control.Location = mousePos;
            }
        }


        private void PicTimeTable_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (picTimeTable.Width < 12000 && picTimeTable.Height < 7000)
                {
                    picTimeTable.Width = picTimeTable.Width + int.Parse(Math.Ceiling(picTimeTable.Width * step).ToString());
                    picTimeTable.Height = picTimeTable.Height + int.Parse(Math.Ceiling(picTimeTable.Height * step).ToString());
                    picTimeTable.Location = new Point((groupBox1.Width - picTimeTable.Width) / 2, (groupBox1.Height - picTimeTable.Height) / 2);
                }
            }
            else
            {
                if (picTimeTable.Width > 70 && picTimeTable.Height > 40)
                {
                    picTimeTable.Width = picTimeTable.Width - int.Parse(Math.Ceiling(picTimeTable.Width * step).ToString());
                    picTimeTable.Height = picTimeTable.Height - int.Parse(Math.Ceiling(picTimeTable.Height * step).ToString());
                    picTimeTable.Location = new Point((groupBox1.Width - picTimeTable.Width) / 2, (groupBox1.Height - picTimeTable.Height) / 2);
                }
            }
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
