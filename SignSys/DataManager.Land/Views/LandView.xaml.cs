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
using DataManager.Land.ViewsModels;

namespace DataManager.Land.Views
{
    /// <summary>
    /// LandView.xaml 的交互逻辑
    /// </summary>
    public partial class LandView : UserControl, ILandView
    {
        public LandView(ILandViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public ILandViewModel ViewModel
        {
            get { return (ILandViewModel)DataContext; }
            set { DataContext = value; }
        }
        //private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.OnPasswordChanged(sender);
        //}

        private void PasswordBox_Loaded(object sender, RoutedEventArgs e)
        {
            var pwb = sender as PasswordBox;
            pwb.Clear();
        }
    }
}
