using System;
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
                    formChat.Invoke(new MethodInvoker(delegate ()
                    {
                        formChat.ReceiveTextMessage(ptc.Message);
                    }));
                }
                else
                {
                    f.OpenFormChat(ptc.Message.Sender);
                    Thread.Sleep(50);
                    if (f.FormChatOpening.TryGetValue(ptc.Message.Sender, out formChat))
                    {
                        formChat.Invoke(new MethodInvoker(delegate ()
                        {
                            formChat.ReceiveTextMessage(ptc.Message);
                        }));
                    }
                }
            }));
        }
    }
}
