using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatDAO.SQL;
using ChatDataModel;
using ChatDAO;
using ChatProtocol;

namespace SocketServer.Handle
{
    public class AcceptAddFriendHandle : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        private object synlock2 = new object();
        private object synlock3 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as AcceptFriendRequestProtocol;
            var toView = new ChatProtocol.Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.UserAccept, "");
            //xóa record trong list lời mời
            int delete = 0;
            try
            {
                delete = DeleteRecord(new FriendResquestNotExcept(ptc.UserRequest, ptc.UserAccept, DateTime.Now));
            }
            catch (Exception ex)
            {
                toView.Message += "error to delete record \n detail : " + ex.Message;
                return toView.ToString();
            }

            int insert = 0;
            if (ptc.IsAccept == 1)
            {
                try
                {
                    insert = InsertFriend(ptc.UserRequest, ptc.UserAccept);
                }
                catch (Exception ex)
                {

                    toView.Message += "error Insert Friend to db \n detail : " + ex.Message;
                    return toView.ToString();
                }
                
            }

            /*
            var requests = new List<Account>();
            try
            {
                requests = ListRequest(ptc.UserAccept);
            }
            catch (Exception ex)
            {
                toView.Message += "error get from db \n detail : " + ex.Message;
            }

            client.ResponseGetListUserRequestAddFriend(requests);
            */
            var accs = new List<Account>();
            try
            {
                accs = NewListFriend(ptc.UserAccept);
            }
            catch (Exception ex)
            {
                toView.Message += ex.Message;
            }

            client.ResponseGetListFriends(accs);

            IChatClient _client = null;
            if(!Instance.OnlineUser.TryGetValue(ptc.UserRequest, out _client)) { return toView.ToString(); }
            var accounts = new List<Account>();
            try
            {
                accounts = NewListFriend(ptc.UserRequest);
            }
            catch (Exception ex)
            {
                toView.Message += ex.Message;
            }
            _client.ResponseGetListFriends(accounts);

            return toView.ToString();
        }

        private int DeleteRecord(FriendResquestNotExcept request)
        {
            lock (synlock)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.DeleteByMe(request);
            }
        }

        private int InsertFriend(string email1, string email2)
        {
            lock (synlock1)
            {
                var db = new FriendDAOSQL();
                return db.Insert(email1, email2);
            }
        }

        private List<Account> ListRequest(string email)
        {
            lock (synlock2)
            {
                var db = new FriendRequestNotExceptDAOSQL();
                return db.GetMyRequest(email);
            }
        }

        private List<Account> NewListFriend(string email)
        {
            lock (synlock3)
            {
                var db = new AccountDAOSQL();
                return db.GetFriendList(email);
            }
        }
    }
}
