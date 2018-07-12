using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;

namespace SocketServer.Handle
{
    public class LogoutHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as LogoutProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] log out";
            lock (syncLock)
            {
                Instance.OnlineUser.Remove(ptc.Email);
            }
            return toView;
        }
    }
}
