using AllInterfaceProj.ClientInterface;
using Client.Infrastructure;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using Prism.Regions;
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
        //IRegionManager _regionManager;
        //IUnityContainer _container;

        public Shell(IShellViewModel viewModel)
        {
            //_regionManager = regionManager;
            //_container = container;
            
            InitializeComponent();

            ViewModel = viewModel;
            //ShellViewModel viewModel = new ShellViewModel();
            DataContext = viewModel;

            InterfaceClass.ClientInterface.Star();
        }

        public IShellViewModel ViewModel
        {
            get { return (IShellViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
