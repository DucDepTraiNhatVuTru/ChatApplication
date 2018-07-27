using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using StreamProtocol;
using StreamProtocol.Protocol;

namespace UDPSocketServer
{
    public class UDPClient : IUDPClient
    {
        private UdpClient _client;
        public UDPClient() { }
        public UDPClient(UdpClient client)
        {
            _client = client;
        }
        public void ResponseStartStreamRequest(string stream, EndPoint client)
        {
            StartStreamRequestProtocol ptc = new StartStreamRequestProtocol();
            ptc.StreamID = stream;
            SendPacket(1,ptc.ToBytes(), client);
        }

        public void SendStream(string streamID, byte[] image, byte[] sound, EndPoint client)
        {
            StreamingProtocol streamProtocol = new StreamingProtocol();
            streamProtocol.Image = image;
            streamProtocol.Sound = sound;
            streamProtocol.StreamID = streamID;
            SendPacket(2, streamProtocol.ToBytes(), client);
        }

        private void SendPacket(byte opcode,byte[] data, EndPoint client)
        {
            StreamPacket packet = new StreamPacket();
            packet.Opcode = opcode;
            packet.Data = data;
            var datas = packet.ToBytes();
            _client.Send(datas, datas.Length, (IPEndPoint)client);
        }
    }
}
