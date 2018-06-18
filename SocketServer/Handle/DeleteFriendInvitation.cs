using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatDataModel;
using ChatDAO.SQL;
using ChatProtocol;

namespace SocketServer.Handle
{
    public class DeleteFriendInvitation : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        private object synlock2 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as AskBeFriendRequestProtocol;
            var toView = new ChatProtocol.Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.SenderEmail, " delete friend invitation with [user: " + ptc.ReceiverEmail + "]");
            int delete = 0;
            try
            {
                delete = Delete(new FriendResquestNotExcept(ptc.SenderEmail, ptc.ReceiverEmail, DateTime.Now));
            }
            catch (Exception ex)
            {
                toView.Message += "Error to Delete request from db \n deltai : " + ex.Message;
                return toView.ToString();
            }
            

            var accounts = new List<Account>();
            try
            {
                accounts = ListUserISendFriendRequest(ptc.SenderEmail);
            }
            catch (Exception ex)
            {
                toView.Message += "error get list account from db \n deltail : " + ex.Message;
                return toView.ToString();
            }
            client.ResponseGetListUserIRequestAddFriend(accounts);

            var accs = new List<Account>();
            try
            {
                accs = ListUserRequestAddFriendOfReceiveUser(ptc.ReceiverEmail);
            }
            catch (Exception ex)
            {
                toView.Message += "error get list account from db \n deltail : " + ex.Message;
                return toView.ToString();
            }
            IChatClient _client = null;
            if(Instance.OnlineUser.TryGetValue(ptc.ReceiverEmail,out _client))
            {
                _client.ResponseGetListUserRequestAddFriend(accs);
            }

            toView.Message += " handling successful!";

            return toView.ToString();
        }

        private int Delete(FriendResquestNotExcept request)
        {
            lock (this)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.DeleteByMe(request);
            }
        }

        private List<Account> ListUserISendFriendRequest(string email)
        {
            lock (synlock1)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetMyRequest(email);
            }
        }

        private List<Account> ListUserRequestAddFriendOfReceiveUser(string email)
        {
            lock (synlock2)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetRequest(email);
            }
        }
    }
}
