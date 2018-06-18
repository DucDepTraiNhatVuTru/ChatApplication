using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class FriendResquestNotExcept
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Time { get; set; }
        public FriendResquestNotExcept()
        {

        }
        public FriendResquestNotExcept(string sender, string receiver, DateTime time)
        {
            Sender = sender;
            Receiver = receiver;
            Time = time;
        }
    }
}
