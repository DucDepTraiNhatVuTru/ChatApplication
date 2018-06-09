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
using System.Threading;

namespace ChatApplication.View
{
    public partial class FormChat : Form
    {
        private IClient _client;
        private Account _user;
        public List<ChatDataModel.ChatMessage> AllMessage = new List<ChatDataModel.ChatMessage>();
        public event Action<string> OnClose;
        Author authorMe, authorFriend;
        public FormChat()
        {
            InitializeComponent();
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
            //gửi yêu cầu lấy lịch sử chat
            _client.RequestGetHistory(Instance.CurrentUser.Email, _user.Email);
            /*ChatTimeSeparatorItemElement a = new ChatTimeSeparatorItemElement();
            a.Text = "Hú";*/
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

        private void FormChat_Load(object sender, EventArgs e)
        {
            
        }

        public void ReceiveTextMessage(ChatDataModel.ChatMessage message)
        {
            ChatTextMessage mess = new ChatTextMessage(message.Message, authorFriend, message.TimeSend);
            _rcChatlog.AddMessage(mess);
        }

        public void AddMessageHistory()
        {
            var me = Instance.CurrentUser.Email;
            foreach(var item in AllMessage)
            {
                if (item.Sender == me)
                {
                    ChatTextMessage message = new ChatTextMessage(item.Message, authorMe, item.TimeSend);
                    _rcChatlog.AddMessage(message);
                }
                else
                {
                    ChatTextMessage message = new ChatTextMessage(item.Message, authorFriend, item.TimeSend);
                    _rcChatlog.AddMessage(message);
                }
            }
        }
    }
}
