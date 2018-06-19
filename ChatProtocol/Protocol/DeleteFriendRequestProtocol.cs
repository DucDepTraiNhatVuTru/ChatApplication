using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class DeleteFriendRequestProtocol : IProtocol
    {
        public string UserRequest { get; set; }
        public string UserDelete { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2)
                return false;
            UserRequest = tach[0];
            UserDelete = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += UserRequest + "\0";
            data += UserDelete + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
