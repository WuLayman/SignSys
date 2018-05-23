using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.ObjectModel;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using WCFSocket.CommunicateManager.Agreement;
using PublicBaseClassProj;

namespace WCFSocket.CommunicateManager
{
    public static class ServerOperation
    {
        public static ServiceHost host;
        public static Dictionary<ICallBackServices, Person> people = new Dictionary<ICallBackServices, Person>();
        public static string ErrorMsg = null;
        /// <summary>
        /// 与服务端建立通信连接，
        /// 即启动监听程序
        /// </summary>
        /// <returns>返回值为bool，确定是否成功启动监听程序</returns>
        public static bool SetConnectionToClient()
        {
            bool tip = false;
            try
            {
                host = new ServiceHost(typeof(Service));
                host.Open();
                tip = true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
            return tip;
        }

        public static bool CloseConnectionToClient()
        {
            try
            {
                host.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (host == null)
                {
                    ErrorMsg = "还未开启服务！";
                }
                else if (host.State == CommunicationState.Faulted)
                {
                    ErrorMsg = "还未开启服务！";
                }
                else if (host.State == CommunicationState.Closed)
                {
                    ErrorMsg = "服务已关闭！";
                }
                else if (host.State == CommunicationState.Closing)
                {
                    ErrorMsg = "服务正在关闭！";
                }
                else
                {
                    ErrorMsg = ex.Message;
                }
                return false;
            }
        }
        /// <summary>
        /// 客户端接收服务端已建立连接的远程终结点
        /// 用于客户端监视窗体显示
        /// </summary>
        /// <returns></returns>
        public static List<Person> ReceiveClientInfo()
        {
            List<Person> users = new List<Person>();
            var data = people;
            foreach (var p in data)
            {
                users.Add(p.Value);
            }
            return users;
        }
    }
    public class Person
    {
        public Person(PersonInfo info, string IP, int port)
        {
            personInfo = info;
            iP = IP;
            this.port = port;
        }
        private Cache cache = new Cache();
        private ICallBackServices call;
        private PersonInfo personInfo;
        public ICallBackServices Call { get => call; set => call = value; }
        public PersonInfo PersonInfo { get => personInfo; set => personInfo = value; }
        public string IP { get => iP; set => iP = value; }
        public int Port { get => port; set => port = value; }
        public Cache Cache { get => cache; set => cache = value; }

        private string iP;
        private int port;
    }
}
