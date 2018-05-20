using AllInterfaceProj.ClientInterface;
using Client.Infrastructure;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace ClientProj
{
    /// <summary>
    /// Shell.xaml 的交互逻辑
    /// </summary>
    public partial class Shell : MetroWindow, IShell
    {
        IClientInterfaceProj clientInterfaceProj = null;

        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            clientInterfaceProj.Star();
        }

        public IShellViewModel ViewModel
        {
            get { return (IShellViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
