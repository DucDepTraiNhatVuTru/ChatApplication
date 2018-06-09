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

        public static Image ResizeImage(Image image, float percentage)
        {
            //size cũ
            int originalW = image.Width;
            int originalH = image.Height;
            //size mới
            int resizedW = (int)(originalW * percentage);
            int resizedH = (int)(originalH * percentage);
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            //tạo 1 graphic mới từ Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            //vẽ lại ảnh ban đầu lên bmp theo kích thước mới
            graphic.DrawImage(image, 0, 0, resizedW, resizedH);
            //giải phóng tài nguyên mà graphic đang giữ
            graphic.Dispose();
            //return the image
            return (Image)bmp;
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
            graphic.DrawEllipse(new Pen(Brushes.White),new Rectangle());
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.DrawImage(image, 0 - edge / 2, 0 - edge / 2, edge, edge);
            graphic.Dispose();
            return (Image)bitmap;
        }
    }
}
