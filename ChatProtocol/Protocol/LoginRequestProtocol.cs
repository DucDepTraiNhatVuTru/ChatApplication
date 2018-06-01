using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class LoginRequestProtocol : IProtocol
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            Email = tach[0];
            Password = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Email + "\0";
            data += Password + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
