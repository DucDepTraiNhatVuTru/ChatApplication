using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO;

namespace SocketServer.Handle
{
    public class GetFriendNotInGroupHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetFriendNotInGroupRequestProtocol;
            var toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user: " + ptc.Email+"] get list friend not in group [" + ptc.GroupId + "]";
            List<Account> accounts = new List<Account>();
            try
            {
                accounts = GetAccountNotInGroup(ptc.Email, ptc.GroupId);
            }
            catch (Exception ex)
            {
                toView += "\n Get List Account not in Group Failed \n detail: " + ex.Message;
                return toView;
            }
            if (accounts.Count > 0)
                client.ResponseFriendNotInGroup(accounts);
            toView += "\n send list friend not in group chat successful";
            return toView;
        }

        private List<Account> GetAccountNotInGroup(string email, string groupId)
        {
            lock (syncLock)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetListFriendNotInGroup(email, groupId);
            }
        }
        
    }
}
