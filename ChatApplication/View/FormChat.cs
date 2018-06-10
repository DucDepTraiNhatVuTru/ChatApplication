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
        private string mediaMessageDriveId = "";
        private Image imageWillSend;
        private FormChung.Picture controlsAdded;
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
            _rcChatlog.ChatElement.ShowToolbarButtonElement.Click += ShowToolbarButtonElement_Click;
            _rcChatlog.ChatElement.SendButtonElement.Click += SendButtonElement_Click;
        }

        private void SendButtonElement_Click(object sender, EventArgs e)
        {/*
            Image temp = null;
            if (imageWillSend.Size.Height > 128 )
            {
                float percentage = 128 / imageWillSend.Size.Height;
                temp = ImageConverter.ImageResize.ResizeImagePercentage(imageWillSend, percentage);
            }
            else if (imageWillSend.Size.Width > 128)
            {
                float percentage = 128 / imageWillSend.Size.Width;
                temp = ImageConverter.ImageResize.ResizeImagePercentage(imageWillSend, percentage);
            }*/
            if (mediaMessageDriveId != "")
            {
                ChatMediaMessage message = new ChatMediaMessage(imageWillSend, new Size(128, 128), null, authorMe, DateTime.Now);
                _client.SendMessage(new ChatDataModel.ChatMessage(Instance.CurrentUser.Email, _user.Email, "", mediaMessageDriveId, DateTime.Now));
                _rcChatlog.AddMessage(message);
                mediaMessageDriveId = "";
                this.Controls.Remove(controlsAdded);
                _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Enabled = true;
                _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Text = "";
            }
        }

        private void ShowToolbarButtonElement_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose Image";
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.InitialDirectory + @"\" + dialog.FileName;
                var fileID = GoogleDriveFilesRepository.UploadFile(path.Substring(1));
                mediaMessageDriveId = fileID;
                /*PictureBox picture = new PictureBox();
                picture.Size = new Size(64, 64);
                picture.Location = new Point(0, _rcChatlog.Size.Height - 30);
                imageWillSend = Image.FromFile(Path.Combine(dialog.InitialDirectory, dialog.FileName));
                picture.Image = imageWillSend;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                controlsAdded = picture;
                this.Size = new Size(this.Size.Width, this.Size.Height + 70);
                _rcChatlog.Controls.Add(picture);*/
                FormChung.Picture picture = new FormChung.Picture();
                picture.Close += Picture_Close;
                picture.Location = new Point(2, _rcChatlog.Size.Height - 80);
                imageWillSend = Image.FromFile(Path.Combine(dialog.InitialDirectory, dialog.FileName));
                picture.AddImage(imageWillSend);
                controlsAdded = picture;
                _rcChatlog.Controls.Add(picture);
                _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Enabled = false;
            }
        }

        private void Picture_Close()
        {
            mediaMessageDriveId = "";
            _rcChatlog.Controls.Remove(controlsAdded);
            _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Enabled = true;
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
            if (!string.IsNullOrEmpty(message.ImageMessageDriveID))
            {
                var stream = GoogleDriveFilesRepository.DownloadFile(message.ImageMessageDriveID);
                var img = Image.FromStream(stream);
                /*if (img.Size.Height > 128)
                {
                    float percentage = 128 / imageWillSend.Size.Height;
                    img = ImageConverter.ImageResize.ResizeImagePercentage(imageWillSend, percentage);
                }
                else if (img.Size.Width > 128)
                {
                    float percentage = 128 / imageWillSend.Size.Width;
                    img = ImageConverter.ImageResize.ResizeImagePercentage(imageWillSend, percentage);
                }*/
                ChatMediaMessage mess = new ChatMediaMessage(img, new Size(128,128), null, authorFriend, message.TimeSend);
                _rcChatlog.AddMessage(mess);
                return;
            }
            else
            {
                ChatTextMessage mess = new ChatTextMessage(message.Message, authorFriend, message.TimeSend);
                _rcChatlog.AddMessage(mess);
            }
        }

        public void ReceiveMediaMessage(ChatDataModel.ChatMessage message)
        {
            var stream = GoogleDriveFilesRepository.DownloadFile(message.ImageMessageDriveID);
            var img = Image.FromStream(stream);
            ChatMediaMessage mess = new ChatMediaMessage(img, img.Size, null, authorFriend, message.TimeSend);
            _rcChatlog.AddMessage(mess);
        }

        public void AddMessageHistory()
        {
            var me = Instance.CurrentUser.Email;
            foreach(var item in AllMessage)
            {
                if (item.ImageMessageDriveID != null)
                {
                    var image = GoogleDriveFilesRepository.DownloadFile(item.ImageMessageDriveID);
                    if (item.Sender == me)
                    {
                        ChatMediaMessage message = new ChatMediaMessage(Image.FromStream(image), new Size(128, 128),null, authorMe, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                    else
                    {
                        ChatMediaMessage message = new ChatMediaMessage(Image.FromStream(image), new Size(128, 128), null, authorFriend, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                }
                else
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
}
