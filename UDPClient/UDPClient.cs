using StreamProtocol;
using StreamProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPClient
{
    public class UDPClient : IClient
    {
        private UdpClient _client;

        public UDPClient()
        {
            _client = new UdpClient();
        }
        public void Receive()
        {
            Thread thread = new Thread(delegate ()
            {
                while (true)
                {
                    byte[] data = new byte[1];
                    IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                    data = _client.Receive(ref remote);
                }
            });
            thread.Start();
        }

        public void RequestStartStream(string streamID, IPEndPoint server)
        {
            StartStreamRequestProtocol ptc = new StartStreamRequestProtocol();
            ptc.StreamID = streamID;
            Send(server, ptc.ToBytes());
        }

        public void Send(IPEndPoint endpoint,byte[] data)
        {
            _client.Send(data, data.Length, endpoint);
        }

        private void Receive(byte[] data)
        {
            StreamPacket packet = new StreamPacket();
            if (!packet.Parse(data)) return;
            var protocol = ProtocolFactory.CreateProtocol(packet.Opcode);
            if (!protocol.Parse(packet.Data)) return;
            //viết 1 cái Handle cho client
        }
    }
}
