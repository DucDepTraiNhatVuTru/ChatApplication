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
            /*IChatMessageDAO db = new ChatMessageDAOSQL();
            var meslist = db.AllMessage("ngocdung@gmail.com","minhduc@gmail.com" );
            foreach(var item in meslist)
            {
                Console.WriteLine(item.Message);
            }*/
            IAccountDAO db = new AccountDAOSQL();
            /*object sunc = new object();
            List<Account> accs = new List<Account>();
            lock (sunc)
            {
                accs = db.GetFriendList("minhduc@gmail.com");
            }
            foreach(var item in accs)
            {
                Console.WriteLine(item.Email);
                Console.WriteLine(item.Name);
            }*/
            var l = db.EmailsFriends("minhduc@gmail.com");
            foreach(var item in l)
            {
                Console.WriteLine(item);
            }
            List<Account> accs = new List<Account>();

            foreach(var item in l)
            {
                accs.Add(db.GetAccount(item));
            }

            foreach (var item in accs)
            {
                Console.WriteLine(item.Email);
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
