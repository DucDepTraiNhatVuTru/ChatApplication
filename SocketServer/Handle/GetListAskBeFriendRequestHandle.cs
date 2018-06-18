using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatDataModel;
using ChatDAO.SQL;
using SocketServer.Protocol;

namespace SocketServer.Handle
{
    public class GetListAskBeFriendRequestHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetListAskBeFriendRequestProtocol;
            var toView = new ChatProtocol.Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "request get all request add be friend");
            var accounts = new List<Account>();
            try
            {
                accounts = ListAccountSendFriendRequest(ptc.Email);
            }
            catch (Exception ex)
            {
                toView.Message += " db error \n detail : " + ex.Message;
                return toView.ToString();
            }

            client.ResponseGetListUserRequestAddFriend(accounts);
            return toView.ToString();
        }

        private List<Account> ListAccountSendFriendRequest(string email)
        {
            lock (this)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetRequest(email);
            }
        }
    }
}
