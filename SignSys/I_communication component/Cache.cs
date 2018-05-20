using I_communication_component.mywcf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_communication_component
{
   public static class Cache
    {
        private static PictureInfo pictureInfo = null;
        private static ObservableCollection<PersonSignInfo> observableCollection = null;
        private static bool ifSigned = false;
        public static PictureInfo PictureInfo { get => pictureInfo; set => pictureInfo = value; }
        public static ObservableCollection<PersonSignInfo> ObservableCollection { get => observableCollection; set => observableCollection = value; }
        public static bool IfSigned { get => ifSigned; set => ifSigned = value; }
    }
}
