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
    public class ShellViewModel : IShellViewModel
    {
        //IRegionManager _regionManager;
        //IUnityContainer _container;


        private bool _isBusy;

        public bool IsBusy { get => _isBusy; set => _isBusy = value; }

        public void ClientDisconnection()
        {
            IsBusy = false;
        }

        public void ClientReconnection()
        {
            IsBusy = true;
        }

    }
}
