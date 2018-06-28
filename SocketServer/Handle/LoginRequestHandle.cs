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
    public class LoginRequestHandle : IHandle
    {
        private object syncLock = new object();
        private object syncLock1 = new object();
        private object syncLock2 = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as LoginRequestProtocol;
            string toView = "[" + DateTime.Now + "] : request login ";
            int isAccept = 0;

            IChatClient _client;
            lock (syncLock2)
            {
                if (!Instance.OnlineUser.TryGetValue(ptc.Email, out _client))
                {
                    isAccept = 0;
                    toView += "\n reject login";
                    return toView;
                }
            }

            var account = GetAccount(ptc.Email, ptc.Password);
            if (account.Email != ptc.Email)
            {
                //trả về 0 nếu không trùng
                isAccept = 0;
                toView += "\n reject login";
                return toView;
            }
            //trả về 1 nếu đúng
            isAccept = 1;
            client.ResponseLogin(isAccept, account);
            toView += "\n accept login";

            Instance.OnlineUser.Add(ptc.Email, client);

            //SendMessageHadNotSended(client, ptc.Email);

            return toView;
        }

        private Account GetAccount(string email, string password)
        {
            lock (syncLock)
            {
                IAccountDAO db = new AccountDAOSQL();
                Account account = db.GetAccount(email, password);
                return account;
            }
        }

        private void SendMessageHadNotSended(IChatClient client, string email)
        {
            //List<ChatMessage> list = Instance.MessageHadNotSended;

            foreach(var item in Instance.MessageHadNotSended.ToList())
            {
                if (item.Receiver == email)
                {
                    client.SendMessage(item);
                    Instance.MessageHadNotSended.Remove(item);
                }
            }
            
            /*lock (syncLock1)
            {
                list = Instance.MessageHadNotSended;
            }
            foreach(var item in list)
            {
                if (item.Receiver == email)
                {
                    client.SendMessage(item);
                    lock (syncLock1)
                    {
                        Instance.MessageHadNotSended.Remove(item);
                    }
                }
            }*/
        }
    }
}
