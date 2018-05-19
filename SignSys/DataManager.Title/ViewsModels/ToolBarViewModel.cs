﻿using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.Infrastructure.PusSubEvents;
using Client.Infrastructure;
using System.Windows;
using System.Threading;
using Prism.Mvvm;
using PublicBaseClassProj;

namespace DataManager.Title.ViewsModels
{
    public class ToolBarViewModel : BindableBase, IToolbarViewModel
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private IEventAggregator _aggregator;


        private string _userName;
        private bool _isEnabled = true;
        public bool IsEnabled { get => _isEnabled; set { SetProperty(ref _isEnabled, value, nameof(IsEnabled)); } }

        public string UserName { get => _userName; set { SetProperty(ref _userName, value, nameof(UserName)); ReturnHomePageCommand.RaiseCanExecuteChanged(); ViewTimeTableCommand.RaiseCanExecuteChanged(); UploadTimeTableCommand.RaiseCanExecuteChanged(); HistorySignCommand.RaiseCanExecuteChanged(); LeaveCommand.RaiseCanExecuteChanged(); ModifyPasswordCommand.RaiseCanExecuteChanged(); SignCommand.RaiseCanExecuteChanged(); } }
        //public string UserName { get => _userName; set => SetProperty(ref _userName, value, nameof(UserName)); }


        #region Command
        public DelegateCommand ReturnHomePageCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ViewTimeTableCommand { get; set; }
        public DelegateCommand UploadTimeTableCommand { get; set; }
        public DelegateCommand HistorySignCommand { get; set; }
        public DelegateCommand LeaveCommand { get; set; }
        public DelegateCommand ModifyPasswordCommand { get; set; }
        public DelegateCommand SignCommand { get; set; }

        #endregion

        public ToolBarViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator aggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;

            ReturnHomePageCommand = new DelegateCommand(HomePage, NotLand);
            LogoutCommand = new DelegateCommand(Logout);
            ViewTimeTableCommand = new DelegateCommand(ViewTimeTable, NotLand);
            UploadTimeTableCommand = new DelegateCommand(UploadTimeTable, NotLand);
            HistorySignCommand = new DelegateCommand(HistorySign, NotLand);
            LeaveCommand = new DelegateCommand(Leave, NotLand);
            ModifyPasswordCommand = new DelegateCommand(ModifyPassword, NotLand);
            SignCommand = new DelegateCommand(Sign, CanNotSign);

            //UserName = StaticProperty.staticUserName;
            _aggregator.GetEvent<UserNameChangedEvent>().Subscribe(UserNameChange);
        }

        private void UserNameChange(string obj)
        {
            UserName = obj;
        }

        #region CommandMethod


        private bool NotLand()
        {

            if (UserName == null)
            {
                //Thread th = new Thread(() =>
                //{
                //    while (true)
                //    {
                //        if (UserName != null)
                //        {
                //            NotLand();
                //            //break;
                //        }
                //        UserName = StaticProperty.staticUserName;

                //    }
                //})
                //{
                //    IsBackground = true
                //};
                //th.Start();
                return false;

            }
            else
            {
                return true;
            }

        }
        private void Logout()
        {
            //退出登录
            UserName = null;
            InterfaceClass.ClientInterface.Leave();
            var uri = new Uri("Land", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void HomePage()
        {
            //返回首页
            var uri = new Uri("HomePage", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }

        private void ViewTimeTable()
        {
            //查看课表
            var uri = new Uri("DownLoadPicture", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void UploadTimeTable()
        {
            //上传课表
            var uri = new Uri("Picture", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void HistorySign()
        {
            //查看历史签到
            var uri = new Uri("History", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void Leave()
        {
            //请假
            var uri = new Uri("State", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void ModifyPassword()
        {
            //修改密码
            var uri = new Uri("ModifyPassword", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }
        private void Sign()
        {
            //签到
            PersonSignInfo personSignInfo = new PersonSignInfo
            {
                UserNickName = StaticProperty.staticUserName,
                SignTime = DateTime.Now,
                IsSign = true
            };

            if (InterfaceClass.ClientInterface.SendSignInfoToServer(personSignInfo))
            {
                MessageBox.Show("成功签到");
                _aggregator.GetEvent<TitleChangedEvent>().Publish("今日已成功签到");
                IsEnabled = false;
            }
            else
            {
                MessageBox.Show("未签到成功，请重新签到");
            }

        }
        private bool CanNotSign()
        {
            if (StaticProperty.staticUserName == null)
            {
                return false;
            }
            else
            {
                if (InterfaceClass.ClientInterface.ReceiveSignInfoFromServer())
                {
                    _aggregator.GetEvent<TitleChangedEvent>().Publish("今日已成功签到");
                    return false;
                }
                else
                {
                    _aggregator.GetEvent<TitleChangedEvent>().Publish("今日还没签到，请先签到");

                    return true;
                }
            }

        }

        #endregion
    }
}