using AllInterface.AllInterfaceProj.PublicBaseInterface;
using Client.Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
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
    public class UpLoadPictureViewModel : NotifyPropertyChangedBase, IUpLoadPictureViewModel, INavigationAware
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public IEnumerable<TimetableAndExpPic> BingingTTAndEP
        {
            get { return Enum.GetValues(typeof(TimetableAndExpPic)).Cast<TimetableAndExpPic>(); }
        }

        public DelegateCommand<object> ImportCommand { get; set; }
        public DelegateCommand<object> UpLoadPictureCommand { get; set; }
        public DelegateCommand ReturnHomePageCommand { get; set; }

        ISendInfoToServer sendInfoToServer = null;

        public UpLoadPictureViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;
            ImportCommand = new DelegateCommand<object>(Import);
            UpLoadPictureCommand = new DelegateCommand<object>(UpLoadPicture);
            ReturnHomePageCommand = new DelegateCommand(ReturnHomePage);
        }

        private void ReturnHomePage()
        {
            //首页
            var uri = new Uri("HomePage", UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.LandRegion, uri);
        }


        PictureInfo pictureInfo = new PictureInfo();
        private void UpLoadPicture(object obj)
        {
            //上传图片
            var cmbBox = obj as ComboBox;
            //Console.WriteLine(cmbBox.Text); 
            TimetableAndExpPic e = (TimetableAndExpPic)Enum.Parse(typeof(TimetableAndExpPic), cmbBox.Text);

            pictureInfo.UserNickName = StaticProperty.staticUserName;
            pictureInfo.TtAndEP = e;

            if (sendInfoToServer.SendPictureInfoToServer(pictureInfo))
            {
                MessageBox.Show("上传成功");
            }
            else
            {
                MessageBox.Show("上传失败，请重新上传");
            }

        }

        private void Import(object obj)
        {
            //导入图片
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "图片|*.jpg;*.png",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] _imageBinary = br.ReadBytes((int)fs.Length);
                //通信传递
                pictureInfo.Picture = _imageBinary;
                //this._imgLocalPath = dialog.FileName;
                br.Close();
                fs.Close();
                var image = obj as Image;
                image.Source = ByteArrayToBitmapImage(_imageBinary);

            }
        }

        public void OnImageChanged(object sender)
        {
            ImportCommand.RaiseCanExecuteChanged();
        }

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

        public void OnComboBoxChanged(object sender)
        {
            UpLoadPictureCommand.RaiseCanExecuteChanged();
        }
    }
}
