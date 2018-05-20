using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DataManager.ModifyProfile.ViewModels
{
    public class ModifyProfileViewModel : NotifyPropertyChangedBase, IModifyProfileViewModel
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        private string _ip;
        private string _port;

        public DelegateCommand ChangedIpAndPortCommand;
        public DelegateCommand ReturnHomePageCommand;

        public ModifyProfileViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
            ChangedIpAndPortCommand = new DelegateCommand(ChangedIpAndPort);
            ReturnHomePageCommand = new DelegateCommand(ReturnHomePage);
        }

        private void ReturnHomePage()
        {
            var uri = new Uri("HomePage", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }

        private void ChangedIpAndPort()
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var serviceModel = config.SectionGroups["system.serviceModel"];
            //var str = config.FilePath;
            try
            {
                UpdateConfig(Ip, Port);
                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();
            }
            catch
            {
                MessageBox.Show("修改失败");
                Ip = null;
                Port = null;
            }


        }

        public string Ip { get => _ip; set { _ip = value; OnProperyChanged("Ip"); } }
        public string Port { get => _port; set { _port = value; OnProperyChanged("Port"); } }

        private void UpdateConfig(string serverIPAddress, string serverPort)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);  
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup sct = config.SectionGroups["system.serviceModel"];
            ServiceModelSectionGroup serviceModelSectionGroup = sct as ServiceModelSectionGroup;
            ClientSection clientSection = serviceModelSectionGroup.Client;

            foreach (ChannelEndpointElement item in clientSection.Endpoints)
            {
                string pattern = "://.*/";
                string address = item.Address.ToString();
                string replacement = string.Format("://{0}:{1}/", serverIPAddress, serverPort);
                address = Regex.Replace(address, pattern, replacement);
                item.Address = new Uri(address);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("system.serviceModel");
        }

    }
}
