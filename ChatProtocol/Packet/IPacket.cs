using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Packet
{
    public interface IPacket
    {
        bool Parse(byte[] data);
        byte[] ToBytes();
    }
}
