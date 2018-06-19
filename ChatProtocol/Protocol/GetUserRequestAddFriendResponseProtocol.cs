using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GetUserRequestAddFriendResponseProtocol : IProtocol
    {
        public int Count { get; set; }
        public List<Account> Accounts = new List<Account>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            int count = 0;
            if (!int.TryParse(tach[0], out count)) return false;
            Count = count;
            for(int i=1;i<tach.Length; i++)
            {
                var account = new Account();
                if (account.Parse(tach[i]))
                {
                    Accounts.Add(account);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Count + "\0";
            foreach(var item in Accounts)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
