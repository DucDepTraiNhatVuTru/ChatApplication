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
            return true;
        }

        public byte[] ToBytes()
        {
            var data = IsAccept + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
