using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AllInterfaceProj.ServerInterface
{
    public interface IGetData
    {
        /// <summary>
        /// 从服务端接收Mac地址
        /// </summary>
        /// <param name="userName">给定的UserName</param>
        /// <returns>返回值为String类型的Mac地址</returns>
        string ReceiveMacAddress(string userName);

        /// <summary>
        /// 从服务端接收（课表信息）
        /// </summary>
        /// <returns>返回课表信息类</returns>
        PictureInfo ReceivePictureFromServer(string userNickName, TimetableAndExpPic type);

        /// <summary>
        /// 从服务端接收今日是否已签到
        /// </summary>
        /// <returns>返回是否已签到</returns>
        bool ReceiveSignInfoFromServer(PersonInfo personInfo);

        /// <summary>
        /// 从服务端接收所有的签到信息
        /// </summary>
        /// <returns>返回签到信息的集合</returns>
        ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer(PersonInfo personInfo);

        /// <summary>
        /// 用于用户登录
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        bool SendPerosnInfoToServer(PersonInfo personInfo);
    }

}
