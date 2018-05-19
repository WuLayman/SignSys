using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInterface.AllInterfaceProj.PublicBaseInterface
{
    /// <summary>
    /// 客户端向服务端发送信息的接口
    /// </summary>
    public interface ISendInfoToServer
    {
        /// <summary>
        /// 向服务端发送用户信息函数
        /// </summary>
        /// <param name="personInfo">用户信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        bool SendPerosnInfoToServer(PersonInfo personInfo);

        /// <summary>
        /// 修改密码
        /// </summary>
        bool SendPasswordToServer(PersonInfo personInfo);

        /// <summary>
        /// 向服务端发送用户课表函数
        /// </summary>
        /// <param name="pictureInfo">课表信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        bool SendPictureInfoToServer(PictureInfo pictureInfo);

        /// <summary>
        /// 向服务端发送签到信息
        /// </summary>
        /// <param name="signInfo">签到信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        bool SendSignInfoToServer(PersonSignInfo signInfo);

        /// <summary>
        /// 向服务端发送用户状态信息
        /// </summary>
        /// <param name="stateInfo">用户状态信息类</param>
        /// <returns>返回的bool判断是否发送成功</returns>
        bool SendStateInfoToServer(string userNickName, PersonStateInfo stateInfo, string leaveReson);


    }
}
