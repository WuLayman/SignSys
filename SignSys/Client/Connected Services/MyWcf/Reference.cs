﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.MyWcf {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonInfo", Namespace="http://schemas.datacontract.org/2004/07/PublicBaseClassProj")]
    [System.SerializableAttribute()]
    public partial class PersonInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MacAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassWordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNickNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserRealNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MacAddress {
            get {
                return this.MacAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.MacAddressField, value) != true)) {
                    this.MacAddressField = value;
                    this.RaisePropertyChanged("MacAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassWord {
            get {
                return this.PassWordField;
            }
            set {
                if ((object.ReferenceEquals(this.PassWordField, value) != true)) {
                    this.PassWordField = value;
                    this.RaisePropertyChanged("PassWord");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserNickName {
            get {
                return this.UserNickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNickNameField, value) != true)) {
                    this.UserNickNameField = value;
                    this.RaisePropertyChanged("UserNickName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserRealName {
            get {
                return this.UserRealNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserRealNameField, value) != true)) {
                    this.UserRealNameField = value;
                    this.RaisePropertyChanged("UserRealName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PictureInfo", Namespace="http://schemas.datacontract.org/2004/07/PublicBaseClassProj")]
    [System.SerializableAttribute()]
    public partial class PictureInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.MyWcf.TimetableAndExpPic TtAndEPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNickNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Picture {
            get {
                return this.PictureField;
            }
            set {
                if ((object.ReferenceEquals(this.PictureField, value) != true)) {
                    this.PictureField = value;
                    this.RaisePropertyChanged("Picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.MyWcf.TimetableAndExpPic TtAndEP {
            get {
                return this.TtAndEPField;
            }
            set {
                if ((this.TtAndEPField.Equals(value) != true)) {
                    this.TtAndEPField = value;
                    this.RaisePropertyChanged("TtAndEP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserNickName {
            get {
                return this.UserNickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNickNameField, value) != true)) {
                    this.UserNickNameField = value;
                    this.RaisePropertyChanged("UserNickName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimetableAndExpPic", Namespace="http://schemas.datacontract.org/2004/07/PublicBaseClassProj")]
    public enum TimetableAndExpPic : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        课程表 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        实验表 = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonSignInfo", Namespace="http://schemas.datacontract.org/2004/07/PublicBaseClassProj")]
    [System.SerializableAttribute()]
    public partial class PersonSignInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSignField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SignTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNickNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSign {
            get {
                return this.IsSignField;
            }
            set {
                if ((this.IsSignField.Equals(value) != true)) {
                    this.IsSignField = value;
                    this.RaisePropertyChanged("IsSign");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> SignTime {
            get {
                return this.SignTimeField;
            }
            set {
                if ((this.SignTimeField.Equals(value) != true)) {
                    this.SignTimeField = value;
                    this.RaisePropertyChanged("SignTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserNickName {
            get {
                return this.UserNickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNickNameField, value) != true)) {
                    this.UserNickNameField = value;
                    this.RaisePropertyChanged("UserNickName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonStateInfo", Namespace="http://schemas.datacontract.org/2004/07/PublicBaseClassProj")]
    public enum PersonStateInfo : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        上课 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        请假 = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyWcf.IService", CallbackContract=typeof(Client.MyWcf.IServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Login")]
        void Login(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Login")]
        System.Threading.Tasks.Task LoginAsync(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Update")]
        void Update(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Update")]
        System.Threading.Tasks.Task UpdateAsync(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Leave")]
        void Leave(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Leave")]
        System.Threading.Tasks.Task LeaveAsync(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPerosnInfoToServer", ReplyAction="http://tempuri.org/IService/SendPerosnInfoToServerResponse")]
        bool SendPerosnInfoToServer(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPerosnInfoToServer", ReplyAction="http://tempuri.org/IService/SendPerosnInfoToServerResponse")]
        System.Threading.Tasks.Task<bool> SendPerosnInfoToServerAsync(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPictureInfoToServer", ReplyAction="http://tempuri.org/IService/SendPictureInfoToServerResponse")]
        bool SendPictureInfoToServer(Client.MyWcf.PictureInfo pictureInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPictureInfoToServer", ReplyAction="http://tempuri.org/IService/SendPictureInfoToServerResponse")]
        System.Threading.Tasks.Task<bool> SendPictureInfoToServerAsync(Client.MyWcf.PictureInfo pictureInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPasswordToServer", ReplyAction="http://tempuri.org/IService/SendPasswordToServerResponse")]
        bool SendPasswordToServer(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendPasswordToServer", ReplyAction="http://tempuri.org/IService/SendPasswordToServerResponse")]
        System.Threading.Tasks.Task<bool> SendPasswordToServerAsync(Client.MyWcf.PersonInfo personInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendSignInfoToServer", ReplyAction="http://tempuri.org/IService/SendSignInfoToServerResponse")]
        bool SendSignInfoToServer(Client.MyWcf.PersonSignInfo signInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendSignInfoToServer", ReplyAction="http://tempuri.org/IService/SendSignInfoToServerResponse")]
        System.Threading.Tasks.Task<bool> SendSignInfoToServerAsync(Client.MyWcf.PersonSignInfo signInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendStateInfoToServer", ReplyAction="http://tempuri.org/IService/SendStateInfoToServerResponse")]
        bool SendStateInfoToServer(string userNickName, Client.MyWcf.PersonStateInfo state, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendStateInfoToServer", ReplyAction="http://tempuri.org/IService/SendStateInfoToServerResponse")]
        System.Threading.Tasks.Task<bool> SendStateInfoToServerAsync(string userNickName, Client.MyWcf.PersonStateInfo state, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendAllSignInfoToClient", ReplyAction="http://tempuri.org/IService/SendAllSignInfoToClientResponse")]
        bool SendAllSignInfoToClient(Client.MyWcf.PersonSignInfo[] allSignInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendAllSignInfoToClient", ReplyAction="http://tempuri.org/IService/SendAllSignInfoToClientResponse")]
        System.Threading.Tasks.Task<bool> SendAllSignInfoToClientAsync(Client.MyWcf.PersonSignInfo[] allSignInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveMacAddress", ReplyAction="http://tempuri.org/IService/ReceiveMacAddressResponse")]
        string ReceiveMacAddress(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveMacAddress", ReplyAction="http://tempuri.org/IService/ReceiveMacAddressResponse")]
        System.Threading.Tasks.Task<string> ReceiveMacAddressAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceivePictureFromServer", ReplyAction="http://tempuri.org/IService/ReceivePictureFromServerResponse")]
        Client.MyWcf.PictureInfo ReceivePictureFromServer(string userName, Client.MyWcf.TimetableAndExpPic ttAndEP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceivePictureFromServer", ReplyAction="http://tempuri.org/IService/ReceivePictureFromServerResponse")]
        System.Threading.Tasks.Task<Client.MyWcf.PictureInfo> ReceivePictureFromServerAsync(string userName, Client.MyWcf.TimetableAndExpPic ttAndEP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveSignInfoFromServer", ReplyAction="http://tempuri.org/IService/ReceiveSignInfoFromServerResponse")]
        bool ReceiveSignInfoFromServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveSignInfoFromServer", ReplyAction="http://tempuri.org/IService/ReceiveSignInfoFromServerResponse")]
        System.Threading.Tasks.Task<bool> ReceiveSignInfoFromServerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveAllSignInfoFromServer", ReplyAction="http://tempuri.org/IService/ReceiveAllSignInfoFromServerResponse")]
        Client.MyWcf.PersonSignInfo[] ReceiveAllSignInfoFromServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveAllSignInfoFromServer", ReplyAction="http://tempuri.org/IService/ReceiveAllSignInfoFromServerResponse")]
        System.Threading.Tasks.Task<Client.MyWcf.PersonSignInfo[]> ReceiveAllSignInfoFromServerAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ShowMessage", ReplyAction="http://tempuri.org/IService/ShowMessageResponse")]
        void ShowMessage(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.MyWcf.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<Client.MyWcf.IService>, Client.MyWcf.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Login(Client.MyWcf.PersonInfo personInfo) {
            base.Channel.Login(personInfo);
        }
        
        public System.Threading.Tasks.Task LoginAsync(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.LoginAsync(personInfo);
        }
        
        public void Update(Client.MyWcf.PersonInfo personInfo) {
            base.Channel.Update(personInfo);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.UpdateAsync(personInfo);
        }
        
        public void Leave(Client.MyWcf.PersonInfo personInfo) {
            base.Channel.Leave(personInfo);
        }
        
        public System.Threading.Tasks.Task LeaveAsync(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.LeaveAsync(personInfo);
        }
        
        public bool SendPerosnInfoToServer(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.SendPerosnInfoToServer(personInfo);
        }
        
        public System.Threading.Tasks.Task<bool> SendPerosnInfoToServerAsync(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.SendPerosnInfoToServerAsync(personInfo);
        }
        
        public bool SendPictureInfoToServer(Client.MyWcf.PictureInfo pictureInfo) {
            return base.Channel.SendPictureInfoToServer(pictureInfo);
        }
        
        public System.Threading.Tasks.Task<bool> SendPictureInfoToServerAsync(Client.MyWcf.PictureInfo pictureInfo) {
            return base.Channel.SendPictureInfoToServerAsync(pictureInfo);
        }
        
        public bool SendPasswordToServer(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.SendPasswordToServer(personInfo);
        }
        
        public System.Threading.Tasks.Task<bool> SendPasswordToServerAsync(Client.MyWcf.PersonInfo personInfo) {
            return base.Channel.SendPasswordToServerAsync(personInfo);
        }
        
        public bool SendSignInfoToServer(Client.MyWcf.PersonSignInfo signInfo) {
            return base.Channel.SendSignInfoToServer(signInfo);
        }
        
        public System.Threading.Tasks.Task<bool> SendSignInfoToServerAsync(Client.MyWcf.PersonSignInfo signInfo) {
            return base.Channel.SendSignInfoToServerAsync(signInfo);
        }
        
        public bool SendStateInfoToServer(string userNickName, Client.MyWcf.PersonStateInfo state, string message) {
            return base.Channel.SendStateInfoToServer(userNickName, state, message);
        }
        
        public System.Threading.Tasks.Task<bool> SendStateInfoToServerAsync(string userNickName, Client.MyWcf.PersonStateInfo state, string message) {
            return base.Channel.SendStateInfoToServerAsync(userNickName, state, message);
        }
        
        public bool SendAllSignInfoToClient(Client.MyWcf.PersonSignInfo[] allSignInfo) {
            return base.Channel.SendAllSignInfoToClient(allSignInfo);
        }
        
        public System.Threading.Tasks.Task<bool> SendAllSignInfoToClientAsync(Client.MyWcf.PersonSignInfo[] allSignInfo) {
            return base.Channel.SendAllSignInfoToClientAsync(allSignInfo);
        }
        
        public string ReceiveMacAddress(string userName) {
            return base.Channel.ReceiveMacAddress(userName);
        }
        
        public System.Threading.Tasks.Task<string> ReceiveMacAddressAsync(string userName) {
            return base.Channel.ReceiveMacAddressAsync(userName);
        }
        
        public Client.MyWcf.PictureInfo ReceivePictureFromServer(string userName, Client.MyWcf.TimetableAndExpPic ttAndEP) {
            return base.Channel.ReceivePictureFromServer(userName, ttAndEP);
        }
        
        public System.Threading.Tasks.Task<Client.MyWcf.PictureInfo> ReceivePictureFromServerAsync(string userName, Client.MyWcf.TimetableAndExpPic ttAndEP) {
            return base.Channel.ReceivePictureFromServerAsync(userName, ttAndEP);
        }
        
        public bool ReceiveSignInfoFromServer() {
            return base.Channel.ReceiveSignInfoFromServer();
        }
        
        public System.Threading.Tasks.Task<bool> ReceiveSignInfoFromServerAsync() {
            return base.Channel.ReceiveSignInfoFromServerAsync();
        }
        
        public Client.MyWcf.PersonSignInfo[] ReceiveAllSignInfoFromServer() {
            return base.Channel.ReceiveAllSignInfoFromServer();
        }
        
        public System.Threading.Tasks.Task<Client.MyWcf.PersonSignInfo[]> ReceiveAllSignInfoFromServerAsync() {
            return base.Channel.ReceiveAllSignInfoFromServerAsync();
        }
    }
}