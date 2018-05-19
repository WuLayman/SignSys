using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSocket.CommunicateManager
{
    public class Cache
    {
        private  PersonInfo personInfo = null;
        private  PersonStateInfo stateInfo = PersonStateInfo.请假;
        private  PictureInfo pictureInfo = null;
        private PersonSignInfo signInfo = null;
        private  ObservableCollection<PersonSignInfo> observableCollection = null;
        private string leaveReson = null;
        public PersonInfo PersonInfo { get => personInfo; set => personInfo = value; }
        public PictureInfo PictureInfo { get => pictureInfo; set => pictureInfo = value; }
        public PersonSignInfo SignInfo { get => signInfo; set => signInfo = value; }
        public PersonStateInfo StateInfo { get => stateInfo; set => stateInfo = value; }
        public ObservableCollection<PersonSignInfo> ObservableCollection { get => observableCollection; set => observableCollection = value; }
        public string LeaveReson { get => leaveReson; set => leaveReson = value; }
    }
}
