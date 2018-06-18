using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class AskBeFriendResponseProtocol : IProtocol
    {
        public Account UserRequest { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var account = new Account();
            if (account.Parse(data))
            {
                UserRequest = account;
            }
            return true;
        }

        public byte[] ToBytes()
        {
            return Encoding.Unicode.GetBytes(UserRequest.ToString());
        }
    }
}
