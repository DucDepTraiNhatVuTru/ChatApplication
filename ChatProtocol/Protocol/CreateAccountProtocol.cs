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
        public Account account { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 6) return false;
            account.Email = tach[0];
            account.Password = tach[1];
            account.Name = tach[2];
            account.Avatar = ImageConverter.ImageConverter.CovertByteArrayToImage(Encoding.Unicode.GetBytes(tach[3]));
            account.Gender = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            account.TimeCreate = time;
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += account.Email + "\0";
            data += account.Password + "\0";
            data += account.Name + "\0";
            data += ImageConverter.ImageConverter.ConvertImageToByteArray(account.Avatar) + "\0";
            data += account.Gender + "\0";
            data += account.TimeCreate + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
