using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamProtocol
{
    public class StreamPacket : IPacket
    {
        public byte Opcode { get; set; }
        public byte[] Data { get; set; }
        public bool Parse(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                using (var read = new BinaryReader(stream))
                {
                    Opcode = read.ReadByte();
                    var Len = read.ReadInt32();
                    if (Len < data.Length - 5)
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
                    w.Write((int)Data.Length);
                    w.Write(Data);
                    return stream.ToArray();
                }
            }
        }
    }
}
