using System;
using ChattingClient.ChatServer;

namespace ChattingClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btLogin = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lbfriend = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RTBRoom = new System.Windows.Forms.RichTextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.groudLogin = new System.Windows.Forms.GroupBox();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.groupInfor = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ptAvarta = new System.Windows.Forms.PictureBox();
            this.btAddFriend = new System.Windows.Forms.Button();
            this.txtAddFriend = new System.Windows.Forms.TextBox();
            this.Logout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RTBPrivate = new System.Windows.Forms.RichTextBox();
            this.cbChatMat = new System.Windows.Forms.CheckBox();
            this.RTBText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groudLogin.SuspendLayout();
            this.groupInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptAvarta)).BeginInit();
            this.ChatBox.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(222, 22);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(103, 50);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Đăng Nhập";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(67, 22);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(139, 20);
            this.txtusername.TabIndex = 1;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(67, 51);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(139, 20);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // lbfriend
            // 
            this.lbfriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfriend.FormattingEnabled = true;
            this.lbfriend.ItemHeight = 25;
            this.lbfriend.Location = new System.Drawing.Point(18, 180);
            this.lbfriend.Name = "lbfriend";
            this.lbfriend.Size = new System.Drawing.Size(162, 279);
            this.lbfriend.TabIndex = 3;
            this.lbfriend.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.lbfriend.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật Khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // RTBRoom
            // 
            this.RTBRoom.AcceptsTab = true;
            this.RTBRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBRoom.Location = new System.Drawing.Point(-4, 3);
            this.RTBRoom.Name = "RTBRoom";
            this.RTBRoom.Size = new System.Drawing.Size(481, 272);
            this.RTBRoom.TabIndex = 7;
            this.RTBRoom.Text = "";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(592, 512);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 61);
            this.btSend.TabIndex = 9;
            this.btSend.Text = "Gởi";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.button2_Click);
            // 
            // groudLogin
            // 
            this.groudLogin.Controls.Add(this.RegisterBtn);
            this.groudLogin.Controls.Add(this.label1);
            this.groudLogin.Controls.Add(this.label2);
            this.groudLogin.Controls.Add(this.txtusername);
            this.groudLogin.Controls.Add(this.txtpassword);
            this.groudLogin.Controls.Add(this.btLogin);
            this.groudLogin.Location = new System.Drawing.Point(19, 16);
            this.groudLogin.Name = "groudLogin";
            this.groudLogin.Size = new System.Drawing.Size(339, 123);
            this.groudLogin.TabIndex = 11;
            this.groudLogin.TabStop = false;
            this.groudLogin.Text = "Đăng nhập";
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Location = new System.Drawing.Point(123, 78);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(103, 23);
            this.RegisterBtn.TabIndex = 6;
            this.RegisterBtn.Text = "Đăng ký";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // groupInfor
            // 
            this.groupInfor.Controls.Add(this.label5);
            this.groupInfor.Controls.Add(this.ptAvarta);
            this.groupInfor.Controls.Add(this.btAddFriend);
            this.groupInfor.Controls.Add(this.txtAddFriend);
            this.groupInfor.Controls.Add(this.label3);
            this.groupInfor.Location = new System.Drawing.Point(379, 2);
            this.groupInfor.Name = "groupInfor";
            this.groupInfor.Size = new System.Drawing.Size(294, 176);
            this.groupInfor.TabIndex = 12;
            this.groupInfor.TabStop = false;
            this.groupInfor.Text = "Thông Tin User";
            this.groupInfor.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nhập tên:";
            this.label5.Visible = false;
            // 
            // ptAvarta
            // 
            this.ptAvarta.Location = new System.Drawing.Point(16, 45);
            this.ptAvarta.Name = "ptAvarta";
            this.ptAvarta.Size = new System.Drawing.Size(125, 125);
            this.ptAvarta.TabIndex = 10;
            this.ptAvarta.TabStop = false;
            this.ptAvarta.Click += new System.EventHandler(this.ptAvarta_Click);
            // 
            // btAddFriend
            // 
            this.btAddFriend.Location = new System.Drawing.Point(191, 83);
            this.btAddFriend.Name = "btAddFriend";
            this.btAddFriend.Size = new System.Drawing.Size(75, 23);
            this.btAddFriend.TabIndex = 8;
            this.btAddFriend.Text = "Kết Bạn";
            this.btAddFriend.UseVisualStyleBackColor = true;
            this.btAddFriend.Click += new System.EventHandler(this.btAddFriend_Click);
            // 
            // txtAddFriend
            // 
            this.txtAddFriend.Location = new System.Drawing.Point(147, 57);
            this.txtAddFriend.Name = "txtAddFriend";
            this.txtAddFriend.Size = new System.Drawing.Size(130, 20);
            this.txtAddFriend.TabIndex = 7;
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(18, 484);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(162, 89);
            this.Logout.TabIndex = 9;
            this.Logout.Text = "Đăng Xuất";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Send File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ChatBox
            // 
            this.ChatBox.Controls.Add(this.tabPage1);
            this.ChatBox.Controls.Add(this.tabPage2);
            this.ChatBox.Location = new System.Drawing.Point(192, 179);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.SelectedIndex = 0;
            this.ChatBox.Size = new System.Drawing.Size(485, 299);
            this.ChatBox.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RTBRoom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat Room";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RTBPrivate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(477, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat Mật";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RTBPrivate
            // 
            this.RTBPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBPrivate.Location = new System.Drawing.Point(-4, 3);
            this.RTBPrivate.Name = "RTBPrivate";
            this.RTBPrivate.Size = new System.Drawing.Size(481, 276);
            this.RTBPrivate.TabIndex = 8;
            this.RTBPrivate.TabStop = false;
            this.RTBPrivate.Text = "";
            // 
            // cbChatMat
            // 
            this.cbChatMat.AutoSize = true;
            this.cbChatMat.Location = new System.Drawing.Point(18, 151);
            this.cbChatMat.Name = "cbChatMat";
            this.cbChatMat.Size = new System.Drawing.Size(134, 17);
            this.cbChatMat.TabIndex = 15;
            this.cbChatMat.Text = "Chat mật ( Chọn người)";
            this.cbChatMat.UseVisualStyleBackColor = true;
            // 
            // RTBText
            // 
            this.RTBText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBText.Location = new System.Drawing.Point(192, 512);
            this.RTBText.Multiline = true;
            this.RTBText.Name = "RTBText";
            this.RTBText.Size = new System.Drawing.Size(394, 61);
            this.RTBText.TabIndex = 16;
            this.RTBText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTBText_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 591);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.RTBText);
            this.Controls.Add(this.cbChatMat);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupInfor);
            this.Controls.Add(this.groudLogin);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.lbfriend);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groudLogin.ResumeLayout(false);
            this.groudLogin.PerformLayout();
            this.groupInfor.ResumeLayout(false);
            this.groupInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptAvarta)).EndInit();
            this.ChatBox.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RTBRoom;
        private System.Windows.Forms.Button btSend;
        public System.Windows.Forms.ListBox lbfriend;
        private System.Windows.Forms.GroupBox groudLogin;
        private System.Windows.Forms.GroupBox groupInfor;
        private System.Windows.Forms.Button btAddFriend;
        private System.Windows.Forms.TextBox txtAddFriend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl ChatBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox RTBPrivate;
        private System.Windows.Forms.CheckBox cbChatMat;
        private System.Windows.Forms.TextBox RTBText;
        private System.Windows.Forms.Button Logout;
        public IAsyncResult BeginUserLoggedin(string name, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserLoggedin(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserloggedout(string name, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserloggedout(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginSendMessageAddFriend(string username, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndSendMessageAddFriend(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginAddFriendMessageResult(string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndAddFriendMessageResult(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginNewPublicMessage(ChatMessage CM, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndNewPublicMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginNewPrivateMessage(ChatMessage CM, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndNewPrivateMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiverFile(FileMessage fileMessage, string receiver, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiverFile(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiveMessageBack(string messageContent, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveMessageBack(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ptAvarta;
        private System.Windows.Forms.Timer timer1;
    }
}

