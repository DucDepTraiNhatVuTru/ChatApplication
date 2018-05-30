using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using SimpleTCP;
using ChatProtocol.Protocol;
using ChatProtocol.Packet;

namespace ClientSocket.SimpleTcp
{
    public class SimpleTCPClient : IClient
    {
        private SimpleTcpClient _client;
        public event Action<string> OnNewRecieve;

        public SimpleTCPClient()
        {
            _client = new SimpleTcpClient();
        }

        public void Connect(string ip, int port)
        {
            try
            {
                _client.Connect(ip, port);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        public void Send(string data)
        {
            _client.WriteLine(data);
        }

        public void RequestCreateAccount(Account account)
        {
            CreateAccountProtocol ptc = new CreateAccountProtocol();
            ptc.Account = account;
            BasicPacket packet = new BasicPacket();
            packet.Opcode = 1;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }
    }
}
