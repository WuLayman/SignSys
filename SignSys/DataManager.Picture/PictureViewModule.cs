using Client.Infrastructure;
using DataManager.Picture.ViewModels;
using DataManager.Picture.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Unity;

namespace DataManager.Picture
{
    public class PictureViewModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public PictureViewModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IUpLoadPictureViewModel, UpLoadPictureViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, PictureView>("Picture", new ContainerControlledLifetimeManager());

            _container.RegisterType<IDownLoadPictureViewModel, DownLoadPictureViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<object, DownLoadPictureView>("DownLoadPicture", new ContainerControlledLifetimeManager());


            _container.RegisterTypeForNavigation<PictureView>();
            _container.RegisterTypeForNavigation<DownLoadPictureView>();

            _regionManager.RegisterViewWithRegion(RegionNames.UpLoadPictureRegion, typeof(PictureView));
            _regionManager.RegisterViewWithRegion(RegionNames.DownLoadPictureRegion, typeof(DownLoadPictureView));
        }
    }
}
