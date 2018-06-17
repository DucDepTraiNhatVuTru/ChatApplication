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
    public partial class FormFindFriends : Form
    {
        private IClient _client;
        private Account _me;
        public FormFindFriends()
        {
            InitializeComponent();
        }

        public FormFindFriends(IClient client)
        {
            InitializeComponent();

            _client = client;
            _client.OnNewRecieve += _client_OnNewRecieve;

            lock (this)
            {
                _me = Instance.CurrentUser;
            }

            InitListUser();
        }

        private void _client_OnNewRecieve(byte opcode, ChatProtocol.Protocol.IProtocol ptc)
        {
            Thread thread = new Thread(delegate ()
            {
                var handle = ChatApplication.Handle.HandleFactory.CreateHandle(opcode);
                handle.Handling(ptc, this);
            });
            thread.Start();
        }

        private void InitListUser()
        {
            _radLVSearchResult.AllowEdit = false;
            _radLVSearchResult.AllowRemove = false;
            _radLVSearchResult.ItemSize = new Size(_radLVSearchResult.Size.Width - 3, 45);
            _radLVSearchResult.ItemDataBound += _radLVSearchResult_ItemDataBound;
            _radLVSearchResult.ItemMouseClick += _radLVSearchResult_ItemMouseClick;
        }

        private void _radLVSearchResult_ItemMouseClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            FormAddFriend formAddFriend = new FormAddFriend(_client, (Account)e.Item.DataBoundItem, e.Item.Image);
            formAddFriend.ShowDialog();
        }

        private void _radLVSearchResult_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                var image = GoogleDriveApiv3.GoogleDriveFilesRepository.DownloadFile(((Account)e.Item.DataBoundItem).AvatarDriveID);
                _radLVSearchResult.Invoke(new MethodInvoker(delegate ()
                {
                    e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(Image.FromStream(image), 46);
                }));
            });
            thread.Start();
        }

        private void _btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_txtSearch.Text))
            {
                MessageBox.Show("Nhập tên hoặc email người bạn cần tìm!");
                return;
            }
            _client.RequestFindFriend(_me.Email, _txtSearch.Text);
        }

        public void LoadUserResult(List<Account> accounts)
        {
            BindingList<Account> list = new BindingList<Account>();
            foreach(var item in accounts)
            {
                list.Add(item);
            }
            _radLVSearchResult.DataSource = list;
            _radLVSearchResult.DisplayMember = "Name";
            _radLVSearchResult.ValueMember = "Id";
        }
    }
}
