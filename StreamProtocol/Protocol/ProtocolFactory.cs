using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamProtocol.Protocol
{
    public class ProtocolFactory
    {
        public static IProtocol CreateProtocol(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new StartStreamRequestProtocol();
                case 2:
                    return new StreamingProtocol();
                default:
                    throw new Exception("chưa hỗ trợ opcode");
            }
        }
    }
}
