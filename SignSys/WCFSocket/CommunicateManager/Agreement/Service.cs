using AllInterface.AllInterfaceProj.PublicBaseInterface;
using AllInterfaceProj.ServerInterface;
using ImplementInterface;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFSocket.CommunicateManager.Agreement
{
    // 服务端接受数据并存入cache
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true, UseSynchronizationContext = true)]
    public class Service : IService
    {
        ICallBackServices client = OperationContext.Current.GetCallbackChannel<ICallBackServices>();//回调接口
        private static readonly object InstObj = new object();//单一实例 
        private static PersonInfo person;
        IGetData getData = new GetDataHelper();
        ISendDataToDB sendDataToDB = new SendDataHelper();
        public bool SendPerosnInfoToServer(PersonInfo personInfo)
        {
            bool tip = false;
            try
            {
                tip = getData.SendPerosnInfoToServer(personInfo);
                if (tip)
                {
                    Login(personInfo);
                    ServerOperation.people[client].PersonInfo = personInfo;
                    person = personInfo;
                }
            }
            catch (Exception)
            {
            }
            return tip;
        }
        public bool SendPictureInfoToServer(PictureInfo pictureInfo)
        {
            bool tip = false;
            try
            {
                ServerOperation.people[client].Cache.PictureInfo = pictureInfo;
                tip = sendDataToDB.SendPictureInfoToDB(pictureInfo);
            }
            catch (Exception)
            {
                throw;
            }
            return tip;
        }
        public bool SendSignInfoToServer(PersonSignInfo signInfo)
        {
            bool tip = false;
            try
            {
                ServerOperation.people[client].Cache.SignInfo = signInfo;
                tip = sendDataToDB.SendSignInfoToDB(signInfo);
            }
            catch (Exception)
            {
                throw;
            }
            return tip;
        }
        public bool SendStateInfoToServer(string userNickName, PersonStateInfo state, string message)
        {
            bool tip = false;
            try
            {
                ServerOperation.people[client].Cache.StateInfo = state;
                ServerOperation.people[client].Cache.LeaveReson = message;
                tip = sendDataToDB.SendStateInfoDB(userNickName, state, message);
            }
            catch (Exception)
            {
                throw;
            }
            return tip;
        }
        void Channel_Closing(object sender, EventArgs e)
        {
            lock (InstObj)//加锁，处理并发
            {
                if (ServerOperation.people != null && ServerOperation.people.Count > 0)
                {
                    foreach (var d in ServerOperation.people)
                    {
                        if (d.Key == (ICallBackServices)sender)//删除此关闭的客户端信息
                        {
                            ServerOperation.people.Remove((ICallBackServices)sender);
                            break;
                        }
                    }
                }
            }
        }

        public bool SendAllSignInfoToClient(ObservableCollection<PersonSignInfo> allSignInfo)
        {
            bool tip = false;
            try
            {
                ServerOperation.people[client].Cache.ObservableCollection = allSignInfo;
                tip = true;
            }
            catch (Exception)
            {

                throw;
            }
            return tip;
        }

        public void Login(PersonInfo personInfo)
        {
            EndpointAddress IP = OperationContext.Current.Channel.RemoteAddress;
            var endpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);//注册客户端关闭触发事件     
            ServerOperation.people.Add(client, new Person(personInfo, endpoint.Address, endpoint.Port));
        }

        public void Update(PersonInfo personInfo)
        {
            try
            {
                client = OperationContext.Current.GetCallbackChannel<ICallBackServices>();
                Console.WriteLine("用户:" + personInfo.UserRealName + "心跳更新！");
                lock (InstObj)
                {
                    foreach (var p in ServerOperation.people)
                    {
                        if (p.Value.PersonInfo == personInfo)
                        {
                            ServerOperation.people.Remove(client);
                        }
                    }
                    EndpointAddress IP = OperationContext.Current.Channel.RemoteAddress;
                    var endpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);//注册客户端关闭触发事件    
                    ServerOperation.people[client] = new Person(personInfo, endpoint.Address, endpoint.Port);
                    client.ShowMessage(personInfo.UserRealName);
                }
            }
            catch
            {

            }
        }
        public void Leave(PersonInfo personInfo)
        {
            foreach (var d in ServerOperation.people)
            {
                if (d.Value.PersonInfo == personInfo)//删除此关闭的客户端信息
                {
                    ServerOperation.people.Remove(client);
                    break;
                }
            }
        }
        public string ReceiveMacAddress(string userName)
        {
            return getData.ReceiveMacAddress(userName);
        }

        public PictureInfo ReceivePictureFromServer(string useName, TimetableAndExpPic ttAndEP)
        {
            return getData.ReceivePictureFromServer(useName, ttAndEP);
        }

        public bool ReceiveSignInfoFromServer()
        {
            return getData.ReceiveSignInfoFromServer(person);
        }

        public ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer()
        {
            return getData.ReceiveAllSignInfoFromServer(person);
        }

        public PictureInfo ReceivePictureFromServer(TimetableAndExpPic ttAndEP)
        {
            throw new NotImplementedException();
        }

        public bool SendPasswordToServer(PersonInfo personInfo)
        {
            bool tip = false;
            try
            {
                tip = sendDataToDB.SendChangePersonInfoToDB(personInfo);
            }
            catch (Exception)
            {
                throw;
            }
            return tip;
        }
    }
}
