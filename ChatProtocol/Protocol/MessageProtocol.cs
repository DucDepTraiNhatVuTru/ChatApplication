using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class MessageProtocol:IProtocol
    {
        public ChatMessage Message = new ChatMessage();

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 6) return false;
            int id = 0;
            if (!int.TryParse(tach[0], out id)) return false;
            Message.Id = id;
            Message.Sender = tach[1];
            Message.Receiver = tach[2];
            Message.Message = tach[3];
            Message.ImageMessageDriveID = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            Message.TimeSend = time;
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Message.Id + "\0";
            data += Message.Sender + "\0";
            data += Message.Receiver + "\0";
            data += Message.Message + "\0";
            data += Message.ImageMessageDriveID + "\0";
            data += Message.TimeSend + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
