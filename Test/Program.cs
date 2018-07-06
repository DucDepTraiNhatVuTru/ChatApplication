using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDAO;
using ChatDataModel;
using System.Drawing;
using ChatDAO.SQL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ChatMessageDAOSQL();
            foreach(var item in db.AllMessage("minhduc@gmail.com", "congphuong@gmail.com"))
            {
                Console.WriteLine(item.Call.Duration);
            }
            Console.ReadLine();
        }
    }
}
