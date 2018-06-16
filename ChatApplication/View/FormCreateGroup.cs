using ChatApplication.Util;
using ChatDataModel;
using ClientSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ChatApplication.View
{
    public partial class FormCreateGroup : Form
    {
        private IClient _client;
        private List<Account> _listFriend = new List<Account>();
        private Account _me;

        public FormCreateGroup()
        {
            InitializeComponent();
        }      

        public FormCreateGroup(IClient client)
        {
            InitializeComponent();
            _client = client;
            lock (this)
            {
                _me = Instance.CurrentUser;
            }
            InitListFriend();
        }

        private void InitListFriend()
        {
            _radLVFriends.AllowEdit = false;
            _radLVFriends.AllowRemove = false;
            _radLVFriends.ItemSize = new Size(_radLVFriends.Size.Width, 35);
            _radLVFriends.ShowCheckBoxes = true;
            lock (this)
            {
                _listFriend = Util.Instance.ListFriends;
            }
            LoadListFriend(_listFriend);
            _radLVFriends.ItemDataBound += _radLVFriends_ItemDataBound;
        }

        private void _radLVFriends_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                var download = GoogleDriveApiv3.GoogleDriveFilesRepository.DownloadFile(((Account)e.Item.DataBoundItem).AvatarDriveID);
                _radLVFriends.Invoke(new MethodInvoker(delegate ()
                {
                    e.Item.Image = Image.FromStream(download);
                }));
            });
        }

        private void LoadListFriend(List<Account> accounts)
        {
            BindingList<Account> listUser = new BindingList<Account>();
            foreach (var item in accounts)
            {
                listUser.Add(item);
            }
            _radLVFriends.DataSource = listUser;
            _radLVFriends.DisplayMember = "Name";
            _radLVFriends.ValueMember = "Id";
        }

        private void _btnCreateGroup_Click(object sender, EventArgs e)
        {
            var groupName = "No Name Yet";
            var listEmail = new List<string>();
            foreach(var item in _radLVFriends.Items)
            {
                listEmail.Add(((Account)item.DataBoundItem).Email);
            }
            if (!string.IsNullOrEmpty(_txtGroupName.Text))
            {
                groupName = _txtGroupName.Text;
            }
            var group = new Group(Guid.NewGuid().ToString(), groupName, _me.Email, DateTime.Now);
            _client.RequestCreateGroupChat(group, listEmail);
        }
    }
}
