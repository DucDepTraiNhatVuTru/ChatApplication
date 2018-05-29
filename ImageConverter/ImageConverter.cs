using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageConverter
{
    public class ImageConverter
    {
        public static byte[] ConvertImageToByteArray(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            return stream.ToArray();
        }

        public static Image CovertByteArrayToImage(byte[] imageArray)
        {
            MemoryStream ms = new MemoryStream(imageArray);
            Image image = Image.FromStream(ms);
            return image;
        }
    }
}
