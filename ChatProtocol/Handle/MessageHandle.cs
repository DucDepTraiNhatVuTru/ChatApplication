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
    public class MessageHandle : IHandle
    {
        private object lockInstance = new object();
        private object syncLockDb = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as MessageProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Message.Sender + "] send a message to [user:" + ptc.Message.Receiver + "]";

            try
            {
                InsertMessage(ptc.Message);
            }
            catch (Exception ex)
            {
                toView += "\n Can't not update this Message to database \n detail : " + ex.Message;
            }

            if (!IsUserOnline(ptc.Message.Receiver))
            {
                lock (lockInstance)
                {
                    Instance.MessageHadNotSended.Add(ptc.Message);
                    return toView;
                }
            }

            GetUserOnline(ptc.Message.Receiver).SendMessage(ptc.Message);
            
            return toView;
        }

        private bool IsUserOnline(string email)
        {
            lock (lockInstance)
            {
                IChatClient receiver = null;
                if (Instance.OnlineUser.TryGetValue(email, out receiver))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        private IChatClient GetUserOnline(string email)
        {
            lock (lockInstance)
            {
                IChatClient receiver = null;
                Instance.OnlineUser.TryGetValue(email, out receiver);
                return receiver;
            }
        }
        private void InsertMessage(ChatMessage message)
        {
            lock (syncLockDb)
            {
                IChatMessageDAO db = new ChatMessageDAOSQL();
                db.Insert(message);
            }
        }
    }
}
