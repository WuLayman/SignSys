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
using DataManager.HistorySign.ViewModels;

namespace DataManager.HistorySign.Views
{
    /// <summary>
    /// HistoryView.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryView : UserControl, IHistoryView
    {
        public HistoryView(IHistorySignViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IHistorySignViewModel ViewModel
        {
            get { return (IHistorySignViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
