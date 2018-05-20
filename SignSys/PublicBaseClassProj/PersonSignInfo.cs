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
    public class PersonSignInfo
    {
        private string _userNickName;
        private DateTime? _signTime;

        private bool _isSign;
        [DataMember]
        public string UserNickName { get => _userNickName; set => _userNickName = value; }
        [DataMember]
        public DateTime? SignTime { get => _signTime; set => _signTime = value; }
        [DataMember]
        public bool IsSign { get => _isSign; set => _isSign = value; }
    }
}
