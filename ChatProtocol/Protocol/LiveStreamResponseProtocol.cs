using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class LiveStreamResponseProtocol : IProtocol
    {
        public string StreamID { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            StreamID = tach[0];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = StreamID + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
