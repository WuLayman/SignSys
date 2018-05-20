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
using DataManager.Picture.ViewModels;

namespace DataManager.Picture.Views
{
    /// <summary>
    /// DownLoadPictureView.xaml 的交互逻辑
    /// </summary>
    public partial class DownLoadPictureView : UserControl, IDownLoadPictureView
    {
        public DownLoadPictureView(IDownLoadPictureViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IDownLoadPictureViewModel ViewModel
        {
            get { return (IDownLoadPictureViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
