using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;
using ChatProtocol.Packet;
using ChatProtocol;
using System.Threading;
using System.IO;

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
            Console.WriteLine("Packet Weight : " + e.Data.Count() + " bytes");
            Thread thread = new Thread(delegate ()
            {
                var tmp = SimpleTcpAdapter.Convert(e.TcpClient);
                var packet = new BasicPacket();
                if (!packet.Parse(e.Data))
                {

                    var packets = SplitPacket(e.Data);
                    foreach (var pk in packets)
                    {
                        Thread.Sleep(50);
                        Thread t = new Thread(delegate ()
                        {
                            var pack = new BasicPacket();
                            if (!pack.Parse(pk))
                                return;
                            var ptc = ProtocolFactory.CreateProtocol(pack.Opcode);
                            if (!ptc.Parse(Encoding.Unicode.GetString(pack.Data)))
                                return;
                            var handling = HandleFactory.CreateHandle(pack.Opcode);
                            string toview = handling.Handling(ptc, tmp);
                            if (OnNewMessage != null)
                            {
                                OnNewMessage.Invoke(tmp, toview);
                            }
                        });
                        t.Start();
                    }

                    return;
                }
                var protocol = ProtocolFactory.CreateProtocol(packet.Opcode);
                if (!protocol.Parse(Encoding.Unicode.GetString(packet.Data)))
                    return;
                var handle = HandleFactory.CreateHandle(packet.Opcode);
                string toView = handle.Handling(protocol, tmp);
                if (OnNewMessage != null)
                {
                    OnNewMessage.Invoke(tmp, toView);
                }
            });
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
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

        private List<byte[]> SplitPacket(byte[] data)
        {
            var result = new List<byte[]>();
            using (var stream = new MemoryStream(data))
            {
                using (var read = new BinaryReader(stream))
                {
                    while (true)
                    {
                        byte opcode;
                        int length;
                        byte[] dt;
                        try
                        {
                            opcode = read.ReadByte();
                            length = read.ReadInt32();
                            dt = read.ReadBytes(length);
                        }
                        catch(Exception)
                        {
                            return result;
                        }
                        

                        result.Add(BasicPacket.ToByte(opcode, length, dt));
                        if (stream.Length <= 1) return result;
                    }
                }
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
