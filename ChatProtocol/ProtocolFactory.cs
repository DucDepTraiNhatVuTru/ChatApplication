using ChatProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol
{
    public class ProtocolFactory
    {
        public static IProtocol CreateProtocol(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new CreateAccountProtocol();
                    break;
                case 2:
                    return new CreateAccountResponseProtocol();
                    break;
                default:
                    throw new Exception("chưa hỗ trợ opcode");
            }
        }
    }
}
