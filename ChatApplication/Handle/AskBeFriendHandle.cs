﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;
using ChatApplication.View;

namespace ChatApplication.Handle
{
    public class AskBeFriendHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GetUserRequestAddFriendResponseProtocol;
            if (!(form is FormMain)) return;
            var f = form as FormMain;
            if (f.IsHandleCreated)
            {
                f.Invoke(new MethodInvoker(delegate ()
                {
                    f.LoadListUserFriendRequest(ptc.Accounts);
                    f.UpdateFriendRequestCount(ptc.Count);
                }));
            }
        }
    }
}
