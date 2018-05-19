using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class PictureInfo : NotifyPropertyChangedBase
    {
        private string _userNickName;
        private byte[] _picture;
        
        private TimetableAndExpPic _ttAndEP;

        public TimetableAndExpPic TtAndEP { get => _ttAndEP; set { _ttAndEP = value; OnPropertyChanged("TtAndEP"); } }

        public string UserNickName { get => _userNickName; set { _userNickName = value; OnPropertyChanged("UserNickName"); } }
        public byte[] Picture { get => _picture; set { _picture = value; OnPropertyChanged("Picture"); } }

    }
}
