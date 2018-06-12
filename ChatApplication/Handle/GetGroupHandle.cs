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
    public class GetGroupHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GetGroupChatResponseProtocol;
            var f = form as FormMain;
            Instance.ListGroups = ptc.Groups;
            f.Invoke(new MethodInvoker(delegate ()
            {
                f.LoadGroupList(ptc.Groups);
            }));
        }
    }
}
