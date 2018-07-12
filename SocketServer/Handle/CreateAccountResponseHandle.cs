using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using SocketServer.Handle;

namespace SocketServer.Handle
{
    public class CreateAccountResponseHandle : IHandle
    {
        public string Handling(IProtocol protocol, IChatClient client)
        {
            throw new NotImplementedException();
        }
    }
}
