﻿using ChatProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPSocketServer.Handle
{
    public interface IHandle
    {
        string Handling(IProtocol protocol, EndPoint sender);
    }
}
