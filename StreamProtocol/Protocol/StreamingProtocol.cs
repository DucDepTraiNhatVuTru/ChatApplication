using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamProtocol.Protocol
{
    public class StreamingProtocol : IProtocol
    {
        public string StreamID { get; set; }
        public byte[] Image { get; set; }
        public byte[] Sound { get; set; }
        public bool Parse(byte[] data)
        {
            if (data.Length == 0) return false;
            using(var stream = new MemoryStream(data))
            {
                using(var reader=new BinaryReader(stream))
                {
                    var lenghtStreamId = reader.ReadInt16();
                    StreamID = reader.ReadChars(lenghtStreamId).ToString();
                    var lengthImage = reader.ReadInt32();
                    Image = reader.ReadBytes(lengthImage);
                    var lenghtSound = reader.ReadInt32();
                    Sound = reader.ReadBytes(lenghtSound);
                    return true;
                }
            }
        }

        public byte[] ToBytes()
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write((short)StreamID.Length);
                    writer.Write(StreamID);
                    writer.Write((int)Image.Length);
                    writer.Write(Image);
                    writer.Write((int)Sound.Length);
                    writer.Write(Sound);
                    return stream.ToArray();
                }
            }
        }
    }
}
