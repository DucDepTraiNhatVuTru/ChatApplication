using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GetListFriendsResponseProtocol : IProtocol
    {
        public List<Account> ListAccount = new List<Account>();
        public bool Parse(string data)
        {
            if(string.IsNullOrEmpty(data))return false;
            var tach = data.Split('\0');
            //if (tach.Length < 1) return false;
            foreach(var item in tach)
            {
                var account = ParseAccount(item);
                if (account != null)
                    ListAccount.Add(account);
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            foreach(var item in ListAccount)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }

        private Account ParseAccount(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var tach = data.Split('\v');
            if (tach.Length < 6) return null;
            var account = new Account();
            account.Email = tach[0];
            account.Password = tach[1];
            account.Name = tach[2];
            account.AvatarDriveID = tach[3];
            account.Gender = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return null;
            account.TimeCreate = time;
            return account;
        }
    }
}
