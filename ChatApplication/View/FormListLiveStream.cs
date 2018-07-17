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
using LiveStream;
using ClientSocket;
using ChatDataModel;
using GoogleDriveApiv3;
using LiveStream.Ozeki;

namespace ChatApplication.View
{
    public partial class FormListLiveStream : Form
    {
        private IClient _client;
        private Account _me;
        public FormListLiveStream()
        {
            InitializeComponent();
        }

        public FormListLiveStream(IClient client)
        {
            InitializeComponent();
            _client = client;
            lock (this)
            {
                _me = Util.Instance.CurrentUser;
            }
            _client.OnNewRecieve += _client_OnNewRecieve;

            _radListFriendStreaming.ItemDataBound += _radListFriendStreaming_ItemDataBound;
            _radListFriendStreaming.ItemSize = new Size(_radListFriendStreaming.Size.Width - 2, 48);
            _radListFriendStreaming.ItemMouseClick += _radListFriendStreaming_ItemMouseClick;
            //Request lấy những người đang live là bạn bè của mình
            _client.RequestGetListFriendStreaming(_me.Email);
        }

        private void _radListFriendStreaming_ItemMouseClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                OzekiLiveStream live = new OzekiLiveStream();
                live.Register(Guid.NewGuid().ToString());
                live.WatchStream(((AccountStream)e.Item.DataBoundItem).StreamID);
            });
            thread.Start();
        }

        private void _radListFriendStreaming_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            try
            {
                Thread thread = new Thread(delegate ()
                {
                    var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(((ChatDataModel.AccountStream)e.Item.DataBoundItem).ImageDriveID));
                    _radListFriendStreaming.Invoke(new MethodInvoker(delegate ()
                    {
                        e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 46);
                    }));
                });
                thread.Start();
            }
            catch
            {
                MessageBox.Show("không có kết nổi , xin kiểm tra lại internet!");
                _radListFriendStreaming_ItemDataBound(sender, e);
            }
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

        private void _btnStream_Click(object sender, EventArgs e)
        {
            _client.RequestCreateLiveStream(_me.Email);
        }

        public void StartLiveStream(string streamId)
        {
            Thread thread = new Thread(delegate ()
            {
                OzekiLiveStream stream = new OzekiLiveStream();
                stream.Register(streamId);
                stream.StartStream();
            });
            thread.Start();
        }

        public void LoadListUser(List<AccountStream> accounts)
        {
            BindingList<ChatDataModel.AccountStream> list = new BindingList<ChatDataModel.AccountStream>();
            foreach (var item in accounts)
            {
                list.Add(item);
            }
            _radListFriendStreaming.DataSource = list;
            _radListFriendStreaming.DisplayMember = "Name";
            _radListFriendStreaming.ValueMember = "StreamID";
        }

        private void _btnRefresh_Click(object sender, EventArgs e)
        {
            _client.RequestGetListFriendStreaming(_me.Email);
        }
    }
}
