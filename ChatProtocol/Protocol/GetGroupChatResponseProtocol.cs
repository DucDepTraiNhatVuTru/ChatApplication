using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GetGroupChatResponseProtocol : IProtocol
    {
        public List<Group> Groups = new List<Group>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            foreach(var item in tach)
            {
                var group = new Group();
                if (group.Parse(item))
                {
                    Groups.Add(group);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            foreach(var item in Groups)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
        
    }
}
