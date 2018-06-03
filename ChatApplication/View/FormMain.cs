using ChatApplication.Custom;
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
using Telerik.WinControls.UI;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.Primitives;
using System.IO;

namespace ChatApplication.View
{
    public partial class FormMain : Form
    {
        private IClient _client;
        private Account _account;
        public FormMain()
        {
            InitializeComponent();
            _radlvFriendList.AllowEdit = false;
            _radlvFriendList.AllowRemove = false;
            _radlvFriendList.ItemSpacing = 5;
            _radlvFriendList.ShowGridLines = true;
            _radlvFriendList.VisualItemCreating += VisualItemCreating;
            _radlvFriendList.ItemDataBound += _radlvFriendList_ItemDataBound;
            
            _radlvFriendList.ItemSize = new Size(_radlvFriendList.ItemSize.Width, 50);
            BindingList<User> listUser = new BindingList<User>();
            for (int i = 0; i < 10; i++)
            {
                listUser.Add(new User(Image.FromFile(Path.Combine(@"D:\ThucTap","avartar.jpg")),"Minh Đức"));
            }
            _radlvFriendList.DataSource = listUser;
            _radlvFriendList.DisplayMember = "Name";
        }

        private void _radlvFriendList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(((User)e.Item.DataBoundItem).Avatar,46);
        }

        void VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
           // e.VisualItem = new CustomItemListFriends();
        }

        public FormMain(IClient client, Account account)
        {
            
            InitializeComponent();
            _client = client;
            _account = account;
            Init();
            _client.OnNewRecieve += _client_OnNewRecieve;
            
        }

        private void _client_OnNewRecieve(byte opcode, ChatProtocol.Protocol.IProtocol ptc)
        {
            var handle = ChatApplication.Handle.HandleFactory.CreateHandle(opcode);
            handle.Handling(ptc, this);
        }

        private void Init()
        {
            _ptbChinhSua.BackColor = Color.FromArgb(0, 255, 255, 255);
            _ptbChinhSua.SizeMode = PictureBoxSizeMode.StretchImage;
            _lbUserName.Text = _account.Name;
            Thread thread = new Thread(delegate ()
            {
                var file = GoogleDriveFilesRepository.DownloadFile(_account.AvatarDriveID);
                _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                _ptbAvatar.Image = Image.FromStream(file);
            });
            thread.Start();
        }
        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FindForm().Close();
        }
        
        private void _ptbChinhSua_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose Image";
            dialog.Filter= "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.InitialDirectory + @"\" + dialog.FileName;
                var fileID = GoogleDriveFilesRepository.UploadFile(path.Substring(1));
                _client.RequestUpdateAvatar(_account.Email, fileID);
            }
        }

        public void UpdateAvatar(string driveFileId)
        {
            Thread thread = new Thread(delegate ()
            {
                var file = GoogleDriveFilesRepository.DownloadFile(driveFileId);
                _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                _ptbAvatar.Image = Image.FromStream(file);
            });
            thread.Start();
        }

        public PictureBox GetPictureBoxAvatar()
        {
            return _ptbAvatar;
        }
    }
}
