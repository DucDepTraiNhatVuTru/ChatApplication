using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class CreateAccountProtocol : IProtocol
    {
        public Account Account = new Account();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 6) return false;
            Account.Email = tach[0];
            Account.Password = tach[1];
            Account.Name = tach[2];
            Account.AvatarDriveID = tach[3];
            Account.Gender = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            Account.TimeCreate = time;
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Account.Email + "\0";
            data += Account.Password + "\0";
            data += Account.Name + "\0";
            data += Account.AvatarDriveID + "\0";
            data += Account.Gender + "\0";
            data += Account.TimeCreate + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
