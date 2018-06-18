using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatDataModel;
using SocketServer.Protocol;
using ChatDAO.SQL;

namespace SocketServer.Handle
{
    public class GetListUserIAskedBeFriendHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetListAskBeFriendRequestProtocol;
            var toView = new ChatProtocol.Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "get list user that this user sended friend request");
            var accounts = new List<Account>();
            try
            {
                accounts = ListUserIAskBeFriend(ptc.Email);
            }
            catch (Exception ex)
            {
                toView.Message += "error get list account from db \n detail : " + ex.Message;
                return toView.ToString();
            }
            return toView.ToString();
        }

        private List<Account> ListUserIAskBeFriend(string email)
        {
            lock (synlock)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetMyRequest(email); 
            }
        }
    }
}
