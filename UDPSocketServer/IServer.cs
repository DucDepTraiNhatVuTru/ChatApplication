using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPSocketServer
{
    public interface IServer
    {
        void Start(string ip, int port);
        void Send(EndPoint endpoint, byte[] data);
        event Action<string> OnReceive;
    }
}
