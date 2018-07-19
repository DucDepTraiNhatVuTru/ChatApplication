using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamProtocol.Protocol
{
    public interface IProtocol
    {
        bool Parse(byte[] data);
        byte[] ToBytes();
    }
}
