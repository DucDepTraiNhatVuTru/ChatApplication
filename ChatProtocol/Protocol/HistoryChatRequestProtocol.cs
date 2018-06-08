using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class HistoryChatRequestProtocol : IProtocol
    {
        public string PersonOne { get; set; }
        public string PersonTwo { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data))
                return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            PersonOne = tach[0];
            PersonTwo = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += PersonOne + "\0";
            data += PersonTwo + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
