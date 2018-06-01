using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public interface IChatClient
    {
        void Disconnect();
        EndPoint GetEndPoint();
        void ResponseCreateAccount(int isSuccess, string message);
    }
}
