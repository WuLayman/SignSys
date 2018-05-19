using Client.Infrastructure;
using DataManager.HistorySign.ViewModels;
using DataManager.HistorySign.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.HistorySign
{
    public class HistorySignViewModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public HistorySignViewModule(IUnityContainer container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;
        }


        public void Initialize()
        {
            _container.RegisterType<IHistorySignViewModel, HistorySignViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, HistoryView>("History", new ContainerControlledLifetimeManager());

            _container.RegisterTypeForNavigation<HistoryView>();

            _regionManager.RegisterViewWithRegion(RegionNames.HistorySignRegion, typeof(HistoryView));

        }
    }
}
