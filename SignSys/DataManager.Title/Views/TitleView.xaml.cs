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
using Client.Infrastructure;
using DataManager.Title.ViewsModels;

namespace DataManager.Title.Views
{
    /// <summary>
    /// TitleView.xaml 的交互逻辑
    /// </summary>
    public partial class TitleView : UserControl, ITitleView
    {
        public TitleView(ITitleViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public ITitleViewModel ViewModel
        {
            get { return (ITitleViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
