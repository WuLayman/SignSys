using DataManager.Picture.ViewModels;
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

namespace DataManager.Picture.Views
{
    /// <summary>
    /// PictureView.xaml 的交互逻辑
    /// </summary>
    public partial class PictureView : UserControl, IUpLoadPictureView
    {
        public PictureView(IUpLoadPictureViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IUpLoadPictureViewModel ViewModel
        {
            get { return (IUpLoadPictureViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
