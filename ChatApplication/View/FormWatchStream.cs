using ChatApplication.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class FormWatchStream : Form
    {
        private ClientSocket.IClient _client;
        private string _streamID = "";
        private UDPClient.IClient _udpClient;
        private IPEndPoint _streamServer;
        public FormWatchStream()
        {
            InitializeComponent();
            _streamServer = ServerInfo.StreamServer;
            _udpClient = new UDPClient.UDPClient();
            _udpClient.NewDataReceive += _udpClient_NewDataReceive;
            _udpClient.RequestStartStream("abc", _streamServer);
        }

        public FormWatchStream(ClientSocket.IClient client , string streamId)
        {
            _client = client;
            _streamID = streamId;
            _streamServer = ServerInfo.StreamServer;
            _udpClient = new UDPClient.UDPClient();
            _udpClient.Receive();
            _udpClient.NewDataReceive += _udpClient_NewDataReceive;
            _udpClient.RequestStartStream(_streamID, _streamServer);
            InitializeComponent();
        }

        private void _udpClient_NewDataReceive(StreamProtocol.Protocol.IProtocol ptc, byte opcode)
        {
            Thread thread = new Thread(delegate ()
            {
                var handle = StreamHandle.StreamHandleFactory.CreateHandle(opcode);
                handle.Handling(ptc, this);
            });
            thread.Start();
        }

        private void FormWatchStream_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gửi request stop watch stream
        }

        public bool IsStream(string streamID)
        {
            if (_streamID == streamID) return true;
            return false;
        }

        public void Render(byte[] image, byte[] sound)
        {
            _ptbVideoView.Image = ImageConverter.ImageConverter.CovertByteArrayToImage(image);
        }
    }
}
