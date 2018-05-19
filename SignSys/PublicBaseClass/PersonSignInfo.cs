using PublicBaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicBaseClassProj
{
    public class PersonSignInfo : NotifyProperyChangedBase
    {
        private string _userNickName;
        private DateTime? _signTime;

        private bool _isSign;
        public bool IsSign { get => _isSign; set { _isSign = value; OnProperyChanged("IsSign"); } }


        public string UserNickName { get => _userNickName; set { _userNickName = value; OnProperyChanged("UserNickName"); } }
        public DateTime? SignTime { get => _signTime; set { _signTime = value; OnProperyChanged("SignTime"); } }

    }
}
