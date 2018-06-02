using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AllInterface.AllInterfaceProj.PublicBaseInterface;
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

        #region Properties

        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _aggregator;

        bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnProperyChanged("IsBusy"); } }

        string _password;
        public string Password { get => _password; set { _password = value; EnterLoginCommand.RaiseCanExecuteChanged(); LoginCommand.RaiseCanExecuteChanged(); } }

        private string _userName;
        public string UserName
        {
            get => _userName;
            //set { SetProperty(ref _userName, value, nameof(UserName)); LoginCommand.RaiseCanExecuteChanged(); }
            set { _userName = value; OnProperyChanged("UserName"); LoginCommand.RaiseCanExecuteChanged(); }
        }
        #endregion

        #region DelegateCommand
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand<object> EnterLoginCommand { get; set; }

        #endregion

        public LandViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator aggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;

            LoginCommand = new DelegateCommand(Login, CanLogin);
            EnterLoginCommand = new DelegateCommand<object>((k) =>
            {
                var key = (Key)k;
                if (key == Key.Enter && CanLogin())
                {
                    Console.WriteLine("Enter Login");
                    Login();
                }
            }, (o) => true);
        }

        private bool CanLogin()
        {
            //var pwb = arg as PasswordBox;
            if (string.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            return true;
        }

        private void Login()
        {

            //var pwb = obj as PasswordBox;      
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
                        PassWord = Password
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
                    }
                }
                else
                {
                    Password = BCutEncrypt(Password);

                    PersonInfo person = new PersonInfo
                    {
                        UserNickName = UserName,
                        PassWord = Password,
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
                    }

                    //Thread th = new Thread(() =>
                    //{
                    //    while (true)
                    //    {
                    //        InterfaceClass.ClientInterface.Star();
                    //    }
                    //})
                    //{
                    //    IsBackground = true
                    //};
                    //th.Start();

                    #endregion
                }
            }
            catch
            {
                IsBusy = true;
                MessageBoxResult mor = MessageBox.Show("服务端连接失败，请重试");
                if (mor == MessageBoxResult.OK)
                {
                    StaticProperty.staticUserName = null;
                    _aggregator.GetEvent<UserNameChangedEvent>().Publish(StaticProperty.staticUserName);
                    IsBusy = false;
                }
            }
        }


        #region INavigationAware
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
        #endregion

        #region  Methods

        //public void OnPasswordChanged(object sender)
        //{
        //    LoginCommand.RaiseCanExecuteChanged();
        //}

        public string BCutEncrypt(string str)
        {
            try
            {
                char[] emblem = GetMacAddress().ToCharArray();
                StringBuilder buffer = new StringBuilder();
                char[] chars = str.ToCharArray();
                if (emblem.Length > chars.Length)
                {
                    for (int i = 0; i < chars.Length; i++)
                    {
                        char temp = (char)(chars[i] ^ emblem[i]);
                        buffer.Append(temp);
                        for (int j = i; j < emblem.Length; j++)
                        {
                            buffer.Append(emblem[j]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < emblem.Length; i++)
                    {
                        char temp = (char)(chars[i] ^ emblem[i]);
                        buffer.Append(temp);
                        for (int j = i; j < chars.Length; j++)
                        {
                            buffer.Append(chars[j]);
                        }
                    }
                }
                return buffer.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
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


        #endregion

    }
}
