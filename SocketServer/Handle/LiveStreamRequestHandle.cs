using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatProtocol.Ulti;

namespace SocketServer.Handle
{
    public class LiveStreamRequestHandle : IHandle
    {
        private object synclock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as LiveStreamRequestProtocol;
            var toView = new ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "request create a stream video");
            var streamID = Guid.NewGuid().ToString();
            client.ResponseStreamID(streamID);
            lock (synclock)
            {
                Instance.Streaming.Add(streamID, client);
            }
            return toView.ToString();
        }
    }
}
