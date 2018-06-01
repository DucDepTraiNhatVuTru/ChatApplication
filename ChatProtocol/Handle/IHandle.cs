﻿using ChatProtocol.Protocol;
using SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatProtocol.Handle
{
    public interface IHandle
    {
        string Handling(IProtocol protocol, IChatClient client);
        
    }
}
