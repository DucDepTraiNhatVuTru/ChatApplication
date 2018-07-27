using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StreamProtocol.Protocol;

namespace UDPSocketServer.Handle
{
    public class StrartStreamRequestHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, EndPoint sender, IUDPClient sendback)
        {
            var ptc = protocol as StartStreamRequestProtocol;

            lock (synlock)
            {
                Instance.CurrentStream.Add(ptc.StreamID,new List<EndPoint>());
            }

            string toView = "[" + DateTime.Now + "] " + ptc.StreamID + " is streamming ";
            return toView;
        }
    }
}
