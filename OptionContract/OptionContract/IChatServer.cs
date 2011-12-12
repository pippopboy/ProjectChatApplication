using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Drawing;

namespace OptionContract
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int userid;
        
        [DataMember]
        public string username;
        
        [DataMember]
        public string password;

        [DataMember]
        public Binary avarta;
    }

    [DataContract]
    public class ChatMessage
    {
        [DataMember]
        public User Sender;

        [DataMember]
        public string Content;

        [DataMember]
        public DateTime CurrentTime;
    }
    
    [DataContract]
    public class TrackedFault
    {
        #region Private fields
        private Guid _trackingId;
        private string _name;
        private string _details;
        private DateTime _dateTime;
        #endregion

        #region Properties
        [DataMember]
        public Guid TrackingId
        {
            get { return _trackingId; }
            set { _trackingId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        [DataMember]
        public DateTime DateAndTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        #endregion

        public TrackedFault(Guid id, string name, string details, DateTime dateTime)
        {
            _name = name;
            _trackingId = id;
            _details = details;
            _dateTime = dateTime;
        }
    }

    [DataContract]
    public class FileMessage
    {
        private string _sender;
        private string _fileName;
        private byte[] _data;
        private DateTime _time;

        [DataMember]
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        [DataMember]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        [DataMember]
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }

    [ServiceContract(CallbackContract=typeof(IChatCallBack), SessionMode = SessionMode.Required )]
    public interface IChat
    {

        [OperationContract]
        void Register(string username, string password, byte[] avarta);

        [OperationContract(IsOneWay = true)]
        void Login(string username, string password);

        [OperationContract]
        User GetInformationUser(string username);

        [OperationContract]
        Binary GetAvartaByUsername(string username);

        [OperationContract(IsOneWay = true)]
        void MessageAddFriend(string username, string friend, string message);

        [OperationContract(IsOneWay = true)]
        void SendMessageResult(string tousername, string message);

        [OperationContract(IsOneWay = true)]
        void AddFriend(string username, string friend);

        [OperationContract]
        bool CheckOnline(string username);

        [OperationContract]
        void ChangeAvarta(string username, byte[] avarta);

        [OperationContract]
        void Logout(string username);

        [OperationContract]
        List<User> GetListOnlineFriends(string username);

        [OperationContract]
        List<User> GetListOfflineFriends(string username);

        [OperationContract]
        void SendPublicMessage(ChatMessage cm, string username);

        [OperationContract]
        void SendPrivateMessage(ChatMessage cm, string tousername);

        [OperationContract]
        void SendFile(FileMessage fileMessage, string receiver);

        [OperationContract(IsOneWay = true)]
        void SendMessageBack(string username, string messageContent);

   
    }

    public interface IChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void UserLoggedin(User user);

        [OperationContract(IsOneWay = true)]
        void Userloggedout(User user);

        [OperationContract(IsOneWay = true)]
        void SendMessageAddFriend(string username, string message);

        [OperationContract(IsOneWay = true)]
        void AddFriendMessageResult(string message);

        [OperationContract(IsOneWay = true)]
        void NewPublicMessage(ChatMessage cm);

        [OperationContract(IsOneWay = true)]
        void NewPrivateMessage(ChatMessage cm);

        [OperationContract(IsOneWay = true)]
        void ReceiverFile(FileMessage fileMessage, string receiver);

        [OperationContract(IsOneWay = true)]
        void ReceiveMessageBack(string messageContent);

        [OperationContract(IsOneWay = true)]
        void ReceiveInformation(User user);
    }

    
}
