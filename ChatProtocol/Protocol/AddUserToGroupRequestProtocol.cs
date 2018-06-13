using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class AddUserToGroupRequestProtocol : IProtocol
    {
        public string GroupId { get; set; }
        public List<string> Emails { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            GroupId = tach[0];
            for(int i=1; i<tach.Length; i++)
            {
                Emails.Add(tach[i]);
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = GroupId + "\0";
            foreach(var item in Emails)
            {
                data += item + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
