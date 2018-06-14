using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;
using ChatApplication.View;

namespace ChatApplication.Handle
{
    public class HistoryChatGroupHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as HistoryChatGroupResponseProtocol;
            var f = form as FormMain;
            var message= ptc.Messages[0];
            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChatGroups formChatGroup;
                if (f.FormChatGroupsOpening.TryGetValue(message.GroupReceive,out formChatGroup))
                {
                    formChatGroup.Invoke(new MethodInvoker(delegate ()
                    {
                        formChatGroup.AddWaitingBar();
                        formChatGroup.messages = ptc.Messages;
                        formChatGroup.LoadHistory();
                    }));
                }
            }));
        }
    }
}
