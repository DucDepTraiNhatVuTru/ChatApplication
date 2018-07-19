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
           /* MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            stream.Position = 0;
            return stream.ToArray();*/
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        public static Image CovertByteArrayToImage(byte[] imageArray)
        {
            /*MemoryStream ms = new MemoryStream();
            ms.Read(imageArray, 0, imageArray.Length);
            Image image = Image.FromStream(ms);
            return image;*/
            using(MemoryStream ms = new MemoryStream(imageArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static string ConvertImageToBase64(Image image)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                byte[] arr = ms.ToArray();

                string base64 = Convert.ToBase64String(arr);
                return base64;
            }
        }

        public static Image ConvertBase64ToImage(string base64)
        {
            byte[] arr = Convert.FromBase64String(base64);
            using (var ms = new MemoryStream(arr, 0, arr.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
