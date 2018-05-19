using Client.Infrastructure;
using DataManager.ModifyPasswork.Views;
using DataManager.ModifyPasswork.ViewsModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyPasswork
{
    public class ModifyPasswordViewModule : IModule
    {

        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModifyPasswordViewModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<object, ModifyPasswordView>("ModifyPassword", new ContainerControlledLifetimeManager());
            _container.RegisterType<IModifyPasswordViewModel, ModifyPasswordViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterTypeForNavigation<ModifyPasswordView>();
            _regionManager.RegisterViewWithRegion(RegionNames.ModifyPasswordRegion, typeof(ModifyPasswordView));
        }
    }
}
