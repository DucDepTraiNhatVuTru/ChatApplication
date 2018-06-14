using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class LeaveGroupResponseProtocol : IProtocol
    {
        public int IsSuccess { get; set; }
        public string GroupId { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            int isSuccess = 0;
            if (!int.TryParse(tach[0], out isSuccess)) return false;
            IsSuccess = isSuccess;
            GroupId = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += IsSuccess + "\0";
            data += GroupId + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
