using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I_communication_component.MyWcf;

namespace I_communication_component
{
    public static class ReciveCache
    {
        private static PersonSignInfo[] allSignInfo = null;
        private static PictureInfo picture = null;
        private static bool ifSigned = false;
        private static ObservableCollection<PersonSignInfo> observableCollection = null;
        private static string mACaddress = null;
        public static PersonSignInfo[] AllSignInfo { get => allSignInfo; set => allSignInfo = value; }
        public static PictureInfo Picture { get => picture; set => picture = value; }
        public static bool IfSigned { get => ifSigned; set => ifSigned = value; }
        public static ObservableCollection<PersonSignInfo> ObservableCollection { get => observableCollection; set => observableCollection = value; }
        public static string MACaddress { get => mACaddress; set => mACaddress = value; }
    }
}
