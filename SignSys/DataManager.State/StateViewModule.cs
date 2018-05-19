using Client.Infrastructure;
using DataManager.State.ViewModels;
using DataManager.State.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.State
{
    public class StateViewModule : IModule
    {

        IUnityContainer _container;
        IRegionManager _regionManager;

        public StateViewModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IStateViewModel, StateViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, StateView>("State", new ContainerControlledLifetimeManager());

            _regionManager.RegisterViewWithRegion(RegionNames.StateRegion, typeof(StateView));

            _container.RegisterTypeForNavigation<StateView>();
        }
    }
}
