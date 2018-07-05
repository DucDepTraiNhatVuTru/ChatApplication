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
        public Call Call { get; set; }
        public DateTime TimeSend { get; set; }

        public ChatMessage()
        {

        }
        public ChatMessage(string sender, string receiver, string message, string imageDriveId,Call call, DateTime time)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
            ImageMessageDriveID = imageDriveId;
            Call = call;
            TimeSend = time;
        }

        public ChatMessage(int id, string sender, string receiver, string message, string imageDriveId, Call call, DateTime time)
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Message = message;
            ImageMessageDriveID = imageDriveId;
            Call = call;
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
            data += Call.ToString() + "\v";
            data += TimeSend + "\v";
            return data;
        }

        public bool Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var tach = input.Split('\v');
            if (tach.Length < 4) return false;
            int id = 0;
            if (!int.TryParse(tach[0], out id)) return false;
            Id = id;
            Sender = tach[1];
            Receiver = tach[2];
            Message = tach[3];
            ImageMessageDriveID = tach[4];
            var call = new Call();
            if (call.Parse(tach[5])) Call = call;
            else Call = null;
            DateTime time ;
            if (!DateTime.TryParse(tach[6], out time)) return false;
            TimeSend = time;
            return true;
        }
    }
}
