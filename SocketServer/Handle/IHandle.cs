using ChatProtocol.Protocol;
using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Handle
{
    public interface IHandle
    {
        string Handling(IProtocol protocol, IChatClient client);
        
    }
}
