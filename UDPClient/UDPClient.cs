using StreamProtocol;
using StreamProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
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
        public event Action<IProtocol, byte> NewDataReceive;

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
            SendPacket(1, server, ptc.ToBytes());
        }

        private void SendPacket(byte opcode,IPEndPoint server, byte[] data)
        {
            StreamPacket packet = new StreamPacket();
            packet.Opcode = opcode;
            packet.Data = data;
            if (data.Length > 500)
            {
                var tachgoi = SplitByteArray(data);

                //sửa lại cái StreamPacket.
            }
            _client.Send(packet.ToBytes(), packet.ToBytes().Length, server);
        }


        //cắt mảng byte lớn thành danh sách các mảng có độ dài nhỏ hơn 500
        private List<byte[]> SplitByteArray(byte[] data)
        {
            int length = data.Length;
            int index = 0;
            int count = 500;
            List<byte[]> result = new List<byte[]>();
            while (length >= 0)
            {
                using(var stream = new MemoryStream())
                {
                    using(var writer = new BinaryWriter(stream))
                    {
                        writer.Write(data, index, count);
                        result.Add(stream.ToArray());
                        index += count;
                        length -= count;
                        if (length < 500)
                        {
                            count = length;
                        }
                    }
                }
            }
            return result;
        }

        private byte[] ToBytes(byte[] data)
        {
            return null;
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
            if (NewDataReceive != null)
            {
                NewDataReceive.Invoke(protocol, packet.Opcode);
            }
        }

        public void SendStream(string streamID, byte[] image, byte[] sound, IPEndPoint server)
        {
            StreamingProtocol protocol = new StreamingProtocol();
            protocol.Image = image;
            protocol.Sound = sound;
            protocol.StreamID = streamID;
            SendPacket(2, server, protocol.ToBytes());
        }
    }
}
