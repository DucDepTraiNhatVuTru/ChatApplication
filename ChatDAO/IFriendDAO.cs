using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO
{
    public interface IFriendDAO
    {
        int Insert(string email1, string email2);
    }
}
