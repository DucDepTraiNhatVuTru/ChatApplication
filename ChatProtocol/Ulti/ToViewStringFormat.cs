using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Ulti
{
    public class ToViewStringFormat
    {
        public DateTime Time { get; set; }
        public string IP { get; set; }
        public string User { get; set; }
        public string Handle { get; set; }
        public string Message { get; set; }

        public ToViewStringFormat()
        {

        }

        public ToViewStringFormat(DateTime time, string ip, string user, string handle)
        {
            Time = time;
            IP = ip;
            User = user;
            Handle = handle;
        }

        public override string ToString()
        {
            var data = "";
            data += "[" + Time + "] [" + IP + "] [user:" + User + "] " + Handle + "\n"+Message;
            return data;
        }
    }
}
