using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.SimpleTCP
{
    public class SimpleTcpAdapter
    {
        static public IChatClient Convert(TcpClient client)
        {
            return new ClientSimpleTcp(client);
        }
    }
}
