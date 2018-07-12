using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDataModel;
using ChatDAO;

namespace SocketServer.Handle
{
    public class CreateAccountRequestHandle : IHandle
    {
        private static object syncLock = new object();

        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as CreateAccountProtocol;
            string toView = "[" + DateTime.Now + "] : request create Account ";

            //kiểm tra coi email đăng ký đã tồn tại không cái đã
            if (!IsAccountExist(ptc.Account.Email))
            {
                // gửi lỗi về đã tồn tại account.Email về
                client.ResponseCreateAccount(0, "email is uesed!");
                toView += "\n create account non successful , email is used";
            }
            else
            {
                try
                {
                    InsertAccount(ptc.Account);
                    toView += "\n create account successful";
                }
                catch (Exception ex)
                {
                    toView += "\n create account non successful , database error ";
                    throw new Exception(ex.Message);
                }
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

        private static bool IsAccountExist(string email)
        {
            lock (syncLock)
            {
                try
                {
                    IAccountDAO db = new AccountDAOSQL();
                    var account = db.GetAccount(email);
                    if (account.Email == email) return false;
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        
    }
}
