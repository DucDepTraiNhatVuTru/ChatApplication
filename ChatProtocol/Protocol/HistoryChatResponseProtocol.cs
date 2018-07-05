using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class HistoryChatResponseProtocol : IProtocol
    {
        public List<ChatMessage> Messages = new List<ChatMessage>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            foreach(var item in tach)
            {
                var message = new ChatMessage();
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

        private ChatMessage ParseMessage(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var tach = data.Split('\v');
            if (tach.Length < 5) return null;
            var message = new ChatMessage();
            int id = 0;
            if (!int.TryParse(tach[0], out id)) return null;
            message.Id = id;
            message.Sender = tach[1];
            message.Receiver = tach[2];
            message.Message = tach[3];
            message.ImageMessageDriveID = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return null;
            message.TimeSend = time;
            return message;
        }
    }
}
