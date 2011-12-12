using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.ServiceModel;
using ChattingClient.ChatServer;


namespace ChattingClient
{
  
    public partial class Form1 : Form, IChatCallback
    {
        #region Proxy
		 
        public static ChatClient proxy;
       
        //NetTcpBinding ws = new NetTcpBinding(SecurityMode.None);
        private WSDualHttpBinding ws = new WSDualHttpBinding();
        EndpointAddress address = new EndpointAddress("http://localhost:8000/Chat/");
        #endregion

        #region Field static sử dụng
        private string _toUser;
        public string Message;
        public static string Username;
        public static string Friend;
        public static string MessageAddFriend = "";
        private string _rcvFilePath = @"D:/";
        User UserClient;
        private User ChatUsers;
     
        #endregion

        public Form1()
        {
            InitializeComponent();
            ws.MaxBufferPoolSize = int.MaxValue;
            ws.MaxReceivedMessageSize = int.MaxValue;
            ws.ReaderQuotas.MaxArrayLength = int.MaxValue;
            ws.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            ws.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            proxy = new ChatClient(new InstanceContext(this), ws, address);

        }
     
        #region Function Service from client

        public void ReceiveInformation(User user)
        {
            
        }
        // Khi user log in
        public void UserLoggedin(User user)
        {
            lbfriend.Items.Add(user.username);
            ChatUsers = user;
            AppendText(RTBRoom, Color.Red, user.username + " vừa đăng nhập vào hệ thống\n");
           RTBRoom.AppendText("\n");
            //listBox2.Items.Remove(name);
        }

        //user log out
        public void Userloggedout(User user)
        {
            //listBox2.Items.Add(name);
            lbfriend.Items.Remove(user.username);
            ChatUsers = user;
            AppendText(RTBRoom, Color.Red, user.username + " vừa thoát hệ thống\n");
            RTBRoom.AppendText("\n");
        }

        //Gởi thông báo đến người dùng muốn kết bạn (ok or cancel)
        public void SendMessageAddFriend(string Friend, string message)
        {
            DialogResult  dialogResult = MessageBox.Show(Friend + " muốn kết bạn với bạn. Lời nhắn: \n" + message, "Kết Bạn",
                            MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                message = txtusername.Text + " đã đồng ý kết bạn với bạn! Xin chúc mừng";
                proxy.AddFriend(txtusername.Text, Friend);
                proxy.SendMessageResult(Friend, message);
                lbfriend.Items.Add(Friend);
            }
            else
            {
                message = txtusername.Text + "đã từ chối kết bạn với bạn! Chia buồn.";
                proxy.SendMessageResult(Friend, message);
            }
        }
        
        //gởi kết quả kết bạn
        public void AddFriendMessageResult(string message)
        {
            MessageBox.Show(message);
        }

        //Send a message ra mọi đối tượng đang online tren mạng
        public void NewPublicMessage(ChatMessage CM)
        {
            ChatUsers = CM.Sender;
            AppendText(RTBRoom, Color.Black, CM.Content);
            RTBRoom.SelectionStart = RTBRoom.Text.Length;
            RTBRoom.ScrollToCaret();
            ChatUsers = UserClient;

        }

        //Send 1 message cho 1 đối tượng người dùng cụ thể
        public void NewPrivateMessage(ChatMessage CM)
        {
            ChatUsers = CM.Sender;
            AppendText(RTBRoom, Color.Blue, CM.Content);
            AppendText(RTBPrivate, Color.Blue, CM.Content);
            RTBPrivate.SelectionStart = RTBPrivate.Text.Length;
            RTBPrivate.ScrollToCaret();
            RTBRoom.SelectionStart = RTBRoom.Text.Length;
            RTBRoom.ScrollToCaret();
            ChatUsers = UserClient;
        }

        public void ReceiverFile(FileMessage fileMessage, string receiver)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(fileMessage.Sender + " send cho ban " + fileMessage.FileName, "Send file",
                            MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.FileName = fileMessage.FileName;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.ShowDialog();
                    FileStream fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(fileMessage.Data, 0, fileMessage.Data.Length);
                    AppendText(RTBRoom, Color.Blue, "\n                              Received File " + fileMessage.FileName +"\n");
                    proxy.SendMessageBack(fileMessage.Sender, "                              File Sent!\n");
                } 
            }
            catch (Exception ex)
            {
                AppendText(RTBRoom, Color.Blue, ex.Message.ToString());
            }
        }

        public void ReceiveMessageBack(string messageContent)
        {
            AppendText(RTBRoom, Color.ForestGreen, "                              " + messageContent);
            AppendText(RTBPrivate, Color.ForestGreen, "                              " + messageContent);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }


        #region Xử lý Ảnh
        //resize avarta
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        public static Image BinaryToImage(System.Data.Linq.Binary binaryData)
        {
            if (binaryData == null) return null;

            byte[] buffer = binaryData.ToArray();
            MemoryStream memStream = new MemoryStream();
            memStream.Write(buffer, 0, buffer.Length);
            return Image.FromStream(memStream);
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        #endregion

        #region Button Login vào hệ thống
        private void button1_Click(object sender, EventArgs e)
        {
            //Click button Send
            //proxy = DuplexChannelFactory<IChat>.CreateChannel(this, ws, address);
            try
            {
                proxy.Login(txtusername.Text, txtpassword.Text);
                User[] user = proxy.GetListOnlineFriends(txtusername.Text);
                List<User> listonline = user.ToList<User>();
                foreach (var online in listonline)
                {
                    if (!lbfriend.Items.Contains(online.username))
                    {
                        lbfriend.Items.Add(online.username);
                    }
                }
                UserClient = proxy.GetInformationUser(txtusername.Text);
                ChatUsers = UserClient;
                Size size = new Size { Height = 125, Width = 125 };
                Image img = BinaryToImage(UserClient.avarta);
                img = resizeImage(img, size);
                ptAvarta.Image = img;
                label3.Text = txtusername.Text;
                label3.Visible = true;
                groudLogin.Enabled = false;
                groupInfor.Visible = true;
                //time1 = DateTime.Now.Second;
                //timer1.Enabled = true;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
       }
        #endregion

        #region Kết bạn

        // New 1 form để người dùng nhập message để gởi cho người muốn kết bạn
        private void btAddFriend_Click(object sender, EventArgs e)
        {
            if (proxy.CheckOnline(txtAddFriend.Text))
            {
                Username = txtusername.Text;
                Friend = txtAddFriend.Text;
                MessageAddFriendForm messageAddFriendForm = new MessageAddFriendForm(Friend);
                messageAddFriendForm.Show();
            }
            else
            {
                MessageBox.Show(txtAddFriend.Text + " không online hoặc không tồn tại! Thử lại lần sau. Cám ơn!");
            }
        }

        public static void addFriend()
        {
            proxy.MessageAddFriend(Username, Friend, MessageAddFriend);
        }
        #endregion


        //Lấy tên người dùng để user chat mật
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbfriend.SelectedIndex >= 0)
            {
                _toUser = lbfriend.Items[lbfriend.SelectedIndex].ToString();   
            }      
        }


        //Button Send
        private void button2_Click(object sender, EventArgs e)
        {
           Send();
        }

        //Send Text
        void Send()
        {
           
            if (RTBText.Text == string.Empty)
            {
                MessageBox.Show("Tin nhắn rỗng. Thử lại!");
            }
            else
            {
                ChatMessage CM = new ChatMessage();
                ChatUsers = UserClient;
                CM.Sender= UserClient;
                CM.Content = " " + txtusername.Text + " : " + RTBText.Text + "\n";
                CM.CurrentTime = DateTime.Now;
                if (cbChatMat.Checked)
                {
                    AppendText(RTBPrivate, Color.Blue, CM.Content);
                    AppendText(RTBRoom, Color.Blue, CM.Content);
                    RTBPrivate.SelectionStart = RTBPrivate.Text.Length;
                    RTBPrivate.ScrollToCaret();
                    RTBRoom.SelectionStart = RTBRoom.Text.Length;
                    RTBRoom.ScrollToCaret();
                    proxy.SendPrivateMessage(CM, _toUser);
                }
                else
                {
                    AppendText(RTBRoom, Color.Black, CM.Content);
                    RTBRoom.SelectionStart = RTBRoom.Text.Length;
                    RTBRoom.ScrollToCaret();
                    proxy.SendPublicMessage(CM, CM.Sender.username);
                }
            }
            RTBText.Select(0,RTBText.TextLength);
            RTBText.SelectedText = "";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }


        //test Send file
        private void button1_Click_1(object sender, EventArgs e)
        {
           
            Stream strm = null;
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.ShowDialog();
                strm = fileDialog.OpenFile();
                if (strm != null)
                {
                    byte[] buffer = new byte[(int)strm.Length];
                    int i = strm.Read(buffer, 0, buffer.Length);
                    if (i > 0)
                    {
                        var fileMessage = new FileMessage();
                        fileMessage.Sender = txtusername.Text;
                        fileMessage.FileName = fileDialog.SafeFileName;
                        fileMessage.Data = buffer;
                        fileMessage.Time = DateTime.Now;
                        AppendText(RTBPrivate, Color.Blue, "\n                              Sending File....\n");
                        AppendText(RTBRoom, Color.Blue, "\n                              Sending File....\n");
                        proxy.SendFile(fileMessage, _toUser);
                    }
                }

            }
            catch (Exception ex)
            {
                AppendText(RTBPrivate, Color.Blue, ex.Message.ToString());
                AppendText(RTBRoom, Color.Blue, ex.Message.ToString());
            }
            finally
            {
                if (strm != null)
                {
                    strm.Close();
                }
            }
        }

       
        //add đoạn message vào richtextbox
        void AppendText( RichTextBox box, Color color, string text)
        {
            Image img;
            img = BinaryToImage(ChatUsers.avarta);
            Size size = new Size();
            size.Width = 50;
            size.Height = 50;
            img = resizeImage(img, size);
            Clipboard.SetDataObject(img);
            DataFormats.Format df;
            df = DataFormats.GetFormat(DataFormats.Bitmap);
            if (box.CanPaste(df))
            {
                box.Paste(df);
            }
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            box.Select(start, end-start);
            box.SelectionColor = color;
            box.SelectionLength = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void RTBText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
                e.Handled = true;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            proxy.Logout(txtusername.Text);
            this.Close();
        }

        private void ReceiveBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_rcvFilePath);
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void ptAvarta_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         

        }

    }
}
