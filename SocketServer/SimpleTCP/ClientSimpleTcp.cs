using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatProtocol.Packet;

namespace SocketServer.SimpleTCP
{
    public class ClientSimpleTcp : IChatClient
    {
        private TcpClient _client;

        public ClientSimpleTcp(TcpClient client)
        {
            this._client = client;
        }

        public void Disconnect()
        {
            if (_client.Connected)
            {
                _client.Close();
            }
        }

        public EndPoint GetEndPoint()
        {
            return _client.Client.RemoteEndPoint;
        }

        public void ResponseCreateAccount(int isSuccess, string message)
        {
            var ptc = new CreateAccountResponseProtocol();
            ptc.IsSuccess = isSuccess;
            ptc.Message = message;
            var packet = new BasicPacket();
            packet.Opcode = 2;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }
    }
}
