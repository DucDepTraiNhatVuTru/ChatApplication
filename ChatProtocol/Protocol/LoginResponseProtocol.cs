using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class LoginResponseProtocol : IProtocol
    {
        public int IsAccept { get; set; }
        public Account Account = new Account();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1)
                return false;
            int isAccept = 0;
            if (!int.TryParse(tach[0], out isAccept))
                return false;
            IsAccept = isAccept;
            Account.Email = tach[1];
            Account.Password = tach[2];
            Account.Name = tach[3];
            Account.AvatarDriveID = tach[4];
            Account.Gender = tach[5];
            DateTime time;
            if (!DateTime.TryParse(tach[6], out time)) return false;
            Account.TimeCreate = time;
            return true;
        }

        public byte[] ToBytes()
        {
            var data = IsAccept + "\0";
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
