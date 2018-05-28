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

        event Action<IChatClient> OnNewConnect;
        event Action<IChatClient> OnDisconnect;
        event Action<IChatClient, string> OnNewMessage;
        void Stop();

    }
}
