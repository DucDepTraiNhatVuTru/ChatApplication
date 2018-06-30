using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PBX.OzekiPBX
{
    public class OzekiPBX : IPBX
    {
        private PBXBase _PBX;
        private IPAddress _PBXIP;
        public OzekiPBX()
        {
            _PBX = new PBXBase(20000, 30000);
        }

        public OzekiPBX(int minPort, int maxPort)
        {
            _PBX = new PBXBase(minPort, maxPort);
        }

        public IPAddress GetPBXIP()
        {
            return _PBXIP;
        }

        public void SetUp(int port)
        {
            _PBX.SetListenPort(Ozeki.Network.NetworkAddressHelper.GetLocalIP().ToString(), port, Ozeki.Network.TransportType.Udp);
            _PBXIP = Ozeki.Network.NetworkAddressHelper.GetLocalIP();
        }

        public void SetUp(string domain , int domainPort)
        {
            _PBX.SetListenPort(domain, domainPort, Ozeki.Network.TransportType.Udp);
            _PBXIP = IPAddress.Parse(domain);
        }

        public void Start()
        {
            _PBX.Start();
        }
    }
}
