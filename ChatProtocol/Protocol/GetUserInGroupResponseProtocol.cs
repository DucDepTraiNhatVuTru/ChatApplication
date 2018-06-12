using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GetUserInGroupResponseProtocol : IProtocol
    {
        public string GroupId { get; set; }
        public List<Account> Accounts = new List<Account>();

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            GroupId = tach[0];
            foreach(var item in tach)
            {
                var account = new Account();
                if (account.Parse(item))
                {
                    Accounts.Add(account);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = GroupId + "\0";
            foreach(var item in Accounts)
            {
                data += item + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
