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
using DataManager.ModifyPasswork.ViewsModels;
using Prism.Events;
using static Client.Infrastructure.PusSubEvents;

namespace DataManager.ModifyPasswork.Views
{
    /// <summary>
    /// ModifyPasswordView.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPasswordView : UserControl, IModifyPasswordView
    {

        private IEventAggregator _aggregator;

        public ModifyPasswordView(IModifyPasswordViewModel viewModel, IEventAggregator aggregator)
        {
            _aggregator = aggregator;

            InitializeComponent();
            ViewModel = viewModel;

            this.Loaded += ModifyPasswordView_Loaded;

        }


        private void ModifyPasswordView_Loaded(object sender, RoutedEventArgs e)
        {
            _aggregator.GetEvent<ModifyPasswordLoadedEvent>().Publish();
        }

        public IModifyPasswordViewModel ViewModel
        {
            get { return (IModifyPasswordViewModel)DataContext; }
            set { DataContext = value; }
        }

    }
}
