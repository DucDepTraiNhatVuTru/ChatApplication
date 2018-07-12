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
    public class GetListFriendsRequestHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetListFriendsRequestProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] get list friends ";
            var listFriends = ListFriends(ptc.Email);
            if (listFriends.Count == 0)
            {
                toView += "\n list friend is empty";
                return toView;
            }
            client.ResponseGetListFriends(listFriends);
            return toView += "\n get list friend successful ";
        }

        private List<Account> ListFriends(string email)
        {
            lock (syncLock)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetFriendList(email);
            }
        }
    }
}
