using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChattingClient
{
    public partial class MessageAddFriendForm : Form
    {
        public MessageAddFriendForm()
        {
            InitializeComponent();
        }

        public static string Username;

        public MessageAddFriendForm(string username)
        {
            InitializeComponent();
            Username = username;
        }

        private void MessageAddFriendForm_Load(object sender, EventArgs e)
        {
            label1.Text = " Lời nhắn với " + Username + ": ";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.MessageAddFriend = richTextBox1.Text;
            this.Close();
            Form1.addFriend();
        }
    }
}
