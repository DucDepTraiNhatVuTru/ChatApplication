using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDAO;
using ChatDataModel;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.Email = "ngocdung@gmail.com";
            account.Password = "123456";
            account.Name = "Minh Đức";
            var image = Image.FromFile(@"D:\ThucTap\avartar.jpg");
            Bitmap bm = new Bitmap(image, new Size(64, 64));
            //account.Avatar =(Image) bm;
            account.Gender = "Nu";
            account.TimeCreate = DateTime.Now;
            IAccountDAO accountDao = new AccountDAOSQL();
            accountDao.Insert(account);
            /*IAccountDAO account = new AccountDAOSQL();
            Account acc = account.GetAccount("ngocdung@gmail.com");
            Console.WriteLine(acc.Email);
            Console.WriteLine(acc.Name);
            Console.WriteLine(acc.Gender);
            Console.WriteLine(acc.TimeCreate);

            
            /*string a = ImageConverter.ImageConverter.ConvertImageToBase64(Image.FromFile(@"D:\ThucTap\avartar.jpg"));

            ImageConverter.ImageConverter.ConvertBase64ToImage(a);*/
           /* var arr = ImageConverter.ImageConverter.ConvertImageToByteArray(Image.FromFile(@"D:\ThucTap\avartar.jpg"));

            ImageConverter.ImageConverter.CovertByteArrayToImage(arr);*/
            Console.ReadLine();
        }
    }
}
