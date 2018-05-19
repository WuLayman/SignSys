using PublicBaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    public class PersonInfo : NotifyProperyChangedBase
    {
        private string _userNickName;
        public string UserNickName { get => _userNickName; set { _userNickName = value; OnProperyChanged("UserNickName"); } }

        private string _userRealName;
        public string UserRealName { get => _userRealName; set { _userRealName = value; OnProperyChanged("UserRealName"); } }

        private string _passWord;
        public string PassWord { get => _passWord; set { _passWord = value; OnProperyChanged("PassWork"); } }

        private string _macAddress;
        public string MacAddress { get => _macAddress; set { _macAddress = value; OnProperyChanged("MacAddress"); } }

    }
}
