﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;
using ChatApplication.View;
using System.Threading;

namespace ChatApplication.Handle
{
    public class GetListFriendsResponseHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GetListFriendsResponseProtocol;
            var f = form as FormMain;

            f.Invoke(new MethodInvoker(delegate ()
            {
                f.LoadFriendList(ptc.ListAccount);
                /*Thread thread = new Thread(delegate ()
                {
                   
                });
                thread.Start();*/
            }));
        }
    }
}