using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProj
{
    public class ShellViewModule : IModule
    {

        IRegionManager _regionManager;
        IUnityContainer _container;

        public ShellViewModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IShellViewModel, ShellViewModel>();
            _container.RegisterType<IShell, Shell>();

            _regionManager.RegisterViewWithRegion(RegionNames.ShellRegion, typeof(Shell));

        }
    }
}
