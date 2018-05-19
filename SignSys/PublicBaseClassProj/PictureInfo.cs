using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    [DataContract]
    public class PictureInfo : NotifyPropertyChangedBase
    {
        private string _userNickName;
        private byte[] _picture;
         


        private TimetableAndExpPic _ttAndEP;
        [DataMember]
        public TimetableAndExpPic TtAndEP { get => _ttAndEP; set { _ttAndEP = value; OnPropertyChanged("TtAndEP"); } }
        [DataMember]
        public string UserNickName { get => _userNickName; set { _userNickName = value; OnPropertyChanged("UserNickName"); } }
        [DataMember]
        public byte[] Picture { get => _picture; set { _picture = value; OnPropertyChanged("Picture"); } }

    }
}
