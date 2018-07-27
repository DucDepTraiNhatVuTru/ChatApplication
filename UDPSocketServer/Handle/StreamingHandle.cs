using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StreamProtocol.Protocol;

namespace UDPSocketServer.Handle
{
    public class StreamingHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, EndPoint sender, IUDPClient sendback)
        {
            var ptc = protocol as StreamingProtocol;
            List<EndPoint> watcher = new List<EndPoint>();
            lock (synlock)
            {
                if (!Instance.CurrentStream.TryGetValue(ptc.StreamID, out watcher))
                    return null;
            }

            if (watcher.Count==0)
            {
                return null;
            }

            foreach(var item in watcher)
            {
                sendback.SendStream(ptc.StreamID, ptc.Image, ptc.Sound, item);
            }
            return null;
        }
    }
}
