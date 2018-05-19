using Client.Infrastructure;
using DataManager.Land.Views;
using DataManager.Land.ViewsModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Land
{
    public class LandViewModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;


        public LandViewModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            _container.RegisterType<ILandViewModel, LandViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, LandView>("Land", new ContainerControlledLifetimeManager());

            _container.RegisterTypeForNavigation<LandView>();

            _regionManager.RegisterViewWithRegion(RegionNames.LandRegion, typeof(LandView));
        }
    }
}
