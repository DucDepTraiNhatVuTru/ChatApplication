using StreamProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    public interface IClient
    {
        event Action<IProtocol,byte> NewDataReceive;
        void Send(IPEndPoint endpoint,byte[] data);
        void Receive();
        void RequestStartStream(string streamID, IPEndPoint server);
        void SendStream(string streamID, byte[] image, byte[] sound, IPEndPoint server);
    }
}
