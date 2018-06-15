using ChatDataModel;
using ClientSocket;
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

namespace ChatApplication.View
{
    public partial class FormCreateGroup : Form
    {
        private IClient _client;
        private List<Account> _listFriend = new List<Account>();

        public FormCreateGroup()
        {
            InitializeComponent();
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
    }
}
