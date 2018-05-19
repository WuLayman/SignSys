using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Client.Infrastructure;
using DataManager.ModifyPasswork.Views;
using I_communication_component.MyWcf;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using PublicBaseClassProj;

namespace DataManager.ModifyPasswork.ViewsModels
{
    public class ModifyPasswordViewModel : IModifyPasswordViewModel, INavigationAware
    {
        public IModifyPasswordView View { get; set; }


        private string _firstPassword;
        private string _SecondPassword;

        private IRegionManager _regionManager;
        private IUnityContainer _container;
        public DelegateCommand PasswordCommand { get; set; }
        public DelegateCommand ExitLogonCommand { get; set; }
        public string FirstPassword { get => _firstPassword; set => _firstPassword = value; }
        public string SecondPassword { get => _SecondPassword; set => _SecondPassword = value; }

        public ModifyPasswordViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
            PasswordCommand = new DelegateCommand(ModSucess, ModFail);
            ExitLogonCommand = new DelegateCommand(Logon);
        }

        private void Logon()
        {
            if (InterfaceClass.ClientInterface.ReceiveMacAddress(StaticProperty.staticUserName) == null)
            {
                //返回登录页面
                var uri = new Uri("Land", UriKind.Relative);
                _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
            }
            else
            {
                var uri = new Uri("HomePage", UriKind.Relative);
                _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
            }

        }

        private bool ModFail()
        {
            return true;
        }

        private void ModSucess()
        {
            if (!PasswordLimit(FirstPassword) && !PasswordLimit(SecondPassword))
            {
                MessageBox.Show("修改失败,密码应最少6位且其中含有字母");
                FirstPassword = null;
                SecondPassword = null;
            }
            else if (FirstPassword != SecondPassword)
            {
                MessageBox.Show("两次密码应保持一致");
                FirstPassword = null;
                SecondPassword = null;
            }

            else
            {
                #region  修改成功

                PersonInfo person = new PersonInfo
                {
                    UserNickName = StaticProperty.staticUserName,
                    PassWord = FirstPassword,
                    MacAddress = GetMacAddress()
                };

                if (InterfaceClass.ClientInterface.SendChangePersonInfoToDB(person))
                {

                    MessageBox.Show("修改成功");
                    FirstPassword = null;
                    SecondPassword = null;
                    //跳到HomePage

                    var uri = new Uri("HomePage", UriKind.Relative);
                    _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
                }
                else
                {
                    MessageBox.Show("修改失败，服务器未接到");
                    FirstPassword = null;
                    SecondPassword = null;
                }

                #endregion
            }
        }


        #region  INavigationAware

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// 对密码框进行限定
        /// </summary>
        public bool PasswordLimit(string password)
        {
            if (password == null)
            {
                return false;
            }
            if (password.Length < 6)
            {
                return false;
            }


            if (IsAllChar(password))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断字符串里是否有字母
        /// </summary>
        public bool IsAllChar(string text)
        {
            foreach (char tempchar in text.ToCharArray())
            {
                if (!char.IsLetter(tempchar))
                {
                    return true;
                }
            }
            return false;
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
