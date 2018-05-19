using DataManager.Picture.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Picture.Views
{
    public interface IDownLoadPictureView
    {
        IDownLoadPictureViewModel ViewModel { get; set; }
    }
}
