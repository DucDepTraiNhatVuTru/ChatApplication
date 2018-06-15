using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDAO;
using ChatDAO.SQL;
using ChatDataModel;

namespace ChatProtocol.Handle
{
    public class KickUserOutGroupHandle : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        private object synlock2 = new object();
        private object synlock3 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as KickUserOutGroupRequestProtocol;
            Ulti.ToViewStringFormat toVIew = new Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.EmailRequest, " request kick [user:" + ptc.KickEmail + "] out group [" + ptc.GroupId + "]");

            //check is this user create group
            bool _isUserCreateGroup;
            try
            {
                _isUserCreateGroup = IsUserCreateGroup(ptc.EmailRequest, ptc.GroupId);
            }
            catch (Exception ex)
            {
                toVIew.Message += "\n Check is user create group failed. \n detail : " + ex.Message;
                return toVIew.ToString();
            }

            if (!_isUserCreateGroup)
            {
                client.ResponseKickUserOutGroup(0, ptc.GroupId,ptc.KickEmail, "Only the creator of the group can invite others out of the group");
                toVIew.Message += "User is not creator. Can not kick user out of group";
                return toVIew.ToString();
            }

            int rowAffect = 0;
            try
            {
                rowAffect = DeleteUser(ptc.KickEmail, ptc.GroupId);
            }
            catch (Exception ex)
            {
                toVIew.Message += "\n can not delete user in group from database \n detail:" + ex.Message;
                return toVIew.ToString();
            }

            client.ResponseKickUserOutGroup(1, ptc.GroupId,ptc.KickEmail, "kick successful");

            // gửi thông báo đến các user khác
            List<Group> group = new List<Group>();
            try
            {
                group = GetListGroup(ptc.KickEmail);
            }
            catch (Exception ex)
            {
                toVIew.Message += "can not get group \n detail: " + ex.Message;
                return toVIew.ToString();
            }
            IChatClient _client = null;
            if (Instance.OnlineUser.TryGetValue(ptc.KickEmail, out _client)) _client.ResponseGetGroups(group);

            var accounts = new List<Account>();
            try
            {
                accounts = GetListAccountInGroup(ptc.GroupId, ptc.EmailRequest);
            }
            catch (Exception ex)
            {
                toVIew.Message += " error \n detail : " + ex.Message;
                return toVIew.ToString();
            }
            
            foreach(var item in accounts)
            {
                IChatClient _cl = null;
                if (Instance.OnlineUser.TryGetValue(item.Email, out _cl))
                    _cl.ResponseGetUserInGroup(ptc.GroupId, accounts);
            }
            
            return toVIew.ToString();
        }

        private bool IsUserCreateGroup(string email, string groupId)
        {
            lock (synlock)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.IsUserCreateGroup(email, groupId);
            }
        }

        private int DeleteUser(string email, string groupId)
        {
            lock (synlock1)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.DeleteUserInGroup(email, groupId);
            }
        }

        private List<Group> GetListGroup(string email)
        {
            lock (synlock2)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.GetListGroup(email);
            }
        }

        private List<Account> GetListAccountInGroup(string groupId, string myEmail)
        {
            lock (synlock3)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroupExceptMe(groupId, myEmail);
            }
        }
    }
}
