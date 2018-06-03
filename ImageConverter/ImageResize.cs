using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static Image ResizeImageCircle(Image image, int edge)
        {
            var bitmap = new Bitmap(edge, edge);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            graphic.TranslateTransform(bitmap.Width /2, bitmap.Height /2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0 - edge / 2, 0 - edge / 2, edge, edge);
            Region region = new Region(path);
            graphic.SetClip(region, CombineMode.Replace);
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            graphic.DrawImage(image, 0 - edge / 2, 0 - edge / 2, edge, edge);
            graphic.Dispose();

            /*graphic.Clear(Color.White);
            Brush brush = new SolidBrush(ColorTranslator.FromHtml("#eeeeee"));
            graphic.FillEllipse(brush, 0, 0, edge - 1, edge - 1);
            graphic.DrawImage(image, 0, 0, edge, edge);
            graphic.Dispose();*/
            return (Image)bitmap;
        }
    }
}
