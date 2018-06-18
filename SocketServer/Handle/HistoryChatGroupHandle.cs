using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO.SQL;

namespace ChatProtocol.Handle
{
    public class HistoryChatGroupHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as HistoryChatGroupRequestProtocol;
            var toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] get history with group chat [" + ptc.GroupId + "]";
            try
            {
                var messages = GetMessages(ptc.GroupId);
                if (messages.Count != 0)
                {
                    client.ResponseGetChatGroupHistory(messages);
                    toView += "\n get history successul";
                }
            }
            catch (Exception)
            {
                toView += "\n get history failed";
            }
            return toView;
        }

        private List<ChatGroupMessage> GetMessages(string groupId)
        {
            lock (syncLock)
            {
                IChatGroupMessageDAO db = new ChatGroupMessageDAOSQL();
                return db.GetMessages(groupId);
            }
        }
    }
}
