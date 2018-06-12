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
    public class GetUserInGroupHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetUserInGroupResquestProtocol;
            string toString = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] : Get All User in Group ";
            try
            {
                var listUser = GetUserInGroup(ptc.Email, ptc.GroupId);
                client.ResponseGetUserInGroup(ptc.GroupId,listUser);
                toString += "\n Get list user successfull";
            }
            catch (Exception ex)
            {
                toString += "\n Get list failed";
            }
            return toString;
        }

        private List<Account> GetUserInGroup(string email, string groupId)
        {
            lock (syncLock)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroup(groupId);
            }
        }
    }
}
