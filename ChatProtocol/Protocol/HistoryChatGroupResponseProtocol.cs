using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class HistoryChatGroupResponseProtocol : IProtocol
    {
        public List<ChatGroupMessage> Messages = new List<ChatGroupMessage>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            foreach(var item in tach)
            {
                var message = new ChatGroupMessage();
                if (message.Parse(item))
                {
                    Messages.Add(message);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            foreach(var item in Messages)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
