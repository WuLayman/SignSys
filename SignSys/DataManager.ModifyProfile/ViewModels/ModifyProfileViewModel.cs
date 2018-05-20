using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyProfile.ViewModels
{
    public class ModifyProfileViewModel : IModifyProfileViewModel
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        private string _ip;
        private string _port;

        public ModifyProfileViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public string Ip { get => _ip; set => _ip = value; }
        public string Port { get => _port; set => _port = value; }
    }
}
