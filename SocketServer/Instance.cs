using ChatDataModel;
using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Instance
    {
        public static IDictionary<string, IChatClient> OnlineUser = new Dictionary<string, IChatClient>();
        public static List<ChatMessage> MessageHadNotSended = new List<ChatMessage>();
        public static IDictionary<string, IChatClient> Streaming = new Dictionary<string, IChatClient>();
    }
}
