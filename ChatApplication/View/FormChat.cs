﻿using System;
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
using Ozeki.VoIP;
using PhoneCall;

namespace ChatApplication.View
{
    public partial class FormChat : Form
    {
        private IClient _client;
        private ChatDataModel.Account _user;
        public List<ChatDataModel.ChatMessage> AllMessage = new List<ChatDataModel.ChatMessage>();
        public event Action<string> OnClose;
        Author authorMe, authorFriend;
        private string mediaMessageDriveId = "";
        private Image imageWillSend;
        private FormChung.Picture controlsAdded;
        private bool _isGotHistory = false;
        public List<ChatDataModel.ChatMessage> Messages = new List<ChatDataModel.ChatMessage>();
        private RadWaitingBar waitingBarControl = null;
        IAudioCall _phoneCall;
        FormCall _formCall = null;
        FormInComingCall _currentFormInCommingCall = null;
        public bool IsGotHistory
        {
            get
            {
                return _isGotHistory;
            }
            set
            {
                _isGotHistory = value;
                if (IsGotHistoryChange != null)
                    IsGotHistoryChange(null, EventArgs.Empty);
            }
        } 
        public event EventHandler IsGotHistoryChange;
        public FormChat()
        {
            InitializeComponent();
        }

        public FormChat(IClient client, ChatDataModel.Account account, IAudioCall phoneCall)
        {
            InitializeComponent();
            _client = client;
            _user = account;
            Stream imageMe,imageFriend;
            string myName = "";
            lock (this)
            {
                imageMe = GoogleDriveFilesRepository.DownloadFile(Util.Instance.CurrentUser.AvatarDriveID);
                myName = Util.Instance.CurrentUser.Name;
            }
            imageFriend = GoogleDriveFilesRepository.DownloadFile(_user.AvatarDriveID);
            _ptbFriendsAvatar.Image = Image.FromStream(imageFriend);
            _ptbFriendsAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            _lbFriendsName.Text = _user.Name;
            authorMe = new Author(Image.FromStream(imageMe), myName);
            authorFriend = new Author(Image.FromStream(imageFriend), _user.Name);
            _rcChatlog.Author = authorMe;
            //gửi yêu cầu lấy lịch sử chat
            _client.RequestGetHistory(Util.Instance.CurrentUser.Email, _user.Email);
            _rcChatlog.ChatElement.ShowToolbarButtonElement.Click += ShowToolbarButtonElement_Click;
            _rcChatlog.ChatElement.SendButtonElement.Click += SendButtonElement_Click;
            _rcChatlog.CardActionClicked += _rcChatlog_CardActionClicked;
            _rcChatlog.ChatElement.MessagesViewElement.BackColor = Color.White;
            _rcChatlog.AutoScroll = false;

            _phoneCall = phoneCall;
            _phoneCall.CallStateChange += _phoneCall_CallStateChange;
        }

        private void _rcChatlog_CardActionClicked(object sender, CardActionEventArgs e)
        {
            if (e.Action.Text == "Call")
            {
                VideoCall(e.UserData.ToString());
            }
        }

        private void _phoneCall_CallStateChange(MyCallState state)
        {
            if (state == MyCallState.Busy)
            {
                _client.SendMessage(new ChatDataModel.ChatMessage(Util.Instance.CurrentUser.Email, _user.Email, "", "", new Call(Guid.NewGuid().ToString(), 0, false), DateTime.Now));
                _formCall.Close();
            }
            else if (state == MyCallState.CallEnd)
            {
                _client.SendMessage(new ChatDataModel.ChatMessage(Util.Instance.CurrentUser.Email, _user.Email, "", "", new Call(Guid.NewGuid().ToString(), _phoneCall.GetDuration(), true), DateTime.Now));
            }
        }

        private void SendButtonElement_Click(object sender, EventArgs e)
        {
            /*
            if (mediaMessageDriveId != "")
            {
                ChatMediaMessage message = new ChatMediaMessage(imageWillSend, new Size(128, 128), null, authorMe, DateTime.Now);
                _client.SendMessage(new ChatDataModel.ChatMessage(Util.Instance.CurrentUser.Email, _user.Email, "", mediaMessageDriveId, DateTime.Now));
                _rcChatlog.AddMessage(message);
                mediaMessageDriveId = "";
                _rcChatlog.Controls.Remove(controlsAdded);
                _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Enabled = true;
                _rcChatlog.ChatElement.InputTextBox.TextBoxItem.Text = "";
            }
            */
        }

        private void ShowToolbarButtonElement_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose Image";
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.InitialDirectory + @"\" + dialog.FileName;
                var fileID = GoogleDriveFilesRepository.UploadFile(path.Substring(1));
                var image = Image.FromFile(Path.Combine(dialog.InitialDirectory, dialog.FileName));
                var displayImage = ResizeImagePercentage(image);
                ChatMediaMessage message = new ChatMediaMessage(displayImage, displayImage.Size, null, authorMe, DateTime.Now);
                _rcChatlog.AddMessage(message);
                _client.SendMessage(new ChatDataModel.ChatMessage(Util.Instance.CurrentUser.Email, _user.Email, "", fileID,null, DateTime.Now));
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
            _client.SendMessage(new ChatDataModel.ChatMessage(Util.Instance.CurrentUser.Email, _user.Email, mesage.Message, "",null, mesage.TimeStamp));
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
                ChatMediaMessage mess = new ChatMediaMessage(img, new Size(128, 128), null, authorFriend, message.TimeSend);
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
            var displayImage = ResizeImagePercentage(img);
            ChatMediaMessage mess = new ChatMediaMessage(displayImage, displayImage.Size, null, authorFriend, message.TimeSend);
            _rcChatlog.AddMessage(mess);
        }

        private void _ptbCall_Click(object sender, EventArgs e)
        {
            try
            {
                var tach = _user.Email.Split('@');
                _phoneCall.CreateCall(tach[0]);
                _phoneCall.ModifyCallStyle(MyCallStyle.Audio);
                _phoneCall.ShowFormCall();
            }
            catch (Exception)
            {

                throw;
            }
            Thread thread = new Thread(delegate ()
            {
                var formCall = new FormCall(_phoneCall, _user);
                _formCall = formCall;
                formCall.ShowDialog();
            });
            thread.Start();
        }

        public void AddMessageHistory()
        {
            var me = Util.Instance.CurrentUser.Email;
            foreach(var item in AllMessage)
            {
                if (item.ImageMessageDriveID != "")
                {
                    var image = GoogleDriveFilesRepository.DownloadFile(item.ImageMessageDriveID);
                    var displayImage = ResizeImagePercentage(Image.FromStream(image));
                    if (item.Sender == me)
                    {
                        ChatMediaMessage message = new ChatMediaMessage(displayImage, displayImage.Size,null, authorMe, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                    else
                    {
                        ChatMediaMessage message = new ChatMediaMessage(displayImage, displayImage.Size, null, authorFriend, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                }
                else if(item.Message!="")
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
                else if (item.Call != null)
                {
                    var tittle = "";
                    if (item.Call.Called) tittle = "Cuộc gọi";
                    else tittle = "Cuộc gọi nhỡ";
                    List<ChatCardAction> actions = new List<ChatCardAction>();
                    actions.Add(new ChatCardAction("Call"));
                    if (item.Sender == me)
                    {
                        ChatImageCardDataItem card = new ChatImageCardDataItem(null, tittle, "bạn & " + authorFriend.Name, TimeSpan.FromSeconds(item.Call.Duration).ToString(@"mm\:ss"), actions, item.Receiver);
                        ChatCardMessage message = new ChatCardMessage(card, authorMe, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                    else
                    {
                        ChatImageCardDataItem card = new ChatImageCardDataItem(null, tittle, "bạn & " + authorFriend.Name, TimeSpan.FromSeconds(item.Call.Duration).ToString(@"mm\:ss"), actions, item.Sender);
                        ChatCardMessage message = new ChatCardMessage(card, authorFriend, item.TimeSend);
                        _rcChatlog.AddMessage(message);
                    }
                }
            }
        }

        public void AddWaitingBar()
        {
            Thread thread = new Thread(delegate ()
            {
                RadWaitingBar waitingBar = new RadWaitingBar();
                waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
                waitingBar.Size = new Size(_rcChatlog.Size.Width, _rcChatlog.Height);
                waitingBar.WaitingSpeed = 10;
                waitingBar.BackColor = Color.White;
                waitingBarControl = waitingBar;
                _rcChatlog.Invoke(new MethodInvoker(delegate ()
                {
                    _rcChatlog.Controls.Add(waitingBar);
                    waitingBar.StartWaiting();
                }));
            });
            thread.Start();
        }

        private void _ptbVideoCall_Click(object sender, EventArgs e)
        {
            var tach = _user.Email.Split('@');
            VideoCall(tach[0]);
        }

        private void VideoCall(string dial)
        {
            Thread thread = new Thread(delegate ()
            {
                if (!_phoneCall.StartCamera()) { return; }
                try
                {
                    _phoneCall.CreateCall(dial);
                }
                catch 
                {
                    MessageBox.Show("Hiện tại không thể thực hiện cuộc gọi với người dùng", "Thông báo");
                }
                
                _phoneCall.ConnectMedia();
                _phoneCall.ModifyCallStyle(MyCallStyle.AudioVideo);
                _phoneCall.ShowFormCall();
                _phoneCall.IsShowFormCall = true;
            });
            thread.Start();
        }

        private void _rcChatlog_Click(object sender, EventArgs e)
        {

        }

        public void RemoveWaitingBar()
        {
            _rcChatlog.Controls.Remove(waitingBarControl);
        }

        public Image ResizeImagePercentage(Image image)
        {
            if (image.Size.Width > 256 || image.Size.Height > 256)
            {
                float percentage = (float)256 / Math.Max(image.Size.Width, image.Size.Height);
                return ImageConverter.ImageResize.ResizeImagePercentage(image, percentage);
            }
            return image;
        }
    }
}
