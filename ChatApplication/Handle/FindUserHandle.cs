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
    public class FindUserHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GetListFriendsResponseProtocol;
            if (!(form is FormFindFriends)) return;
            var f = form as FormFindFriends;
            f.Invoke(new MethodInvoker(delegate ()
            {
                f.LoadUserResult(ptc.ListAccount);
            }));
        }
    }
}
