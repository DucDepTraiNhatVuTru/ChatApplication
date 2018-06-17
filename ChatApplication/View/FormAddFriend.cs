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

            _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            LoadForm();
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
