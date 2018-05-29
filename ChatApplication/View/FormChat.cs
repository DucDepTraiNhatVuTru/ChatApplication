using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ClientSocket;
using ClientSocket.SimpleTcp;

namespace ChatApplication.View
{
    public partial class FormChat : Form
    {
        private IClient _client = new SimpleTCPClient();
        Author author = new Author(null, "Đức");
        string data = "";
        public FormChat()
        {
            _client.Connect("127.0.0.1", 2018);
            InitializeComponent();
            _rcChatlog.ChatElement.SendButtonElement.Click += SendButtonElement_Click;
            
            //_rcChatlog.ChatElement.SendButtonElement.
            //_rcChatlog.AutoAddUserMessages = false;
            _rcChatlog.Author = author;
            //Bitmap bm = new Bitmap(Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg"));
            //_rcChatlog.Author.Avatar = bm;
            /*RadImageItem img = new RadImageItem();
            img.Image = Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg");*/
            _rcChatlog.ChatElement.InputTextBox.TextChanged += InputTextBox_TextChanged;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void SendButtonElement_Click(object sender, EventArgs e)
        {
        }

        private void _rcChatlog_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage mesage = e.Message as ChatTextMessage;
            _client.Send(mesage.Message);
        }
    }
}
