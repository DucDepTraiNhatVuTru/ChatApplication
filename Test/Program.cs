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
            db.Insert(new ChatMessage("minhduc@gmail.com", "ngocdung@gmail.com", "xin chào! test", "", DateTime.Now));
            Console.ReadLine();
        }
    }
}
