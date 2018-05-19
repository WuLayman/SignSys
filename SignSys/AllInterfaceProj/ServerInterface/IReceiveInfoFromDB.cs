using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInterfaceProj.ServerInterface
{
    /// <summary>
    /// 服务端从数据库接收数据接口
    /// </summary>
    public interface IReceiveInfoFromDB
    {
        /// <summary>
        /// 从数据库接收课表
        /// </summary>
        /// <param name="userNickName">用户名真实姓名</param>
        /// <returns></returns>
        List<PictureInfo> ReveicePicture(string userRealName, string type);

        /// <summary>
        /// 接收所有人签到信息
        /// </summary>
        /// <returns></returns>
        List<PersonSignInfo> ReceiveAllSignInfo();

        /// <summary>
        /// 接收所有人当天签到信息
        /// </summary>
        /// <returns></returns>
        List<PersonSignInfo> ReceiveTodaySignInfo();

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="managerName">管理员ID</param>
        /// <param name="Password">管理员密码</param>
        /// <returns></returns>
        bool JudgeIfManagerExist(Manager manager);

        /// <summary>
        /// 从数据库调取全部用户信息，
        /// 用于服务端界面显示
        /// </summary>
        /// <returns></returns>
        List<PersonInfo> ReveiveAllUserInfo();

        /// <summary>
        /// 用于从数据库查找真实姓名
        /// </summary>
        /// <param name="nickName"></param>
        /// <returns></returns>
        List<string> ReceiveRealName(List<string> nickName);
        
        /// <summary>
        /// 用于从数据库查找请假信息
        /// </summary>
        /// <returns></returns>
        List<LeaveMessage> ReceiveLeaveMsg();
    }
}
