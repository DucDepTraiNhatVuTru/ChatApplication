using ChatProtocol.Protocol;
using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Handle
{
    public interface IHandle
    {
        void Handling(IProtocol protocol, IChatClient client);
    }
}
