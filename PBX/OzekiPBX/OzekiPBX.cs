using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBX.OzekiPBX
{
    public class OzekiPBX : IPBX
    {
        private PBXBase _PBX;
        public OzekiPBX()
        {
            _PBX = new PBXBase(20000, 30000);
        }

        public OzekiPBX(int minPort, int maxPort)
        {
            _PBX = new PBXBase(minPort, maxPort);
        }

        public void SetUp(int port)
        {
            _PBX.SetListenPort(Ozeki.Network.NetworkAddressHelper.GetLocalIP().ToString(), port, Ozeki.Network.TransportType.Udp);
        }

        public void SetUp(string domain , int domainPort)
        {
            _PBX.SetListenPort(domain, domainPort, Ozeki.Network.TransportType.Udp);
        }

        public void Start()
        {
            _PBX.Start();
        }
    }
}
