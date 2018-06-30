using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PBX
{
    public interface IPBX
    {
        void SetUp(int port);
        void SetUp(string domain, int domainPort);
        void Start();
        IPAddress GetPBXIP();
    }
}
