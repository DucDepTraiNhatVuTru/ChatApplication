using ChatApplication.Util;
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
            _client.RequestGetUserInGroup(_me.Email, _group.Id);
            InitLV();
            _radchatChatGroup.Author = _authorMe;
            _radchatChatGroup.SendMessage += _radchatChatGroup_SendMessage;
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
            _userInGroup = accounts;
            BindingList<Account> listUser = new BindingList<Account>();
            foreach (var item in accounts)
            {
                listUser.Add(item);
            }
            _radLVListFriendInGroup.DataSource = listUser;
            _radLVListFriendInGroup.DisplayMember = "Name";
            _radLVListFriendInGroup.ValueMember = "Id";
        }

        public void ReceiveMessage(ChatGroupMessage message)
        {
            Author auth;
            if (!_authorFriends.TryGetValue(message.Sender, out auth)) return;
            var mess = new ChatTextMessage(message.Message, auth, message.TimeSend);
            _radchatChatGroup.AddMessage(mess);
        }
    }
}
