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
    public class LeaveGroupHandle : IHandle
    {
        private object synclock = new object();
        private object synclock1 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as LeaveGroupRequestProtocol;
            var toView = new Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "leave group [" + ptc.GroupId + "]");

            int rowAffect = 0;
            try
            {
                rowAffect = Delete(ptc.Email, ptc.GroupId);
                toView.Message += "\n delete in db successful , " + rowAffect + " "+ptc.Email;
            }
            catch (Exception ex)
            {
                toView.Message = "\n delete failed \n Detail : " + ex.Message;
                return toView.ToString();
            }

            //gửi lại  đã xóa được hay chưa
            client.ResponseLeaveGroup(rowAffect, ptc.GroupId);

            if (rowAffect == 0) return toView.Message;
            //gửi lại cho các member trong nhóm danh sách thành viên mới
            List<Account> accounts = new List<Account>();
            try
            {
                accounts = GetUserExceptMe(ptc.Email, ptc.GroupId);
            }
            catch (Exception ex)
            {
                toView.Message += "\n failed get list account to send new list uer in group \n Detail: " + ex.Message;
                return toView.ToString();
            }
            if (accounts.Count > 0)
            {
                foreach(var item in accounts)
                {
                    IChatClient _client = null;
                    if(Instance.OnlineUser.TryGetValue(item.Email,out _client))
                    {
                        _client.ResponseGetUserInGroup(ptc.GroupId, accounts);
                    }
                }
            }
            toView.Message += "\n send new list accounts succesful";

            return toView.ToString();
        }
        private int Delete(string email, string groupId)
        {
            lock (synclock)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.DeleteUserInGroup(email, groupId);
            }
        }
        private List<Account> GetUserExceptMe(string email,string groupId)
        {
            lock (synclock1)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.GetUserInGroupExceptMe(groupId, email);
            }
        }
    }
}
