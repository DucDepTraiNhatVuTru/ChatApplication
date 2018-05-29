using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketServer;
using SocketServer.SimpleTCP;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _server = new ServerSimpleTcp();
            Console.WriteLine("press enter to start server");
            Console.ReadLine();
            _server.Start("127.0.0.1", 2018);
            _server.OnNewConnect += _server_OnNewConnect;
            _server.OnNewMessage += _server_OnNewMessage;

            while (true )
            {
                int c = Console.Read();
                if (c == 0)
                {
                    break;
                }
            }
            _server.Stop();
        }

        private static void _server_OnNewMessage(IChatClient arg1, string arg2)
        {
            Console.WriteLine(arg1.GetEndPoint().ToString() + " : " + arg2);
        }

        private static void _server_OnNewConnect(IChatClient obj)
        {
            Console.WriteLine(obj.GetEndPoint().ToString());
        }
    }
}
