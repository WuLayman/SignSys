using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInterfaceProj.ServerInterface
{
    public interface ISendDataToDB
    {
        /// <summary>
        /// 向数据库发送用户信息，
        /// 用于用户更改密码的新信息
        /// </summary>
        /// <param name="personInfo">用户信息(可以只包含真实姓名)</param>
        /// <returns>是否成功发送</returns>
        bool SendChangePersonInfoToDB(PersonInfo personInfo);

        /// <summary>
        /// 向数据库发送签到状态
        /// </summary>
        /// <param name="userNickName">用户名（昵称）</param>
        /// <param name="ifSigned">是否签到</param>
        /// <returns>是否成功发送</returns>
        bool SendSignInfoToDB(PersonSignInfo personSign);

        /// <summary>
        /// 发送图片信息到数据库
        /// </summary>
        /// <param name="picture">图片对象，内部封装用户名</param>
        /// <returns>是否成功发送</returns>
        bool SendPictureInfoToDB(PictureInfo picture);

        bool SendStateInfoDB(string userNickName, PersonStateInfo state, string message);
    }
}
