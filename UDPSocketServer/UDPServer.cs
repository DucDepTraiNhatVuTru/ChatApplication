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
using UDPSocketServer.Handle;

namespace UDPSocketServer
{
    public class UDPServer : IServer
    {
        private IPEndPoint _ipEndPoint;
        private Socket _socket;

        public event Action<string> OnReceive;

        public void Start(string ip, int port)
        {
            _ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            _socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            _socket.Bind(_ipEndPoint);
        }

        public void Send(EndPoint endpoint,byte[] data)
        {
            _socket.SendTo(data, data.Length, SocketFlags.None, endpoint);
        }

        public void Recieve()
        {
            Thread thread = new Thread(delegate ()
            {
                while (true)
                {
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint endpoint = (EndPoint)(sender);
                    byte[] data = new byte[1024];
                    int length = _socket.ReceiveFrom(data, ref endpoint);
                    NewRecieve(data, endpoint);
                }
            });
            thread.Start();
        }

        public void NewRecieve(byte[] data, EndPoint endpoint)
        {
            StreamPacket packet = new StreamPacket();
            if (!packet.Parse(data)) return;
            var protocol = ProtocolFactory.CreateProtocol(packet.Opcode);
            if (!protocol.Parse(packet.Data)) return;
            //viết một cái parse với đầu vào là byte[]
            var handle = HandleFactory.CreateHandle(packet.Opcode);
            var toview = handle.Handling(protocol, endpoint);
            if (OnReceive != null)
                OnReceive.Invoke(toview);
        }
    }
}
