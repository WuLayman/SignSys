using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using I_communication_component.MyWcf;

namespace I_communication_component
{
    /// <summary>
    /// 使用前
    /// </summary>
    public class ReceiveInfoFromServer
    {       
        /// <summary>
        /// 从服务端接收（课表信息）
        /// </summary>
        /// <returns>返回课表信息类</returns>
       public PictureInfo ReceivePictureFromServer()
        {
            PictureInfo pictureInfo = null;       
            if (ReciveCache.Picture!=null)
            {
                pictureInfo = ReciveCache.Picture;
                ReciveCache.Picture = null;
            }
            return pictureInfo;
        }

        /// <summary>
        /// 从服务端接收今日是否已签到
        /// </summary>
        /// <returns>返回是否已签到</returns>
       public bool ReceiveSignInfoFromServer()
        {
            bool ifsigned = false;
            if (ReciveCache.IfSigned!=false)
            {
                ifsigned = ReciveCache.IfSigned;
                ReciveCache.IfSigned = false;
            }
           return ifsigned;
        }

        /// <summary>
        /// 从服务端接收所有的签到信息
        /// </summary>
        /// <returns>返回签到信息的集合</returns>
       public  ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer()
        {
            ObservableCollection<PersonSignInfo> ob = null;
            if (ReciveCache.ObservableCollection!=null)
            {
                ob = ReciveCache.ObservableCollection;
                ReciveCache.ObservableCollection = null;
            }
            return ob;
        }
        /// <summary>
        /// 从服务端接收Mac地址
        /// </summary>
        /// <param name="userName">给定的UserName</param>
        /// <returns>返回值为String类型的Mac地址</returns>
       public string ReceiveMacAddress()
        {
            string macaddress = null;
            if (ReciveCache.MACaddress!=null)
            {
                macaddress = ReciveCache.MACaddress;
                ReciveCache.MACaddress = null;
            }
            return macaddress;
        }
    }
}



