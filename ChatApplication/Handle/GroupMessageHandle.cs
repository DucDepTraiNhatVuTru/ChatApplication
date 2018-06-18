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
    public class GroupMessageHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GroupMessageProtocol;
            var f = form as FormMain;

            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChatGroups formChatGroup;
                if (f.FormChatGroupsOpening.TryGetValue(ptc.message.GroupReceive,out formChatGroup))
                {
                    formChatGroup.ReceiveMessage(ptc.message);
                }
            }));
        }
    }
}