using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StreamProtocol.Protocol;

namespace UDPSocketServer.Handle
{
    public class WatchStreamRequestHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, EndPoint sender, IUDPClient sendback)
        {
            var ptc = protocol as WatchStreamRequestProtocol;
            List<IPEndPoint> listEndPoint = new List<IPEndPoint>();
            lock (synlock)
            {
                foreach(var item in Instance.CurrentStream)
                {
                    if (item.Key == ptc.StreamID)
                        item.Value.Add(sender);
                }
            }

            return null;
        }
    }
}
