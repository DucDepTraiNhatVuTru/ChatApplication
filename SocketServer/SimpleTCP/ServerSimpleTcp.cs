using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using ChatProtocol.Packet;

namespace SocketServer.SimpleTCP
{
    public class ServerSimpleTcp : IChatServer
    {
        private SimpleTcpServer _server;

        public event Action<IChatClient> OnNewConnect;
        public event Action<IChatClient> OnDisconnect;
        public event Action<IChatClient, string> OnNewMessage;

        public ServerSimpleTcp()
        {
            _server = new SimpleTcpServer();
            Clients = new Dictionary<string, IChatClient>();
            _server.ClientConnected += _server_ClientConnected;
            _server.ClientDisconnected += _server_ClientDisconnected;
            _server.DataReceived += _server_DataReceived;
        }

        private void _server_DataReceived(object sender, Message e)
        {
            //xử lý chút ít ở đây
            var packet = new BasicPacket();
            if (!packet.Parse(e.Data))
                return;

        }

        private void _server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            IChatClient tmp;
            if (Clients.TryGetValue(e.Client.RemoteEndPoint.ToString(), out tmp))
            {
                Clients.Remove(e.Client.RemoteEndPoint.ToString());
                if (OnDisconnect != null)
                    OnDisconnect.Invoke(tmp);
            }
        }

        private void _server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            var tmpClient = SimpleTcpAdapter.Convert(e);
            Clients.Add(tmpClient.GetEndPoint().ToString(), tmpClient);
            if (OnNewConnect != null)
            {
                OnNewConnect.Invoke(tmpClient);
            }
        }

        public void Start(string ip, int port)
        {
            try
            {
                IPAddress address = IPAddress.Parse(ip);
                _server.Start(address, port);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public IDictionary<string, IChatClient> Clients
        {
            get;
            private set;
        }

        public void Stop()
        {
            if (_server.IsStarted)
            {
                _server.Stop();
            }
        }
    }
}
