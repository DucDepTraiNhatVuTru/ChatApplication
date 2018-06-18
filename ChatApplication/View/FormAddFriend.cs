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

            lock (this) { _me = Instance.CurrentUser; }

            _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            _btnAddFriend.Click += _btnAddFriend_Click;

            LoadForm();
        }

        private void _btnAddFriend_Click(object sender, EventArgs e)
        {
            _client.SendFriendRequest(_me.Email, _account.Email);
            MessageBox.Show("Đã gửi yêu cầu kết bạn!", "Thông báo");
        }

        private void LoadForm()
        {
            _ptbAvatar.Image = _avatar;
            _lbName.Text = _account.Name;
            _lbGender.Text = _account.Gender;
            _lbCreateTime.Text = _account.TimeCreate.ToString();
        }
    }
}
