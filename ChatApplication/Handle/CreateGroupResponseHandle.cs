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
    public class CreateGroupResponseHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as CreateGroupResponseProtocol;
            var f = form as FormMain;
            f.Invoke(new MethodInvoker(delegate ()
            {
                if (ptc.IsSuccess == 1) f.LoadGroupList(ptc.Groups);
            }));
        }
    }
}
