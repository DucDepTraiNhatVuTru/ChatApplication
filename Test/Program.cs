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
            IGroupDAO db = new GroupsDAOSQL();
            var l = db.GetListGroup("minhduc@gmail.com");
            foreach(var item in l)
            {
                Console.WriteLine(item.Name);
            }
            
            Console.ReadLine();
        }
    }
}
