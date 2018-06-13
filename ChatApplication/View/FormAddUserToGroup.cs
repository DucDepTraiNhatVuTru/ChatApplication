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

namespace ChatApplication.View
{
    public partial class FormAddUserToGroup : Form
    {
        private IClient _client;
        private List<Account> _listFriend = new List<Account>();
        private List<Account> _listFriendInGroup = new List<Account>();
        private Group _group;
        private Account _me;
        public FormAddUserToGroup()
        {
            InitializeComponent();
        }

        FormAddUserToGroup(IClient client, Group group)
        {
            InitializeComponent();
            _client = client;
            _group = group;
            lock (this)
            {
                _me = Instance.CurrentUser;
            }
            initListFriend();

        }

        public FormAddUserToGroup(IClient client, List<Account> listFriendInGroup)
        {
            InitializeComponent();
            _client = client;
            _listFriendInGroup = listFriendInGroup;
            lock (this)
            {
                _listFriend = Instance.ListFriends;
            }
            initListFriend();
        }

        private void initListFriend()
        {
            _radListFriendToAddToGroup.MultiSelect = true;
            _radListFriendToAddToGroup.AllowRemove = false;
            _radListFriendToAddToGroup.AllowEdit = false;
            _radListFriendToAddToGroup.ItemDataBound += _radListFriendToAddToGroup_ItemDataBound;
            _radListFriendToAddToGroup.ItemSize = new Size(_radListFriendToAddToGroup.ItemSize.Width - 2, 35);
        }

        private void _radListFriendToAddToGroup_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                var file = GoogleDriveApiv3.GoogleDriveFilesRepository.DownloadFile(((Account)e.Item.DataBoundItem).AvatarDriveID);
                _radListFriendToAddToGroup.Invoke(new MethodInvoker(delegate ()
                {
                    e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(Image.FromStream(file),33);
                }));
            });
            thread.Start();
        }

        private List<Account> GetListUserNotInGroup()
        {
            var list = _listFriend;
            if (list.Count == _listFriendInGroup.Count)
            {
                return new List<Account>();
            }
            foreach(var item in _listFriend)
            {
                foreach(var it in _listFriendInGroup)
                {
                    lock (this)
                    {
                        if (item.Email == it.Email)
                        {
                            list.Remove(item);
                            break;
                        }
                    }
                }
            }
            return list;
        }

        private void LoadAccountToListView(List<Account> accounts)
        {
            if (accounts.Count > 0)
            {
                BindingList<Account> listUser = new BindingList<Account>();
                foreach (var item in accounts)
                {
                    listUser.Add(item);
                }
                _radListFriendToAddToGroup.DataSource = listUser;
                _radListFriendToAddToGroup.DisplayMember = "Name";
                _radListFriendToAddToGroup.ValueMember = "Id";
            }
        }
    }
}
