using Client.Infrastructure;
using DataManager.ModifyProfile.ViewModels;
using DataManager.ModifyProfile.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyProfile
{
    public class ModifyProfileModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public void Initialize()
        {
            _container.RegisterType<IModifyProfileViewModel, ModifyProfileViewModel>(new ContainerControlledLifetimeManager());

            _container.RegisterType<object, ModifyProfileView>("ModifyProfile", new ContainerControlledLifetimeManager());

            _container.RegisterTypeForNavigation<ModifyProfileView>();
            _regionManager.RegisterViewWithRegion(RegionNames.ModifyProfileRegion, typeof(ModifyProfileView));

        }

        public ModifyProfileModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }
    }
}
