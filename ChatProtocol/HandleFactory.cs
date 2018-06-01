using ChatProtocol.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol
{
    public class HandleFactory
    {
        public static IHandle CreateHandle(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new CreateAccountRequestHandle();
                case 3:
                    return new LoginRequestHandle();
                default:
                    throw new Exception("chưa hỗ trợ opcode!");
            }
        }
    }
}
