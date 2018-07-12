
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatProtocol.Ulti;
using ChatDAO.SQL;

namespace SocketServer.Handle
{
    public class GetListFriendStreaming : IHandle
    {
        private object synclock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as GetFriendStreamingRequestProtocol;
            var toView = new ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "get list friends are streaming");

            var listFriend = new List<ChatDataModel.Account>();
            try
            {
                listFriend = GetListFriend(ptc.Email);
            }
            catch (Exception ex)
            {
                toView.Message += "error to use db\n detail : " + ex.Message;
            }

            var listFriendStreaming = new List<ChatDataModel.Account>();
            foreach(var item in listFriend)
            {
                lock (this)
                {
                    string value = "";
                    if(Instance.Streaming.TryGetValue(item.Email, out value))
                    {
                        listFriendStreaming.Add(item);
                    }
                }
            }

            // gửi về danh sách này.

            return toView.ToString();
        }

        private List<ChatDataModel.Account> GetListFriend(string email)
        {
            lock (synclock)
            {
                var db = new ChatDAO.AccountDAOSQL();
                return db.GetFriendList(email);
            }
        }
    }
}
