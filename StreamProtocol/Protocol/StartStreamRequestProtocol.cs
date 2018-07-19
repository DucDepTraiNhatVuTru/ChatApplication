using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamProtocol.Protocol
{
    public class StartStreamRequestProtocol : IProtocol
    {
        public string StreamID { get; set; }
        public bool Parse(byte[] data)
        {
            if (data.Length <= 0) return false;
            using(var stream = new MemoryStream(data))
            {
                using(var reader = new BinaryReader(stream))
                {
                    var length = reader.ReadInt16();
                    StreamID = Encoding.Unicode.GetString(reader.ReadBytes(length));
                    return true;
                }
            }
        }

        public byte[] ToBytes()
        {
            using(var stream = new MemoryStream())
            {
                using(var writer = new BinaryWriter(stream))
                {
                    var streamID = Encoding.Unicode.GetBytes(StreamID);
                    writer.Write((short)streamID.Length);
                    writer.Write(streamID);
                    return stream.ToArray();
                }
            }
        }
    }
}
