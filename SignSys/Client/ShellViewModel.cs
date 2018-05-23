using Client.Infrastructure;
using ClientProj;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProj
{
    public class ShellViewModel : NotifyPropertyChangedBase, IShellViewModel
    {
        //IRegionManager _regionManager;
        //IUnityContainer _container;


        private bool _isBusy = false;

        public ShellViewModel()
        {
            //_container = container;
            //_regionManager = regionManager;

            InterfaceClass.ClientInterface.ClientDisconnection += new Action(ClientDisconnection);
            InterfaceClass.ClientInterface.ClientReconnection += new Action(ClientReconnection);
        }

        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnProperyChanged("IsBusy"); } }

        public void ClientDisconnection()
        {
            IsBusy = true;
            Console.WriteLine("IsBusy被设为true");
        }

        public void ClientReconnection()
        {
            IsBusy = false;
            Console.WriteLine("IsBusy被设为false");
        }

    }
}
