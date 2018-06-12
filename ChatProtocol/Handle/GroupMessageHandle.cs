using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDAO.SQL;
using ChatDataModel;
using ChatDAO;

namespace ChatProtocol.Handle
{
    public class GroupMessageHandle : IHandle
    {
        private object syncLock = new object();
        private object synLock1 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GroupMessageProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.message.Sender + "] send a message to group " + ptc.message.GroupReceive;

            try
            {
                InsertMessage(ptc.message);
            }
            catch (Exception ex)
            {
                toView += "\n insert group message failed!";
            }

            var accounts = GetUserInGroupExceptMe(ptc.message.GroupReceive, ptc.message.Sender);
            foreach(var item in accounts)
            {
                IChatClient clt;
                if(Instance.OnlineUser.TryGetValue(item.Email,out clt))
                {
                    clt.SendGroupMessage(ptc.message);
                }
            }
            return toView;
        }

        private int InsertMessage(ChatDataModel.ChatGroupMessage message)
        {
            lock (syncLock)
            {
                IChatGroupMessageDAO db = new ChatGroupMessageDAOSQL();
                return db.Insert(message);
            }
        }

        private List<Account> GetUserInGroupExceptMe(string groupId, string email)
        {
            lock (synLock1)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroupExceptMe(groupId, email);
            }
        }
    }
}
