using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket
{
    public interface IClient
    {
        void Connect(string ip, int port);
        void Disconnect();
        event Action<string> OnNewRecieve;
    }
}
