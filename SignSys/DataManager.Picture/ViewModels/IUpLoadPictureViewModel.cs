using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Picture.ViewModels
{
    public interface IUpLoadPictureViewModel
    {
        void OnImageChanged(object sender);
        void OnComboBoxChanged(object sender);

    }
}
