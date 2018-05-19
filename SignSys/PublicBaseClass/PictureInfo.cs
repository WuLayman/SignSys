using PublicBaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    public class PictureInfo : NotifyProperyChangedBase
    {
        private string _userNickName;
        private byte[] _picture;

        private TimetableAndExpPic _ttAndEP;

        public TimetableAndExpPic TtAndEP { get => _ttAndEP; set { _ttAndEP = value; OnProperyChanged("TtAndEP"); } }

        public string UserNickName { get => _userNickName; set { _userNickName = value; OnProperyChanged("UserNickName"); } }
        public byte[] Picture { get => _picture; set { _picture = value; OnProperyChanged("Picture"); } }

    }
}
