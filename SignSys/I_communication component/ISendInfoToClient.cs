using AllInterface.AllInterfaceProj.PublicBaseInterface;
using AllInterfaceProj.ClientInterface;
using I_communication_component.MyWcf;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I_communication_component
{
    public class ClientOperation : IClientInterfaceProj, IReceiveInfoFromServer, ISendInfoToServer
    {
        MyWcf.ServiceClient client = null;
        CallBack back = null;
        PersonInfo personInfo = null;
        Task task = null;
        static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        public event Action ClientReconnection;
        public event Action ClientDisconnection;
        //断线提醒事件定义
        #region
        protected virtual void clientdisconnection()
        {
            ClientDisconnection?.Invoke(); /* 事件被触发 */
        }
        public void SetBreaken()
        {
            clientdisconnection();
        }
        #endregion  
        //重连成功定义
        #region 
        private bool reconnection;
        protected virtual void clientreconnection()
        {
            ClientReconnection?.Invoke(); /* 事件被触发 */
        }
        public void Setreconnection()
        {
            clientreconnection();
        }
        #endregion
        public void Run(CancellationToken ct)
        {
            back = new CallBack();
            InstanceContext context = new InstanceContext(back);
            using (DuplexChannelFactory<IService> channelFactory = new DuplexChannelFactory<IService>(context, "NetTcpBinding_IService"))
            {
                IService proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    //proxy.Login(personInfo);
                    while (true)
                    {
                        ct.ThrowIfCancellationRequested();
                        Thread.Sleep(3000);
                        try
                        {
                            proxy.Update(personInfo);
                            Setreconnection();                            
                        }
                        catch
                        {
                            SetBreaken();
                            try
                            {
                                Console.WriteLine("正在重连");
                                proxy = channelFactory.CreateChannel();
                                //proxy.Login(personInfo);
                                client = new ServiceClient(context);
                                client.SendPerosnInfoToServer(personInfo);
                            }
                            catch
                            {
                                Console.WriteLine("重连异常");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 建立连接,并产生接受类.
        /// </summary>
        public void Star()
        {
            back = new CallBack();
            InstanceContext context = new InstanceContext(back);
            client = new ServiceClient(context);
            //client.Login(personInfo);
        }
        /// <summary>
        /// 改变连接Ip
        /// </summary>
        /// <param name="IP"></param>
        public void Change_connection_IP(string IP)
        {
            back = new CallBack();
            InstanceContext context = new InstanceContext(back);
            client = new ServiceClient(context);
            client.Endpoint.Address = new EndpointAddress("net.tcp://" + IP + "/6000/mywcf");
        }
        /// <summary>
        /// 向服务端发送用户信息函数,配置个人信息，开启断线重连 登录类
        /// </summary>
        /// <param name="personInfo">用户信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        public bool SendPerosnInfoToServer(PersonInfo personInfo)
        {
            this.personInfo = personInfo;
            Star();
            back = new CallBack();
            InstanceContext context = new InstanceContext(back);
            task = new Task(() => { Run(ct); }, ct);
            task.Start();
            try
            {
                bool b = client.SendPerosnInfoToServer(personInfo);
                return b;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        ///向服务端发送请假信息
        /// </summary>
        /// <param name="userNickName"></param>
        /// <param name="state"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendStateInfoToServe(string userNickName, PersonStateInfo state, string message)
        {
            return client.SendStateInfoToServer(userNickName, state, message);
        }

        /// <summary>
        /// 向服务端发送用户课表函数 
        /// </summary>
        /// <param name="pictureInfo">课表信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        public bool SendPictureInfoToServer(PictureInfo pictureInfo)
        {
            return client.SendPictureInfoToServer(pictureInfo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        public bool SendPasswordToServer(PersonInfo personInfo)
        {
            return client.SendPasswordToServer(personInfo);
        }

        /// <summary>
        /// 向服务端发送签到信息
        /// </summary>
        /// <param name="signInfo">签到信息类</param>
        /// <returns>返回的bool来判断是否发送成功</returns>
        public bool SendSignInfoToServer(PersonSignInfo signInfo)
        {
            return client.SendSignInfoToServer(signInfo);
        }

        /// <summary>
        /// 向服务端发送用户状态信息
        /// </summary>
        /// <param name="stateInfo">用户状态信息类</param>
        /// <returns>返回的bool判断是否发送成功</returns>
        public bool SendStateInfoToServer(string userNickName, PersonStateInfo state, string message)
        {
            return client.SendStateInfoToServer(userNickName, state, message);
        }
        /// <summary>
        /// 从服务端获得Mac地址
        /// </summary>
        /// <param name="userName">给定的UserName</param>
        /// <returns>返回值为String类型的Mac地址</returns>
        public string ReceiveMacAddress(string userName)
        {
            return client.ReceiveMacAddress(userName);
        }
        /// <summary>
        /// 从服务端接收（课表信息）
        /// </summary>
        /// <returns>返回课表信息类</returns>
        public PictureInfo ReceivePictureFromServer(string useName, TimetableAndExpPic ttAndEP)
        {
            return client.ReceivePictureFromServer(useName, ttAndEP);
        }
        /// <summary>
        /// 从服务端接收今日是否已签到
        /// </summary>
        /// <returns>返回是否已签到</returns>
        public bool ReceiveSignInfoFromServer()
        {
            return client.ReceiveSignInfoFromServer();
        }
        /// <summary>
        /// 从服务端接收所有的签到信息
        /// </summary>
        /// <returns>返回签到信息的集合</returns>
        public ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer()
        {
            List<PersonSignInfo> names = client.ReceiveAllSignInfoFromServerAsync().Result.ToList();
            ObservableCollection<PersonSignInfo> observableCollection = new ObservableCollection<PersonSignInfo>();
            names.ForEach(x => observableCollection.Add(x));
            return observableCollection;
        }
        /// <summary>
        /// 离线方法
        /// </summary>
        public void Leave()
        {
            cts.Cancel();
            client.Leave(personInfo);
        }
    }
}
