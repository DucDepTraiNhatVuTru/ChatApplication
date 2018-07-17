using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class GetListUserStreamResponseProtocol : IProtocol
    {
        public List<ChatDataModel.AccountStream> AccountStream = new List<ChatDataModel.AccountStream>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 1) return false;
            foreach(var item in tach)
            {
                var accountStream = new ChatDataModel.AccountStream();
                if (accountStream.Parse(item))
                {
                    AccountStream.Add(accountStream);
                }
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            foreach(var item in AccountStream)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
