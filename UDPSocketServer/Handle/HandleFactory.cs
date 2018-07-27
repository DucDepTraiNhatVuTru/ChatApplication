using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPSocketServer.Handle;

namespace UDPSocketServer.Handle
{
    public class HandleFactory
    {
        public static IHandle CreateHandle(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new StrartStreamRequestHandle();
                case 2:
                    return new StreamingHandle();
                default:
                    throw new Exception("chưa hỗ trợ opcode");
            }
        }
    }
}
