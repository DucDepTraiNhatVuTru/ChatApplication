﻿using System;
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
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as LoginRequestProtocol;
            string toView = "[" + DateTime.Now + "] : request login ";
            int isAccept = 0;
            if (GetAccount(ptc.Email, ptc.Password).Email != ptc.Email)
            {
                isAccept = 0;
                toView += "\n reject login";
                return toView;
            }
            

            
            
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
    }
}
