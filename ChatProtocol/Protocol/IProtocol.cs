using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public interface IProtocol
    {
        bool Parse(string data);
        byte[] ToBytes();
    }
}
