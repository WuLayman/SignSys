using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.Infrastructure;
using DataManager.Land.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PublicBaseClassProj;
using static Client.Infrastructure.PusSubEvents;

namespace DataManager.Land.ViewsModels
{
    public class LandViewModel : NotifyPropertyChangedBase, ILandViewModel, INavigationAware
    {

        public ILandView View { get; set; }

        bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }

        public DelegateCommand<object> LoginCommand { get; set; }
        public DelegateCommand<object> EnterLoginCommand { get; set; }

        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _aggregator;


        public LandViewModel(LandView view)
        {
            this.View = view;
            this.View.ViewModel = this;
        }

        public LandViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator aggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;

            LoginCommand = new DelegateCommand<object>(Login, CanLogin);
            EnterLoginCommand = new DelegateCommand<object>((k) =>
            {
                var key = (Key)k;
                if (key == Key.Enter)
                {
                    Console.WriteLine("Enter Login");

                }
            }, (o) => true);
        }

        private bool CanLogin(object arg)
        {
            var pwb = arg as PasswordBox;
            if (string.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(pwb?.Password))
            {
                return false;
            }
            return true;
        }

        private void Login(object obj)
        {

            var pwb = obj as PasswordBox;

            //var uri = new Uri("ModifyPassword", UriKind.Relative);
            //_regionManager.RequestNavigate(RegionNames.LandRegion, uri);
            //StaticProperty.staticUserName = UserName;
            //_aggregator.GetEvent<UserNameChangedEvent>().Publish(StaticProperty.staticUserName);
            try
            {

                #region 登录成功
                //将用户名给成静态属性
                StaticProperty.staticUserName = UserName;
                _aggregator.GetEvent<UserNameChangedEvent>().Publish(StaticProperty.staticUserName);
                InterfaceClass.ClientInterface.Star();

                string macAddress = InterfaceClass.ClientInterface.ReceiveMacAddress(UserName);

                if (macAddress == null)
                {
                    PersonInfo person = new PersonInfo
                    {
                        UserNickName = UserName,
                        PassWord = pwb.Password
                    };
                    if (InterfaceClass.ClientInterface.SendPerosnInfoToServer(person))
                    {
                        MessageBox.Show("登录成功");
                        //TODO:跳到修改密码界面
                        var uri = new Uri("ModifyPassword", UriKind.Relative);
                        _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
                    }
                    else
                    {
                        MessageBox.Show("登录失败，请检查再重新登录");
                        pwb.Password = null;
                    }
                }
                else
                {
                    PersonInfo person = new PersonInfo
                    {
                        UserNickName = UserName,
                        PassWord = pwb.Password,
                        MacAddress = GetMacAddress()
                    };
                    if (InterfaceClass.ClientInterface.SendPerosnInfoToServer(person))
                    {
                        //跳到HomePageView
                        MessageBox.Show("登录成功");
                        var uri = new Uri("HomePage", UriKind.Relative);
                        _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
                    }
                    else
                    {
                        MessageBox.Show("登录失败，请检查再重新登录");
                        pwb.Password = null;
                    }

                }
                #endregion
            }

            catch
            {
                IsBusy = true;
                MessageBoxResult mor = MessageBox.Show("服务端连接失败，请重试");
                if (mor == MessageBoxResult.OK)
                {
                    IsBusy = false;
                    pwb.Password = null;
                }
            }
        }



        public string GetMacAddress()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "unknown";
            }
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnPasswordChanged(object sender)
        {
            LoginCommand.RaiseCanExecuteChanged();
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            //set { SetProperty(ref _userName, value, nameof(UserName)); LoginCommand.RaiseCanExecuteChanged(); }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }




        #region  Methods

        #endregion

    }
}
