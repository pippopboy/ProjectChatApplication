﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChattingClient.ChatServer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/OptionContract")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.Linq.Binary avartaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int useridField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
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
        public System.Data.Linq.Binary avarta {
            get {
                return this.avartaField;
            }
            set {
                if ((object.ReferenceEquals(this.avartaField, value) != true)) {
                    this.avartaField = value;
                    this.RaisePropertyChanged("avarta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int userid {
            get {
                return this.useridField;
            }
            set {
                if ((this.useridField.Equals(value) != true)) {
                    this.useridField = value;
                    this.RaisePropertyChanged("userid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatMessage", Namespace="http://schemas.datacontract.org/2004/07/OptionContract")]
    [System.SerializableAttribute()]
    public partial class ChatMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CurrentTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ChattingClient.ChatServer.User SenderField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CurrentTime {
            get {
                return this.CurrentTimeField;
            }
            set {
                if ((this.CurrentTimeField.Equals(value) != true)) {
                    this.CurrentTimeField = value;
                    this.RaisePropertyChanged("CurrentTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ChattingClient.ChatServer.User Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="FileMessage", Namespace="http://schemas.datacontract.org/2004/07/OptionContract")]
    [System.SerializableAttribute()]
    public partial class FileMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
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
        public byte[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServer.IChat", CallbackContract=typeof(ChattingClient.ChatServer.IChatCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Register", ReplyAction="http://tempuri.org/IChat/RegisterResponse")]
        void Register(string username, string password, byte[] avarta);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Login")]
        void Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetInformationUser", ReplyAction="http://tempuri.org/IChat/GetInformationUserResponse")]
        ChattingClient.ChatServer.User GetInformationUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetAvartaByUsername", ReplyAction="http://tempuri.org/IChat/GetAvartaByUsernameResponse")]
        System.Data.Linq.Binary GetAvartaByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/MessageAddFriend")]
        void MessageAddFriend(string username, string friend, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendMessageResult")]
        void SendMessageResult(string tousername, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/AddFriend")]
        void AddFriend(string username, string friend);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/CheckOnline", ReplyAction="http://tempuri.org/IChat/CheckOnlineResponse")]
        bool CheckOnline(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/ChangeAvarta", ReplyAction="http://tempuri.org/IChat/ChangeAvartaResponse")]
        void ChangeAvarta(string username, byte[] avarta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Logout", ReplyAction="http://tempuri.org/IChat/LogoutResponse")]
        void Logout(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetListOnlineFriends", ReplyAction="http://tempuri.org/IChat/GetListOnlineFriendsResponse")]
        ChattingClient.ChatServer.User[] GetListOnlineFriends(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetListOfflineFriends", ReplyAction="http://tempuri.org/IChat/GetListOfflineFriendsResponse")]
        ChattingClient.ChatServer.User[] GetListOfflineFriends(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendPublicMessage", ReplyAction="http://tempuri.org/IChat/SendPublicMessageResponse")]
        void SendPublicMessage(ChattingClient.ChatServer.ChatMessage cm, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendPrivateMessage", ReplyAction="http://tempuri.org/IChat/SendPrivateMessageResponse")]
        void SendPrivateMessage(ChattingClient.ChatServer.ChatMessage cm, string tousername);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendFile", ReplyAction="http://tempuri.org/IChat/SendFileResponse")]
        void SendFile(ChattingClient.ChatServer.FileMessage fileMessage, string receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendMessageBack")]
        void SendMessageBack(string username, string messageContent);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserLoggedin")]
        void UserLoggedin(ChattingClient.ChatServer.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Userloggedout")]
        void Userloggedout(ChattingClient.ChatServer.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendMessageAddFriend")]
        void SendMessageAddFriend(string username, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/AddFriendMessageResult")]
        void AddFriendMessageResult(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/NewPublicMessage")]
        void NewPublicMessage(ChattingClient.ChatServer.ChatMessage cm);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/NewPrivateMessage")]
        void NewPrivateMessage(ChattingClient.ChatServer.ChatMessage cm);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiverFile")]
        void ReceiverFile(ChattingClient.ChatServer.FileMessage fileMessage, string receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveMessageBack")]
        void ReceiveMessageBack(string messageContent);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveInformation")]
        void ReceiveInformation(ChattingClient.ChatServer.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : ChattingClient.ChatServer.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.DuplexClientBase<ChattingClient.ChatServer.IChat>, ChattingClient.ChatServer.IChat {
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Register(string username, string password, byte[] avarta) {
            base.Channel.Register(username, password, avarta);
        }
        
        public void Login(string username, string password) {
            base.Channel.Login(username, password);
        }
        
        public ChattingClient.ChatServer.User GetInformationUser(string username) {
            return base.Channel.GetInformationUser(username);
        }
        
        public System.Data.Linq.Binary GetAvartaByUsername(string username) {
            return base.Channel.GetAvartaByUsername(username);
        }
        
        public void MessageAddFriend(string username, string friend, string message) {
            base.Channel.MessageAddFriend(username, friend, message);
        }
        
        public void SendMessageResult(string tousername, string message) {
            base.Channel.SendMessageResult(tousername, message);
        }
        
        public void AddFriend(string username, string friend) {
            base.Channel.AddFriend(username, friend);
        }
        
        public bool CheckOnline(string username) {
            return base.Channel.CheckOnline(username);
        }
        
        public void ChangeAvarta(string username, byte[] avarta) {
            base.Channel.ChangeAvarta(username, avarta);
        }
        
        public void Logout(string username) {
            base.Channel.Logout(username);
        }
        
        public ChattingClient.ChatServer.User[] GetListOnlineFriends(string username) {
            return base.Channel.GetListOnlineFriends(username);
        }
        
        public ChattingClient.ChatServer.User[] GetListOfflineFriends(string username) {
            return base.Channel.GetListOfflineFriends(username);
        }
        
        public void SendPublicMessage(ChattingClient.ChatServer.ChatMessage cm, string username) {
            base.Channel.SendPublicMessage(cm, username);
        }
        
        public void SendPrivateMessage(ChattingClient.ChatServer.ChatMessage cm, string tousername) {
            base.Channel.SendPrivateMessage(cm, tousername);
        }
        
        public void SendFile(ChattingClient.ChatServer.FileMessage fileMessage, string receiver) {
            base.Channel.SendFile(fileMessage, receiver);
        }
        
        public void SendMessageBack(string username, string messageContent) {
            base.Channel.SendMessageBack(username, messageContent);
        }
    }
}