using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO;
using ChatDAO.SQL;

namespace ChatProtocol.Handle
{
    public class CreateGroupChatHandle : IHandle
    {
        private object synlock = new object();
        private object synlock1 = new object();
        private object synlock2 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as CreateGroupRequestProtocol;
            var toView = new Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Group.UserCreate, " request create a group with name " + ptc.Group.Name);

            int insert = 0;
            try
            {
                insert = Insert(ptc.Group);
            }
            catch (Exception ex)
            {
                toView.Message += "\n cannot insert Group to database \n detail: " + ex.Message;
                return toView.ToString();
            }

            if (insert == 0) { client.ResponseCreateGroupChat(insert, new List<Group>()); return toView.ToString(); }

            try
            {
                InsertUserToGroup(ptc.Group.UserCreate, ptc.Group.Id);
            }
            catch (Exception ex)
            {
                toView.Message += "\n Error add user " + ptc.Group.UserCreate + " to groups " + ptc.Group.Id + " \n detail : " + ex.Message;
            }

            foreach (var item in ptc.Accounts)
            {
                try
                {
                    InsertUserToGroup(item, ptc.Group.Id);
                }
                catch (Exception ex)
                {
                    toView.Message += "\n Error add user " + item + " to groups " + ptc.Group.Id + " \n detail : " + ex.Message;
                }
            }

            var listGroup = new List<Group>();
            try
            {
                listGroup = GetListGroup(ptc.Group.UserCreate);
            }
            catch (Exception ex)
            {
                toView.Message += "\n Error get list group \n detail : " + ex.Message;
            }

            client.ResponseGetGroups(listGroup);

            foreach(var item in ptc.Accounts)
            {
                IChatClient _client = null;
                if (Instance.OnlineUser.TryGetValue(item, out _client)){
                    _client.ResponseGetGroups(GetListGroup(item));
                }
            }

            toView.Message += "\n Create Group Successful";

            return toView.ToString();
        }
        private int Insert(Group group)
        {
            lock (synlock)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.Insert(group);
            }
        }

        private int InsertUserToGroup(string email, string groupId)
        {
            lock (synlock1)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.InsertUserToGroup(email, groupId);
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
    }
}
