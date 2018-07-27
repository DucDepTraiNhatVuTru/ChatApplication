using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPSocketServer
{
    public interface IUDPClient
    {
        void ResponseStartStreamRequest(string stream, EndPoint client);
        void SendStream(string streamID, byte[] image, byte[] sound, EndPoint client);
    }
}
