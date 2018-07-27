using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Util
{
    public class ServerInfo
    {
        public static IPEndPoint StreamServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2019);
    }
}
