using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO;

namespace ChatProtocol.Handle
{
    public class FindUserRequestHandle : IHandle
    {
        private object synlock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as FindUserRequestProtocol;
            var toView = new Ulti.ToViewStringFormat(DateTime.Now, client.GetEndPoint().ToString(), ptc.Email, "find users has name is " + ptc.Query);

            var accounts = new List<Account>();
            try
            {
                accounts = FindUsersResult(ptc.Email, ptc.Query);
            }
            catch (Exception ex)
            {
                toView.Message += "error to find user \n detail : " + ex.Message;
            }

            return toView.ToString();
        }

        private List<Account> FindUsersResult(string myEmail, string query)
        {
            lock (synlock)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.FindUserExceptFriend(myEmail, query);
            }
        }
    }
}
