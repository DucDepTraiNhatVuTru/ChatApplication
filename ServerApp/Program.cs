using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketServer;
using SocketServer.SimpleTCP;
using PBX.OzekiPBX;
using System.Threading;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _server = new ServerSimpleTcp();
            var _streamServer = new UDPSocketServer.UDPServer();
            /*var _PBX = new OzekiPBX();
            _PBX.SetUp(5060);*/
            Console.WriteLine("press enter to start server");
            Console.ReadLine();
            _server.Start("127.0.0.1", 2018);
            Thread thread = new Thread(delegate ()
            {
                _streamServer.Start("127.0.0.1", 2019);
                _streamServer.Recieve();
            });
            thread.Start();
            _streamServer.OnReceive += _streamServer_OnReceive;
            Console.WriteLine("server start at 127.0.0.1:2018");
            Console.WriteLine("stream server at 127.0.0.1:2019");
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

        private static void _streamServer_OnReceive(string obj)
        {
            Console.WriteLine(obj);
        }

        private static void _server_OnNewMessage(IChatClient arg1, string arg2)
        {
            Console.WriteLine(arg2);
        }

        private static void _server_OnNewConnect(IChatClient obj)
        {
            Console.WriteLine(obj.GetEndPoint().ToString());
        }
    }
}
