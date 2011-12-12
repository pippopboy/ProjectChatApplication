using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.ServiceModel;

namespace OptionContract
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false, IncludeExceptionDetailInFaults = true)]
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ChatServer: IChat
    {
        private Dictionary<string, IChatCallBack> ClientCallBacks = new Dictionary<string, IChatCallBack>();
        private ChatDBDataContext DB = new ChatDBDataContext();
        static readonly object SyncObj = new object();
        public IChatCallBack CurrentCallback
        {
            get { return OperationContext.Current.GetCallbackChannel<IChatCallBack>(); }
        }

        #region CheckOnlineListFriend
        private void CheckOnlineListFriends(string username)
        {
            lock (SyncObj)
            {
                List<User> listonline = this.GetListOnlineFriends(username);
                if (listonline.Count > 0)
                {
                    foreach (User useronline in listonline)
                    {
                        try
                        {

                            ClientCallBacks[useronline.username].UserLoggedin(GetUserByUsername(username));
                        }
                        catch (Exception)
                        {
                            ClientCallBacks.Remove(useronline.username);
                        }
                    }
                }
            }
        }
        #endregion 

        #region CheckOnline
        //Check an user online or not
        public bool CheckOnline(string username)
        {
            if (ClientCallBacks.ContainsKey(username))
            {
                return true;
            }
            return false;
        }
	
        #endregion

        #region Register

        public void Register(string _username, string _password, byte[] _avarta)
        {
            //ChatDBDataContext DB = new ChatDBDataContext();
            var Users = from U in DB.users
                        where U.username == _username
                        select U;
            foreach (user user in Users)
            {
                throw new Exception("Tên đăng nhập đã tồn tại. Mời bạn nhập lại!");
            }

            user newUser = new user {username = _username, password = _password, avarta = _avarta};
            DB.users.InsertOnSubmit(newUser);
            DB.SubmitChanges();
        }
        #endregion

        #region Login
        public void Login(string username, string password)
        {
            ChatDBDataContext chatdb = new ChatDBDataContext();
            int exist = 0;
            lock (SyncObj)
            {
                var existusers = from u in chatdb.users
                                 where u.username == username
                                 select u;
                if (existusers.FirstOrDefault()!=null)
                {
                    exist = 1;
                }

                var Users = from U in DB.users
                             where U.username == username && U.password == password
                             select U;
                if (Users.Count() == 0)
                {

                    if (exist == 1)
                    {
                        //TrackedFault trackedFault = new TrackedFault(Guid.NewGuid(), Username, "Password is incorrect!", DateTime.Now);
                        //throw new FaultException<TrackedFault>(trackedFault, "Password isn't correct", FaultCode.CreateReceiverFaultCode(new FaultCode("Login")));
                        //return 2;
                        throw new Exception("Mật Khẩu sai!");
                    }
                    else
                    {
                        throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng! Thử lại!");
                    }
                }
                else
                {
                    //Username da dang nhap nen co trong danh sach callback
                    if (ClientCallBacks.ContainsKey(username))
                        throw new Exception(username + "đang online!");
                    else
                    {
                        CheckOnlineListFriends(username);
                        ClientCallBacks.Add(username, CurrentCallback);
                    }
                }
            }
        }

       

        #endregion

        #region Lấy thông tin người dùng
	  
        public User GetInformationUser(string username)
        {
            ChatDBDataContext dataContext = new ChatDBDataContext();
            var existusers = (from u in dataContext.users
                              where u.username == username
                              select u).Single();
            User newuser = new User();
            newuser.userid = existusers.userid;
            newuser.username = existusers.username;
            newuser.password = existusers.password;
            newuser.avarta = existusers.avarta;
            return newuser;
        }
        #endregion

        #region Lây avarta 
        public Binary GetAvartaByUsername(string username)
        {
            var avarta = (from u in DB.users
                          where u.username == username
                          select u.avarta).Single();
            return avarta;
        }
        #endregion

        #region GetFriend
        private int GetFriend(string Username, string Friend)
        {
            User NewUser = this.GetUserByUsername(Username);
            User NewFriend = this.GetUserByUsername(Username);

            var Friends = from R in DB.Relations
                         where R.Userid == NewUser.userid && R.FriendId == NewFriend.userid
                         select R;

            foreach (Relation rl in Friends)
            {
                return 1;
            }
            return 0;
        }
        #endregion

        #region MessageAddFriend
        public void MessageAddFriend(string Username, string Friend, string message)
        {
            lock (SyncObj)
            {
                if(ClientCallBacks.ContainsKey(Friend))
                    ClientCallBacks[Friend].SendMessageAddFriend(Username, message);
            }
          
        }

        public void SendMessageResult(string Tousername, string message)
        {
            lock (SyncObj)
            {
                ClientCallBacks[Tousername].AddFriendMessageResult(message);
            }
        }

        #endregion

        #region AddFriend
        public void AddFriend(string Username, string Friend)
        {
            lock (SyncObj)
            {
                User NewUser = this.GetUserByUsername(Username);
                User NewFriend = this.GetUserByUsername(Friend);
                Relation RL = new Relation();
                RL.Userid = NewUser.userid;
                RL.FriendId = NewFriend.userid;
                DB.Relations.InsertOnSubmit(RL);
                DB.SubmitChanges();

                Relation RL1 = new Relation();
                RL1.Userid = NewFriend.userid;
                RL1.FriendId = NewUser.userid;
                DB.Relations.InsertOnSubmit(RL1);
                DB.SubmitChanges();
                if (ClientCallBacks.ContainsKey(Friend))
                {
                    ClientCallBacks[Friend].UserLoggedin(GetUserByUsername(Username));
                }
            }
        }
        #endregion

        #region ChangeAvarta
        public void ChangeAvarta(string username, byte[] avarta)
        {
            var change = (from U in DB.users
                         where U.username == username
                         select U).Single();
            change.avarta = avarta;
            DB.SubmitChanges();
        }
        #endregion

        #region LogOut
        public void Logout(string username)
        {
            List<User> listuser = new List<User>();
            if (ClientCallBacks.ContainsKey(username))
            {
                ClientCallBacks.Remove(username);
                listuser = this.GetListOnlineFriends(username);
                foreach (User user in listuser)
                {
                    try
                    {
                        ClientCallBacks[user.username].Userloggedout(GetUserByUsername(username));

                    }
                    catch (System.Exception )
                    {
                        ClientCallBacks.Remove(user.username);
                    }            
                }
            }
        }
        #endregion

        #region GetUserById
        private User GetUserById(int userid)
        {
            User NewUser = new User();
            var Users = from U in DB.users
                        where U.userid == userid
                        select U;
            foreach (user user in Users)
            {
                NewUser.userid = user.userid;
                NewUser.username = user.username;
                NewUser.password = user.password;
                NewUser.avarta = user.avarta;
            }
            return NewUser;
        }
        #endregion

        #region GetUserByUserName
        private User GetUserByUsername(string Username)
        {
            User NewUser = new User();
            var users = (from U in DB.users
                        where U.username == Username
                        select U).Distinct().Single();
           
            NewUser.userid = users.userid;
            NewUser.username = users.username;
            NewUser.password = users.password;
            NewUser.avarta = users.avarta;
            
            return NewUser;
        }
        #endregion

        #region GetListFriends
        public int GetlistFriend(string Username, string Friend)
        {
            User NewUser = this.GetUserByUsername(Username);
            User NewFriend = this.GetUserByUsername(Username);

            var Friends = from R in DB.Relations
                          where R.Userid == NewUser.userid && R.FriendId == NewFriend.userid
                          select R;

            foreach (Relation rl in Friends)
            {
                return 1;
            }
            return 0;
        }
        #endregion
        
        #region GetListOnlineFriends
        public List<User> GetListOnlineFriends(string username)
        {
            lock (SyncObj)
            {

                List<User> UL = new List<User>();
                User NewUser = this.GetUserByUsername(username);
                var Friends = (from R in DB.Relations
                               where R.Userid == NewUser.userid
                               select R).Distinct();
                foreach (Relation Friend in Friends)
                {
                    User FriendData = this.GetUserById(Friend.FriendId);
                    if (ClientCallBacks.ContainsKey(FriendData.username))
                    {
                        UL.Add(FriendData);
                    }
                }
                return UL;
            }

        }
        #endregion

        #region GetListOfflineFriends
        public List<User> GetListOfflineFriends(string username)
        {
            List<User> UL = new List<User>();
            //ChatDBDataContext DB = new ChatDBDataContext();
            User NewUser = this.GetUserByUsername(username);
            var Friends = from R in DB.Relations
                          where R.Userid == NewUser.userid
                          select R;
            foreach (Relation Friend in Friends)
            {
                User FriendData = this.GetUserById(Friend.FriendId);
                if (!ClientCallBacks.ContainsKey(FriendData.username))
                {
                    UL.Add(FriendData);
                }
            }
            return UL;
        }
        #endregion

        #region Send a public Message
        public void SendPublicMessage(ChatMessage cm, string username)
        {
            foreach (KeyValuePair<string, IChatCallBack> pair in ClientCallBacks)
            {
                if (pair.Key != username)
                    ClientCallBacks[pair.Key].NewPublicMessage(cm);
            }
            
            //List<User> online = GetListOnlineFriends(To);
            //foreach (User user in online)
            //{
            //    ClientCallBacks[user.username].NewMessage(CM);
            //}
        }
       #endregion

        #region Send a private message
		public void SendPrivateMessage(ChatMessage cm, string to)
		{
            if (ClientCallBacks.ContainsKey(to))
            {
                ClientCallBacks[to].NewPrivateMessage(cm);
            }
		}
        #endregion

        #region Send File
        public void SendFile(FileMessage fileMessage, string receiver)
        {
         
                if (ClientCallBacks.ContainsKey(receiver))
                {
                    ClientCallBacks[receiver].ReceiverFile(fileMessage, receiver);
                }
                else
                {
                    throw new FaultException(fileMessage.Sender + "Không online...");
                }

        }

        public void SendMessageBack(string username, string messageContent)
        {
            ClientCallBacks[username].ReceiveMessageBack(messageContent);
        }

   

        #endregion
    }
}
