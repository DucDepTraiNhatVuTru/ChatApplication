﻿using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO
{
    public interface IAccountDAO
    {
        void Insert(Account account);
        Account GetAccount(string email);
        Account GetAccount(string email, string password);
        int UpdateAvatar(string email, string driveFileId);
    }
}