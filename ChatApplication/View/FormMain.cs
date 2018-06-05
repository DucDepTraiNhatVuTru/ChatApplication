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
        private IDictionary<string, FormChat> FormChatOpening = new Dictionary<string, FormChat>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void _radlvFriendList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(((Account)e.Item.DataBoundItem).AvatarDriveID));
                e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 46);
            }
            catch(Exception ex)
            {
                MessageBox.Show("không có kết nổi , xin kiểm tra lại internet!");
                _radlvFriendList_ItemDataBound(sender, e);
            }
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
            _client.OnNewRecieve += _client_OnNewRecieve; _radlvFriendList.AllowEdit = false;
            _client.RequsetGetListFriend(account.Email);
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
            _radlvFriendList.AllowRemove = false;
            _radlvFriendList.ItemSpacing = 5;
            _radlvFriendList.ShowGridLines = true;
            _radlvFriendList.VisualItemCreating += VisualItemCreating;
            _radlvFriendList.ItemDataBound += _radlvFriendList_ItemDataBound;
            _radlvFriendList.ItemSize = new Size(_radlvFriendList.ItemSize.Width, 50);
            _radlvFriendList.ItemMouseClick += _radlvFriendList_ItemMouseClick;
        }

        private void _radlvFriendList_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            var form = GetFormChatOpening(e.Item.Value.ToString());
            if (form!=null)
            {
                form.Invoke(new MethodInvoker(delegate ()
                {
                    form.Focus();
                }));
                return;
            }
            Thread thread = new Thread(delegate ()
            {
                var formChat = new FormChat();
                FormChatOpening.Add(e.Item.Value.ToString(), formChat);
                formChat.ShowDialog();
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

        public void LoadFriendList(List<Account> accounts)
        {
            BindingList<Account> listUser = new BindingList<Account>();
           foreach(var item in accounts)
            {
                listUser.Add(item);
            }
            _radlvFriendList.DataSource = listUser;
            _radlvFriendList.DisplayMember = "Name";
            _radlvFriendList.ValueMember = "Email";
        }

        private FormChat GetFormChatOpening(string key)
        {
            foreach(var item in FormChatOpening)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
