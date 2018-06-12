using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GroupMessageProtocol : IProtocol
    {
        public ChatDataModel.ChatGroupMessage message = new ChatDataModel.ChatGroupMessage();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 6) return false;
            int id = 0;
            if (!int.TryParse(tach[0], out id))
                return false;
            message.Id = id;
            message.Sender = tach[1];
            message.GroupReceive = tach[2];
            message.Message = tach[3];
            message.ImageMessageDriveId = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            message.TimeSend = time;
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += message.Id + "\0";
            data += message.Sender + "\0";
            data += message.GroupReceive + "\0";
            data += message.Message + "\0";
            data += message.ImageMessageDriveId + "\0";
            data += message.TimeSend + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
