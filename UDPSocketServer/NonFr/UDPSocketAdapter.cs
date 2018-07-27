using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPSocketServer.NonFr
{
    public class UDPSocketAdapter
    {
        public static IUDPClient Convert(UdpClient client)
        {
            return new UDPClient(client);
        }
    }
}
