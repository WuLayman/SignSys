using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DataManager.Title.Views
{
    /// <summary>
    /// Clock.xaml 的交互逻辑
    /// </summary>
    public partial class Clock : UserControl
    {

        DispatcherTimer dispatcherTimer;

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public readonly static DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(Clock), new UIPropertyMetadata(""));

        public Clock()
        {
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Render);
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
            dispatcherTimer.Start();

        }


        /// <summary>
        /// 时钟响应函数
        /// </summary>
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.tb_Time.Text = dt.ToString("HH:mm:ss");
        }
    }
}
