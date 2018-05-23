using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProj
{
    public class PersonIPEndPoint
    {
        private string userRealName;
        private string userIP;
        private int userPoint;

        public string UserRealName { get => userRealName; set => userRealName = value; }
        public string UserIP { get => userIP; set => userIP = value; }
        public int UserPoint { get => userPoint; set => userPoint = value; }
    }
}
