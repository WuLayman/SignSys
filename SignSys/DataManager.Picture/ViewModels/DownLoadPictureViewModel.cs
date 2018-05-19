using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DataManager.Picture.ViewModels
{
    public class DownLoadPictureViewModel : NotifyPropertyChangedBase, IDownLoadPictureViewModel, INavigationAware
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public IEnumerable<TimetableAndExpPic> BingingTTAndEP
        {
            get { return Enum.GetValues(typeof(TimetableAndExpPic)).Cast<TimetableAndExpPic>(); }
        }

        TimetableAndExpPic _selectedTTAndEP;
        public TimetableAndExpPic SelectedTTAndEP { get => _selectedTTAndEP; set { _selectedTTAndEP = value; OnPropertyChanged("SelectedTTAndEP"); } }

        public DelegateCommand<object> DownPictureCommand { get; set; }
        public DelegateCommand ReturnHomePageCommand { get; set; }

        public DownLoadPictureViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;


            DownPictureCommand = new DelegateCommand<object>(DownPicture);
            ReturnHomePageCommand = new DelegateCommand(ReturnHomePage);

        }

        private void ReturnHomePage()
        {
            //返回首页
            var uri = new Uri("HomePage", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }

        private void DownPicture(object obj)
        {
            //查看课表
            var image = obj as Image;

            PictureInfo pictureInfo = InterfaceClass.ClientInterface.ReceivePictureFromServer(StaticProperty.staticUserName, SelectedTTAndEP);
            if (pictureInfo == null)
            {
                MessageBox.Show("查看失败");
            }
            else
            {
                image.Source = ByteArrayToBitmapImage(pictureInfo.Picture);
            }
        }


        /// <summary>
        /// 将二进制转换为BitmapImage对象
        /// </summary>
        BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage bmp = null;

            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
            }
            catch
            {
                bmp = null;
            }

            return bmp;
        }

        public void OnImageChanged(object sender)
        {
            DownPictureCommand.RaiseCanExecuteChanged();
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
    }
}
