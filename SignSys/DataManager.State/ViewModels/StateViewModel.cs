using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataManager.State.ViewModels
{
    public class StateViewModel : NotifyPropertyChangedBase, IStateViewModel
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        string _leaveReson;
        public string LeaveReson { get => _leaveReson; set { _leaveReson = value; OnPropertyChanged("LeaveReson"); } }

        public DelegateCommand<object> SaveCommand { get; set; }
        public DelegateCommand ReturnHomePageCommand { get; set; }

        public StateViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            SaveCommand = new DelegateCommand<object>(Save);
            ReturnHomePageCommand = new DelegateCommand(ReturnHomePage);
        }

        private void ReturnHomePage()
        {
            //返回首页
            var uri = new Uri("HomePage", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }

        private void Save(object obj)
        {
            //保存请假原因
            var comboBox = obj as ComboBox;
            string str = comboBox.Text;

            bool b = InterfaceClass.ClientInterface.SendStateInfoDB(StaticProperty.staticUserName, (PersonStateInfo)Enum.Parse(typeof(PersonStateInfo), str), LeaveReson);
            if (b)
            {
                MessageBox.Show("上传成功");
                //返回首页
                var uri = new Uri("HomePage", UriKind.Relative);
                _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
            }
            else
            {
                MessageBox.Show("上传失败，请重新上传");
            }

        }

        public void OnComboBoxChanged(object sender)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
}
