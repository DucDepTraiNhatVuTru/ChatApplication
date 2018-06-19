using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class AcceptFriendRequestProtocol : IProtocol
    {
        public int IsAccept { get; set; }
        public string UserRequest { get; set; }
        public string UserAccept { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 3) return false;
            int isAccept = 0;
            if (!int.TryParse(tach[0], out isAccept)) return false;
            IsAccept = isAccept;
            UserRequest = tach[1];
            UserAccept = tach[2];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += IsAccept + "\0";
            data += UserRequest + "\0";
            data += UserAccept + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
