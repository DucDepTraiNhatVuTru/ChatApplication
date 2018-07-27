using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.StreamHandle
{
    public class StreamHandleFactory
    {
        public static IStreamHandle CreateHandle(byte opcode)
        {
            switch (opcode)
            {
                case 2:
                    return new StreamingHandle();
                default:
                    throw new Exception("not supported this opcode yet!");
            }
        }
    }
}
