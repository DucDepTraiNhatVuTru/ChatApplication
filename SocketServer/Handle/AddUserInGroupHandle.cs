using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatProtocol.Ulti;
using ChatDAO;
using ChatDAO.SQL;
using ChatDataModel;

namespace SocketServer.Handle
{
    public class AddUserInGroupHandle : IHandle
    {
        private object syncLock = new object();
        private object synclock1 = new object();
        private object synclock2 = new object();
        private object synclock3 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as AddUsersToGroupRequestProtocol;
            var toView = new ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), "null", "Add user to group " + ptc.GroupId);


            int isSuccess = 0;
            try
            {
                isSuccess=Insert(ptc.Email, ptc.GroupId);
                toView.Message = "Insert Successful";
            }
            catch (Exception ex)
            {
                toView.Message = "Insert failed \n detail : " + ex.Message;
            }

            client.ResponseAddFriendToGroup(isSuccess, ptc.GroupId);

            if (isSuccess == 1)
            {
                var accounts = GetUserInGroup(ptc.GroupId);
                foreach (var item in accounts)
                {
                    IChatClient _client = null;
                    if (item.Email != ptc.EmailRequest && !Instance.OnlineUser.TryGetValue(item.Email, out client))
                    {
                        _client.ResponseGetUserInGroup(ptc.GroupId, accounts);
                    }
                }
            }
            List<Group> listGroup = new List<Group>();
            try
            {
                listGroup = GetListGroup(ptc.Email);
            }
            catch (Exception)
            {

            }
            IChatClient cl;
            if (Instance.OnlineUser.TryGetValue(ptc.Email, out cl) && listGroup.Count > 0)
                cl.ResponseGetGroups(listGroup);
            
            return toView.ToString();
        }

        private int Insert(string email, string groupId)
        {
            lock (syncLock)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.InsertUserToGroup(email, groupId);
            }
        }

        private List<Group> GetListGroup(string email)
        {
            lock (synclock1)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.GetListGroup(email);
            }
        }

        private List<Account> GetAccountExceptMe(string email, string groupId)
        {
            lock (synclock2)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroupExceptMe(groupId, email);
            }
        }

        private List<Account> GetUserInGroup(string groupId)
        {
            lock (synclock3)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroup(groupId);
            }
        }
    }
}
