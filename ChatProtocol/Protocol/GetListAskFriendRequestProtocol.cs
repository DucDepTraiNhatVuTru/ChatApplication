using ChatProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Protocol
{
    public class GetListAskBeFriendRequestProtocol : IProtocol
    {
        public string Email { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            Email = tach[0];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = Email + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
