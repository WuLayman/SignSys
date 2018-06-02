using Client.Infrastructure;
using DataManager.ChangeBackgroundColor.Views;
using DataManager.ChangeBackgroundColor.ViewsModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ChangeBackgroundColor
{
    public class ChangedBackgroundColorViewModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ChangedBackgroundColorViewModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IChangedBackgroundColorViewModel, ChangeBackgroundColorViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, ChangeBackgroundColorView>("ChangeBackgroundColor", new ContainerControlledLifetimeManager());

            _container.RegisterTypeForNavigation<ChangeBackgroundColorView>();

            _regionManager.RegisterViewWithRegion(RegionNames.ChangeBackgroundColorRegion, typeof(ChangeBackgroundColorView));
        }
    }
}
