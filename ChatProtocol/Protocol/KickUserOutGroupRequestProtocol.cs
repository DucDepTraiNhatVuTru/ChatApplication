using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class KickUserOutGroupRequestProtocol : IProtocol
    {
        public string EmailRequest { get; set; }
        public string KickEmail { get; set; }
        public string GroupId { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 3) return false;
            EmailRequest = tach[0];
            KickEmail = tach[1];
            GroupId = tach[2];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += EmailRequest + "\0";
            data += KickEmail + "\0";
            data += GroupId + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
