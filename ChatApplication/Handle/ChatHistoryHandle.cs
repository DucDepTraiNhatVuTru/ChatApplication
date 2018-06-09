using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;
using ChatApplication.View;
using ChatApplication.Util;

namespace ChatApplication.Handle
{
    public class ChatHistoryHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as HistoryChatResponseProtocol;
            var f = form as FormMain;

            var message = ptc.Messages[0];
            string currentUser = "";
            string key = "";
            lock (this)
            {
                currentUser = Instance.CurrentUser.Email;
            }
            if (message.Sender == currentUser)
            {
                key = message.Receiver;
            }
            else
            {
                key = message.Sender;
            }
            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChat formChat;
                if(f.FormChatOpening.TryGetValue(key,out formChat))
                {
                    formChat.Invoke(new MethodInvoker(delegate ()
                    {
                        formChat.AllMessage = ptc.Messages;
                        formChat.AddMessageHistory();
                        formChat.Show();
                    }));
                }
            }));
        }
    }
}
