using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public string ImageMessageDriveID { get; set; }
        public DateTime TimeSend { get; set; }

        public ChatMessage()
        {

        }
        public ChatMessage(string sender, string receiver, string message, string imageDriveId, DateTime time)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
            ImageMessageDriveID = imageDriveId;
            TimeSend = time;
        }

        public ChatMessage(int id, string sender, string receiver, string message, string imageDriveId, DateTime time)
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Message = message;
            ImageMessageDriveID = imageDriveId;
            TimeSend = time;
        }

        public override string ToString()
        {
            var data = "";
            data += Id + "\v";
            data += Sender + "\v";
            data += Receiver + "\v";
            data += Message + "\v";
            data += ImageMessageDriveID + "\v";
            data += TimeSend + "\v";
            return data;
        }
    }
}
