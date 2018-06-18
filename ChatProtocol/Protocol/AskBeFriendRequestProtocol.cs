using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class AskBeFriendRequestProtocol : IProtocol
    {
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            SenderEmail = tach[0];
            ReceiverEmail = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += SenderEmail + "\0";
            data += ReceiverEmail + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
