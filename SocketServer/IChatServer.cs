using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public interface IChatServer
    {
        void Start(string ip, int port);
        IDictionary<string, IChatClient> Clients { get; }
        void Stop();

    }
}
