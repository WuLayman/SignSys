using AllInterface.AllInterfaceProj.PublicBaseInterface;
using AllInterfaceProj.ClientInterface;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSocket.CommunicateManager.Agreement
{
    //客户端对服务端所有的操作在service里定义，包括请求数据和发送数据。
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICallBackServices))]
    public interface IService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UID"></param>
        [OperationContract(IsOneWay = true)]
        void Login(PersonInfo personInfo);
        /// <summary>
        /// 心跳检测
        /// </summary>
        /// <param name="UID"></param>
        [OperationContract(IsOneWay = true)]
        void Update(PersonInfo personInfo);
        /// <summary>
        /// 离线
        /// </summary>
        /// <param name="UID"></param>
        [OperationContract(IsOneWay = true)]
        void Leave(PersonInfo personInfo);
        /// <summary>
        /// 向服务端发送用户信息函数
        /// </summary>
        /// <param name="personInfo">用户信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        [OperationContract(IsOneWay = false)]
        bool SendPerosnInfoToServer(PersonInfo personInfo);

        /// <summary>
        /// 向服务端发送用户课表函数
        /// </summary>
        /// <param name="pictureInfo">课表信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        [OperationContract(IsOneWay = false)]
        bool SendPictureInfoToServer(PictureInfo pictureInfo);
        /// <summary>
        /// 向服务端发送更改密码要求
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        bool SendPasswordToServer(PersonInfo personInfo);
        /// <summary>
        /// 向服务端发送签到信息
        /// </summary>
        /// <param name="signInfo">签到信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        [OperationContract(IsOneWay = false)]
        bool SendSignInfoToServer(PersonSignInfo signInfo);

        /// <summary>
        /// 向服务端发送用户状态信息
        /// </summary>
        /// <param name="stateInfo">用户状态信息类</param>
        /// <returns>返回的bool判断是否发送成功</returns>
        [OperationContract(IsOneWay = false)]
        bool SendStateInfoToServer(string userNickName, PersonStateInfo state, string message);
        /// <summary>
        /// 发送全部签到信息至客户端
        /// </summary>
        /// <param name="allSignInfo"></param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        bool SendAllSignInfoToClient(ObservableCollection<PersonSignInfo> allSignInfo);
        /// <summary>
        /// 从服务端获得Mac地址
        /// </summary>
        /// <param name="userName">给定的UserName</param>
        /// <returns>返回值为String类型的Mac地址</returns>
        [OperationContract(IsOneWay = false)]
        string ReceiveMacAddress(string userName);
        /// <summary>
        /// 从服务端接收（课表信息）
        /// </summary>
        /// <returns>返回课表信息类</returns>
        [OperationContract(IsOneWay = false)]
        PictureInfo ReceivePictureFromServer(string userName, TimetableAndExpPic ttAndEP);
        /// <summary>
        /// 从服务端接收今日是否已签到
        /// </summary>
        /// <returns>返回是否已签到</returns>
        [OperationContract(IsOneWay = false)]
        bool ReceiveSignInfoFromServer();
        /// <summary>
        /// 从服务端接收所有的签到信息
        /// </summary>
        /// <returns>返回签到信息的集合</returns>
        [OperationContract(IsOneWay = false)]
        ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer();
    }
    /// <summary>
    /// 服务端对客户端的要求在ICallBackServices里定义
    /// </summary>
    public interface ICallBackServices
    {
        /// <summary>
        /// 心跳检测使用
        /// </summary>
        /// <param name="msg"></param>
        [OperationContract(IsOneWay = false)]
        void ShowMessage(string msg);
    }
}
