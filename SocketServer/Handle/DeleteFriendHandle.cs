using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatProtocol.Ulti;
using ChatDAO.SQL;
using ChatProtocol;
using ChatDataModel;
using ChatDAO;

namespace SocketServer.Handle
{
    public class DeleteFriendHandle : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as DeleteFriendRequestProtocol;
            var toView = new ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.UserRequest, "request delete friend reationship with [user:" + ptc.UserDelete + "]");

            int delete = 0;
            try
            {
                delete = Delete(ptc.UserRequest, ptc.UserDelete);
            }
            catch (Exception ex)
            {
                toView.Message += "error to delete relationship \n detail : " + ex.Message;
                return toView.ToString();
            }

            IChatClient _client = null;
            if(Instance.OnlineUser.TryGetValue(ptc.UserDelete, out _client))
            {
                var accounts = new List<Account>();
                try
                {
                    accounts = NewListFriend(ptc.UserDelete);
                }
                catch (Exception ex)
                {
                    toView.Message += "error get list friend from db \n deltail : " + ex.Message;
                }
                _client.ResponseGetListFriends(accounts);
            }

            return toView.ToString();
        }

        private int Delete(string email1, string email2)
        {
            lock (synlock)
            {
                var db = new FriendDAOSQL();
                return db.Delete(email1, email2);
            }
        }

        private List<Account> NewListFriend(string email)
        {
            lock (synlock1)
            {
                var db = new AccountDAOSQL();
                return db.GetFriendList(email);
            }
        }
    }
}
