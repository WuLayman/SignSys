using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.Infrastructure.PusSubEvents;

namespace DataManager.Title.ViewsModels
{
    public class HomePageViewModel : BindableBase, IHomePageViewModel
    {
        private string _title = "今日还没签到，请先签到";

        public string Title { get => _title; set => SetProperty(ref _title, value, nameof(Title)); }


        private IEventAggregator _aggregator;
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public HomePageViewModel(IEventAggregator aggregator, IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _aggregator = aggregator;
            _regionManager = regionManager;

            _aggregator.GetEvent<TitleChangedEvent>().Subscribe(TitleChange);
            

        }

        private void TitleChange(string newTitle)
        {
            Title = newTitle;
        }
    }
}
