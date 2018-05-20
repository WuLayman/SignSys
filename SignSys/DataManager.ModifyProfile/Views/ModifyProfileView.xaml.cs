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
using DataManager.ModifyProfile.ViewModels;

namespace DataManager.ModifyProfile.Views
{
    /// <summary>
    /// ModifyProfileView.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyProfileView : UserControl, IModifyProfileView
    {
        public ModifyProfileView(IModifyProfileViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IModifyProfileViewModel ViewModel
        {
            get { return (IModifyProfileViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
