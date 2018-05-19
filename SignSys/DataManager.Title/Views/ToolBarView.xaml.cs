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
using DataManager.Title.ViewsModels;

namespace DataManager.Title.Views
{
    /// <summary>
    /// ToolBarView.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarView : UserControl, IToolBarView
    {
        public ToolBarView(IToolbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IToolbarViewModel ViewModel
        {
            get { return (IToolbarViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
