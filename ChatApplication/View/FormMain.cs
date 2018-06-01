using ChatDataModel;
using ClientSocket;
using GoogleDriveApiv3;
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
    public partial class FormMain : Form
    {
        private IClient _client;
        private Account _account;
        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(IClient client, Account account)
        {
            InitializeComponent();
            _client = client;
            _account = account;
            Init();
        }

        private void Init()
        {
            _ptbAvatar.SizeMode = PictureBoxSizeMode.AutoSize;
            _lbUserName.Text = _account.Name;
            Thread thread = new Thread(delegate ()
            {
                _ptbAvatar.Image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(_account.AvatarDriveID));
            });
            thread.Start();
        }
        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
