using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO;

namespace ChatProtocol.Handle
{
    public class GetChatHistoryHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as HistoryChatRequestProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.PersonOne + "] get chat history with [user:" + ptc.PersonTwo;
            var history = GetHistory(ptc.PersonOne, ptc.PersonTwo);
            if(history.Count==0)
            {
                toView += "\n Don't have conversation yet";
                return toView;
            }
            client.ResponseGetChatHistory(history);
            toView += "\n Get history successful";
            return toView;
        }

        private List<ChatMessage> GetHistory(string person1, string person2)
        {
            lock (syncLock)
            {
                IChatMessageDAO db = new ChatMessageDAOSQL();
                return db.AllMessage(person1, person2);
            }
        }
    }
}
