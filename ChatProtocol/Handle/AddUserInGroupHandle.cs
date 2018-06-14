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

namespace ChatProtocol.Handle
{
    public class AddUserInGroupHandle : IHandle
    {
        private object syncLock = new object();
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
            lock (this)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.GetListGroup(email);
            }
        }
    }
}
