﻿using ChatApplication.Util;
using ChatDataModel;
using ClientSocket;
using GoogleDriveApiv3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ChatApplication.View
{
    public partial class FormChatGroups : Form
    {
        private IClient _client;
        private Group _group;
        private Author _authorMe;
        private Account _me;
        private IDictionary<string, Author> _authorFriends = new Dictionary<string, Author>();
        private List<Account> _userInGroup = new List<Account>();
        public List<ChatGroupMessage> messages = new List<ChatGroupMessage>();
        private RadWaitingBar waitingBar;
        private bool _isLoadHistory = false;
        public FormChatGroups()
        {
            InitializeComponent();
        }

        public FormChatGroups(IClient client, Group group)
        {
            InitializeComponent();
            _client = client;
            _group = group;
            _lbGroupName.Text = group.Name;
            lock (this)
            {
                _me = Instance.CurrentUser;
            }
            _authorMe = new Author(null, _me.Name);
            LoadMyAvatar(_me.AvatarDriveID);
            //AddWaitingBar();
            _client.RequestGetUserInGroup(_me.Email, _group.Id);
            InitLV();
            _radchatChatGroup.Author = _authorMe;
            _radchatChatGroup.SendMessage += _radchatChatGroup_SendMessage;
            _radchatChatGroup.ChatElement.ShowToolbarButtonElement.Click += ShowToolbarButtonElement_Click;
            _btnAddUserToGroup.Click += _btnAddUserToGroup_Click;
        }

        private void _btnAddUserToGroup_Click(object sender, EventArgs e)
        {
            FormAddUserToGroup form = new FormAddUserToGroup(_client, _group);
            form.ShowDialog();
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
                _client.SendGroupMessage(new ChatGroupMessage(_me.Email, _group.Id, "", fileID, DateTime.Now));
                var displayImage = Image.FromFile(Path.Combine(dialog.InitialDirectory, dialog.FileName));
                var displayImageResize = ResizeImagePercentage(displayImage);
                ChatMediaMessage message = new ChatMediaMessage(displayImageResize, displayImageResize.Size, null, _authorMe, DateTime.Now);
                _radchatChatGroup.AddMessage(message);
            }
        }

        private void _radchatChatGroup_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage mesage = e.Message as ChatTextMessage;
            _client.SendGroupMessage(new ChatGroupMessage(_me.Email, _group.Id, mesage.Message, "", DateTime.Now));
        }

        private void InitLV()
        {
            _radLVListFriendInGroup.AllowEdit = false;
            _radLVListFriendInGroup.ItemSize = new Size(_radLVListFriendInGroup.Size.Width, 26);
            _radLVListFriendInGroup.ItemDataBound += _radLVListFriendInGroup_ItemDataBound;
        }

        private void _radLVListFriendInGroup_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
              Thread thread = new Thread(delegate ()
                {
                    var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(((Account)e.Item.DataBoundItem).AvatarDriveID));
                    lock (this)
                    {
                        _authorFriends.Add(((Account)e.Item.DataBoundItem).Email, new Author(image, ((Account)e.Item.DataBoundItem).Name));
                    }
            _radLVListFriendInGroup.Invoke(new MethodInvoker(delegate ()
            {
                e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 23);
            }));
                });
            thread.Start();
        }

        private void LoadMyAvatar(string fileId)
        {
            Stream result = null;
            Thread thread = new Thread(delegate ()
            {
                result = GoogleDriveFilesRepository.DownloadFile(fileId);
                _authorMe.Avatar = Image.FromStream(result);
            });
            thread.Start();
        }

        public void LoadListUserInGroup(List<Account> accounts)
        {
            _radLVListFriendInGroup.DataSource = null;
            _radLVListFriendInGroup.Items.Clear();
            _authorFriends.Clear();
            _userInGroup = accounts;
            BindingList<Account> listUser = new BindingList<Account>();
            foreach (var item in accounts)
            {
                listUser.Add(item);
            }
            _radLVListFriendInGroup.DataSource = listUser;
            _radLVListFriendInGroup.DisplayMember = "Name";
            _radLVListFriendInGroup.ValueMember = "Id";

            //lấy lịch sử chat
            if (!_isLoadHistory)
            {
                _client.RequestGetHistoryGroupChat(_me.Email, _group.Id);
            }
        }

        public void ReceiveMessage(ChatGroupMessage message)
        {
            Author auth;
            if (!_authorFriends.TryGetValue(message.Sender, out auth)) return;
            if (message.Message != "")
            {
                var mess = new ChatTextMessage(message.Message, auth, message.TimeSend);
                _radchatChatGroup.AddMessage(mess);
            }
            else if (message.ImageMessageDriveId != "")
            {
                var download = GoogleDriveFilesRepository.DownloadFile(message.ImageMessageDriveId);
                var image = Image.FromStream(download);
                var displayImage = ResizeImagePercentage(image);
                var mess = new ChatMediaMessage(displayImage, displayImage.Size, null, auth, message.TimeSend);
                _radchatChatGroup.AddMessage(mess);
            }
        }

        public void LoadHistory()
        {
            foreach(var item in messages)
            {
                if (item.ImageMessageDriveId!="")
                {
                    var download = GoogleDriveFilesRepository.DownloadFile(item.ImageMessageDriveId);
                    var img = ResizeImagePercentage(Image.FromStream(download));
                    
                    if (item.Sender == _me.Email)
                    {
                        ChatMediaMessage mess = new ChatMediaMessage(img, img.Size, "", _authorMe, item.TimeSend);
                        _radchatChatGroup.AddMessage(mess);
                    }
                    else if(item.Sender !=_me.Email)
                    {
                        Author auth;
                        if (_authorFriends.TryGetValue(item.Sender, out auth))
                        {
                            ChatMediaMessage mess = new ChatMediaMessage(img, img.Size, "", auth, item.TimeSend);
                            _radchatChatGroup.AddMessage(mess);
                        }
                    }
                    
                }
                else if (item.Message != "") { 
                    
                    if (item.Sender == _me.Email)
                    {
                        ChatTextMessage mess = new ChatTextMessage(item.Message, _authorMe, item.TimeSend);
                        _radchatChatGroup.AddMessage(mess);
                    }
                    else if(item.Sender == _me.Email)
                    {
                        Author auth;
                        if (_authorFriends.TryGetValue(item.Sender, out auth))
                        {
                            ChatTextMessage mess = new ChatTextMessage(item.Message, auth, item.TimeSend);
                            _radchatChatGroup.AddMessage(mess);
                        }
                    }
                    
                }
            }
            _isLoadHistory = true;
            //_radchatChatGroup.Controls.Remove(waitingBar);
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

        public void AddWaitingBar()
        {
            Thread thread = new Thread(delegate ()
            {
                waitingBar = new RadWaitingBar();
                waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
                waitingBar.Size = new Size(_radchatChatGroup.Size.Width, _radchatChatGroup.Height);
                waitingBar.WaitingSpeed = 10;
                waitingBar.BackColor = Color.White;
                _radchatChatGroup.Invoke(new MethodInvoker(delegate ()
                {
                    _radchatChatGroup.Controls.Add(waitingBar);
                    waitingBar.StartWaiting();
                }));
            });
            thread.Start();
        }

        private void FormChatGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void RemoveWaitingBar()
        {
            _radchatChatGroup.Controls.Remove(waitingBar);
        }
    }
}
