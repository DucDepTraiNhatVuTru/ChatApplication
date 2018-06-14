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
    public class AddUserToGroupHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as AddUserInGroupResponseProtocol;
            if (!(form is FormMain)) return;
            var f = form as FormMain;
            f.Invoke(new MethodInvoker(delegate ()
            {
                f.SendRequestGetUserInGroup(ptc.GroupId);
            }));
        }
    }
}
