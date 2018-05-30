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
    public class CreateAccountRequestHandle : IHandle
    {
        private static object syncLock = new object();

        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as CreateAccountProtocol;
            string toView = "[" + DateTime.Now + "] : request create Account ";
            try
            {
                InsertAccount(ptc.Account);
                toView += "\n create account successful";
            }
            catch (Exception )
            {
                toView += "\n create account non successful , database error ";
                throw;
            }
            return toView;
        }

        private static void InsertAccount(Account account)
        {
            lock (syncLock)
            {
                try
                {
                    IAccountDAO db = new AccountDAOSQL();
                    db.Insert(account);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }
    }
}
