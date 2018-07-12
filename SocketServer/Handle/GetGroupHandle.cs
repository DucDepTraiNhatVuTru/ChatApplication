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

namespace SocketServer.Handle
{
    public class GetGroupHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetGroupChatRequestProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] get groups chat";
            var listGroup = GetListGroup(ptc.Email);
            if (listGroup.Count == 0)
            {
                toView += "\n list group empty";
                return toView;
            }
            client.ResponseGetGroups(listGroup);
            toView += "\n get list group OK!";
            return toView;
        }

        private List<Group> GetListGroup(string email)
        {
            lock (syncLock)
            {
                IGroupDAO db = new GroupsDAOSQL();
                return db.GetListGroup(email);
            }
        }
    }
}
