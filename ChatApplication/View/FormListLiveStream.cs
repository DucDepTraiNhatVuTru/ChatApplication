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
using PhoneCall;
using PhoneCall.Ozeki;
using ClientSocket;
using ChatDataModel;

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

            //Request lấy những người đang live là bạn bè của mình
        }

        private void _btnStream_Click(object sender, EventArgs e)
        {
            _client.RequestCreateLiveStream(_me.Email);
        }

        public void StartLiveStream(string streamId)
        {
            Thread thread = new Thread(delegate ()
            {
                ILiveStream stream = new OzekiLiveStream();
                stream.Register(streamId);
                stream.StartStream();
            });
            thread.Start();
        }
    }
}
