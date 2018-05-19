using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class PersonSignInfo : NotifyPropertyChangedBase
    {
        private string _userNickName;
        private DateTime? _signTime;

        private bool _isSign;
        public bool IsSign { get => _isSign; set { _isSign = value; OnPropertyChanged("IsSign"); } }


        public string UserNickName { get => _userNickName; set { _userNickName = value; OnPropertyChanged("UserNickName"); } }
        public DateTime? SignTime { get => _signTime; set { _signTime = value; OnPropertyChanged("SignTime"); } }

    }
}
