using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class ChatGroupMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string GroupReceive { get; set; }
        public string Message { get; set; }
        public string ImageMessageDriveId { get; set; }
        public DateTime TimeSend { get; set; }

        public ChatGroupMessage()
        {

        }

        public ChatGroupMessage(string sender, string groupReceive, string  message, string imageMessageDriveId, DateTime timeSend)
        {
            Sender = sender;
            GroupReceive = groupReceive;
            Message = message;
            ImageMessageDriveId = imageMessageDriveId;
            TimeSend = timeSend;
        }

        public ChatGroupMessage(int id, string sender, string groupReceive, string message, string imageMessageDriveId, DateTime timeSend)
        {
            Id = id;
            Sender = sender;
            GroupReceive = groupReceive;
            Message = message;
            ImageMessageDriveId = imageMessageDriveId;
            TimeSend = timeSend;
        }

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\v');
            if (tach.Length < 5) return false;
            int id = 0;
            if (!int.TryParse(tach[0], out id)) return false;
            Id = id;
            Sender = tach[1];
            GroupReceive = tach[2];
            Message = tach[3];
            ImageMessageDriveId = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            TimeSend = time;
            return true;
        }

        public override string ToString()
        {
            var data = "";
            data += Id + "\v";
            data += Sender + "\v";
            data += GroupReceive + "\v";
            data += Message + "\v";
            data += ImageMessageDriveId + "\v";
            data += TimeSend + "\v";
            return data;
        }
    }
}
