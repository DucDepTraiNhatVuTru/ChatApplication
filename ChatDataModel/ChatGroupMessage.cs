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
    }
}
