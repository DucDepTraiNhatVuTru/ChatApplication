using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    public class ImageResize
    {
        public static Image ResizeImage(Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            graphic.DrawImage(image, 0, 0, width, height);
            graphic.Dispose();
            return (Image)bitmap;
        }
    }
}
