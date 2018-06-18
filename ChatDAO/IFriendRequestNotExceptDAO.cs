using ChatDAO;
using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO
{
    public interface IFriendRequestNotExceptDAO
    {
        int Insert(FriendResquestNotExcept requets);
        List<Account> GetRequest(string email);
        List<Account> GetMyRequest(string email);
        int DeleteByMe(FriendResquestNotExcept request);
    }
}
