using System;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using ChattingClient.ChatServer;
using System.Data.Linq;
using Binary = System.Data.Linq.Binary;

namespace ChattingClient
{
    public partial class Register : Form
    {

        OpenFileDialog _fileDialog = new OpenFileDialog();
        private byte[] file_byte;
        
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ChatClient proxy = Form1.proxy;
               proxy.Register(txtusername.Text, txtpassword.Text, file_byte);
               MessageBox.Show("Đăng Ký Thành Công!");
               this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            _fileDialog.ShowDialog();
            pictureBox1.ImageLocation = _fileDialog.FileName;
            file_byte = ImageToByteArray(Image.FromFile(_fileDialog.FileName));
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
    }
}
