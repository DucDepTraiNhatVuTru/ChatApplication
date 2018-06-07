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
    public class MessageHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as MessageProtocol;
            var f = form as FormMain;

            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChat formChat = null;
                if(f.FormChatOpening.TryGetValue(ptc.Message.Sender, out formChat))
                {
                    //formChat.ReceiveTextMessage(ptc.Message);
                    formChat.Invoke(new MethodInvoker(delegate ()
                    {
                        formChat.ReceiveTextMessage(ptc.Message);
                    }));
                }
            }));
        }
    }
}