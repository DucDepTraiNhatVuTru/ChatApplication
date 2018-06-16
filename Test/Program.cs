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
            /* IAccountDAO db = new AccountDAOSQL();
             var l = db.GetListFriendNotInGroup("minhduc@gmail.com","abcd");
             foreach(var item in l)
             {
                 Console.WriteLine(item.Name);
             }*/
            IAccountDAO db = new AccountDAOSQL();
            var l = db.FindUserExceptFriend("minhduc@gmail.com", "công vinh");
            foreach (var item in l)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
