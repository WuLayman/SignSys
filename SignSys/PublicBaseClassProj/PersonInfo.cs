using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    [DataContract]
    public class PersonInfo 
    {
        private string _userNickName;

        private string _userRealName;
        

        private string _passWord;
      

        private string _macAddress;
        [DataMember]
        public string UserNickName { get => _userNickName; set => _userNickName = value; }
        [DataMember]
        public string UserRealName { get => _userRealName; set => _userRealName = value; }
        [DataMember]
        public string PassWord { get => _passWord; set => _passWord = value; }
        [DataMember]
        public string MacAddress { get => _macAddress; set => _macAddress = value; }
    }
}
