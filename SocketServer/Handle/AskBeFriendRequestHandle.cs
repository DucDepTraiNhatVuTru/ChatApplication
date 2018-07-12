using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO.SQL;
using ChatDAO;
using ChatProtocol.Ulti;

namespace SocketServer.Handle
{
    public class AskBeFriendRequestHandle : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        private object synlock2 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as AskBeFriendRequestProtocol;
            var toView = new ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.SenderEmail, "Send a friend requset to user[" + ptc.ReceiverEmail + "]");
            

            try
            {
                var request = new FriendResquestNotExcept(ptc.SenderEmail, ptc.ReceiverEmail, DateTime.Now);
                Insert(request);
                toView.Message += "\n insert request successful";
            }
            catch (Exception ex)
            {
                toView.Message += "\n insert request to db Failed \n detail : " + ex.Message; ;
                return toView.ToString();
            }

            IChatClient _client = null;
            if (Instance.OnlineUser.TryGetValue(ptc.ReceiverEmail, out _client))
            {
                _client.ResponseGetListUserRequestAddFriend(ListRequestOfUser(ptc.ReceiverEmail));
                toView.Message += " send friend request successful!";
            }

            var accounts = new List<Account>();
            try
            {
                accounts = GetRequestIAsk(ptc.SenderEmail);
            }
            catch (Exception ex)
            {

                toView.Message += "error get list user from db \n detail : " + ex.Message;
                return toView.ToString();
            }

            client.ResponseGetListUserIRequestAddFriend(accounts);

            return toView.ToString();
        }

        private int Insert(FriendResquestNotExcept request)
        {
            lock (synlock)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.Insert(request);
            }
        }

        private Account GetAccount(string email)
        {
            lock (synlock1)
            {
                var db = new AccountDAOSQL();
                return db.GetAccount(email);
            }
        }

        private List<Account> ListRequestOfUser(string email)
        {
            lock (synlock1)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetRequest(email);
            }
        }

        private List<Account> GetRequestIAsk(string email)
        {
            lock (synlock2)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetMyRequest(email);
            }
        }
    }
}
