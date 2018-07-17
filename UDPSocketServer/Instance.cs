using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPSocketServer
{
    public class Instance
    {
        //key là email của thằng streamm, value là danh sách EndPoin của mấy thằng xem Stream;
        public static Dictionary<string, List<EndPoint>> CurrentStream = new Dictionary<string, List<EndPoint>>();
    }
}
