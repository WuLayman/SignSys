using Client.Infrastructure;
using DataManager.Title.Views;
using DataManager.Title.ViewsModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title
{
    public class TitleModule : IModule
    {

        IRegionManager _regionManager;
        IUnityContainer _container;

        public TitleModule(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

            _container.RegisterType<ITitleViewModel, TitleViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, TitleView>("Title", new ContainerControlledLifetimeManager());


            _container.RegisterType<IHomePageViewModel, HomePageViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, HomePageView>("HomePage", new ContainerControlledLifetimeManager());

            //先生成HomePageViewModel
            _container.Resolve<IHomePageViewModel>();

            _container.RegisterType<IToolbarViewModel, ToolBarViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, ToolBarView>("ToolBar", new ContainerControlledLifetimeManager());

            
            _container.RegisterTypeForNavigation<TitleView>();
            _container.RegisterTypeForNavigation<HomePageView>();
            _container.RegisterTypeForNavigation<ToolBarView>();


            _regionManager.RegisterViewWithRegion(RegionNames.TitleRegion, typeof(TitleView));
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolBarView));
            _regionManager.RegisterViewWithRegion(RegionNames.HomePageRegion, typeof(HomePageView));
        }
    }
}
