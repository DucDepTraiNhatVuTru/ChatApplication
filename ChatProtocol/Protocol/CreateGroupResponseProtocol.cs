using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class CreateGroupResponseProtocol : IProtocol
    {
        public int IsSuccess { get; set; }
        public List<Group> Groups = new List<Group>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            int isSuccess = 0;
            if (!int.TryParse(tach[0], out isSuccess)) return false;
            IsSuccess = isSuccess;
            for (int i = 1; i < tach.Length; i++)
            {
                var group = new Group();
                if (group.Parse(tach[i]))
                {
                    Groups.Add(group);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += IsSuccess + "\0";
            foreach(var item in Groups)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
