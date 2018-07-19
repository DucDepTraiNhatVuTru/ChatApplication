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
        public string Handling(IProtocol protocol, IPEndPoint sender)
        {
            var ptc = protocol as StreamingProtocol;
            List<IPEndPoint> watcher = new List<IPEndPoint>();
            lock (synlock)
            {
                if (!Instance.CurrentStream.TryGetValue(ptc.StreamID, out watcher))
                    return null;
            }

            foreach(var item in watcher)
            {
                //gửi về cho mấy thằng này hình với audio
            }
            return null;
        }
    }
}
