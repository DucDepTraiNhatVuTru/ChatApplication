using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Packet
{
    public class BasicPacket : IPacket
    {
        public byte[] Data { get; set; }
        public byte Opcode { get; set; }
        public bool Parse(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                using (var read = new BinaryReader(stream))
                {
                    Opcode = read.ReadByte();
                    var Len = read.ReadInt16();
                    if (Len < data.Length - 3)
                        return false;
                    Data = read.ReadBytes(Len);
                    return true;
                }
            }
        }

        public byte[] ToBytes()
        {
            using (var stream = new MemoryStream())
            {
                using (var w = new BinaryWriter(stream))
                {
                    w.Write(Opcode);
                    w.Write((short)Data.Length);
                    w.Write(Data);
                    return stream.ToArray();
                }
            }
        }
    }
}
