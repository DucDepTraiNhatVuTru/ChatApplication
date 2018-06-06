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
            IChatMessageDAO db = new ChatMessageDAOSQL();
            var meslist = db.AllMessage("ngocdung@gmail.com","minhduc@gmail.com" );
            foreach(var item in meslist)
            {
                Console.WriteLine(item.Message);
            }
            Console.ReadLine();
        }
    }
}
