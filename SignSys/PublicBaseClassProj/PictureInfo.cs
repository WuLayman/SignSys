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
    public class PictureInfo 
    {
        private string _userNickName;
        private byte[] _picture;
        
        private TimetableAndExpPic _ttAndEP;
        [DataMember]
        public string UserNickName { get => _userNickName; set => _userNickName = value; }
        [DataMember]
        public byte[] Picture { get => _picture; set => _picture = value; }
        [DataMember]
        public TimetableAndExpPic TtAndEP { get => _ttAndEP; set => _ttAndEP = value; }
    }
}
