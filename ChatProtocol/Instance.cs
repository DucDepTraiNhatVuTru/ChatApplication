using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol
{
    public class Instance
    {
        public static IDictionary<string, IChatClient> OnlineUser = new Dictionary<string, IChatClient>();
    }
}
