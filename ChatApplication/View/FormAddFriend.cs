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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class FormAddFriend : Form
    {
        private IClient _client;
        private Account _account;
        private Account _me;
        private Image _avatar;
        private bool _isSendFriendRequest = false;
        public FormAddFriend()
        {
            InitializeComponent();
        }

        public FormAddFriend(IClient client,Account account, Image image)
        {
            InitializeComponent();
            _client = client;
            _account = account;
            _avatar = image;

            _isSendFriendRequest = CheckIsSendFriendRequest(_account);

            if (_isSendFriendRequest)
            {
                _btnAddFriend.Text = "Hủy lời mời kết bạn";
                _lbThongBao.Text = "bạn đã gửi lời mời kết bạn cho " + _account.Name;
            }

            lock (this) { _me = Instance.CurrentUser; }

            _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            _btnAddFriend.Click += _btnAddFriend_Click;

            LoadForm();
        }

        private void _btnAddFriend_Click(object sender, EventArgs e)
        {
            if (!_isSendFriendRequest)
            {
                _client.SendFriendRequest(_me.Email, _account.Email);
                if (MessageBox.Show("Đã gửi yêu cầu kết bạn!", "Thông báo") == DialogResult.OK)
                {
                    this.Close();
                }
                _isSendFriendRequest = true;
            }
            else
            {
                _client.RequestDeleteFriendInvatation(_me.Email, _account.Email);
                _lbThongBao.Text = "";
                _btnAddFriend.Text = "Gửi lời mời kết bạn";
                _isSendFriendRequest = false;
            }
        }

        private void LoadForm()
        {
            _ptbAvatar.Image = _avatar;
            _lbName.Text = _account.Name;
            _lbGender.Text = _account.Gender;
            _lbCreateTime.Text = _account.TimeCreate.ToString();
        }

        private bool CheckIsSendFriendRequest(Account account)
        {
            foreach(var item in Instance.ListUserAskAddFriend)
            {
                if (account.Email == item.Email)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
