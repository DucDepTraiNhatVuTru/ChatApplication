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
using ChatDataModel;
using GoogleDriveApiv3;
using ChatApplication.Util;
using System.IO;

namespace ChatApplication.View
{
    public partial class FormChat : Form
    {
        private IClient _client;
        private Account _user;
        public event Action<string> OnClose;
        Author authorMe, authorFriend;
        string data = "";
        public FormChat()
        {
            //_client.Connect("127.0.0.1", 2018);
            InitializeComponent();
            
            //_rcChatlog.ChatElement.SendButtonElement.
            //_rcChatlog.AutoAddUserMessages = false;
            //Bitmap bm = new Bitmap(Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg"));
            //_rcChatlog.Author.Avatar = bm;
            /*RadImageItem img = new RadImageItem();
            img.Image = Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg");*/
        }

        public FormChat(IClient client, Account account)
        {
            InitializeComponent();
            _client = client;
            _user = account;
            Stream imageMe,imageFriend;
            string myName = "";
            lock (this)
            {
                imageMe = GoogleDriveFilesRepository.DownloadFile(Instance.CurrentUser.AvatarDriveID);
                myName = Instance.CurrentUser.Name;
            }
            imageFriend = GoogleDriveFilesRepository.DownloadFile(_user.AvatarDriveID);
            authorMe = new Author(Image.FromStream(imageMe), myName);
            authorFriend = new Author(Image.FromStream(imageFriend), _user.Name);
            _rcChatlog.Author = authorMe;
        }

        private void _rcChatlog_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage mesage = e.Message as ChatTextMessage;
            _client.SendMessage(new ChatDataModel.ChatMessage(Instance.CurrentUser.Email, _user.Email, mesage.Message, "", mesage.TimeStamp));
        }

        private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnClose != null)
                OnClose.Invoke(_user.Email);
        }

        public void ReceiveTextMessage(ChatDataModel.ChatMessage message)
        {
            ChatTextMessage mess = new ChatTextMessage(message.Message, authorFriend, message.TimeSend);
            _rcChatlog.AddMessage(mess);
        }
    }
}
