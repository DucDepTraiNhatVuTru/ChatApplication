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
    public class GetUserInGroupHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc =protocol as GetUserInGroupResponseProtocol;
            //if (!(form is FormMain)) return;
            var f = form as FormMain;

            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChatGroups formChatGroups;
                if(f.FormChatGroupsOpening.TryGetValue(ptc.GroupId,out formChatGroups))
                {
                    formChatGroups.Invoke(new MethodInvoker(delegate ()
                    {
                        formChatGroups.LoadListUserInGroup(ptc.Accounts);
                    }));
                }
            }));
        }
    }
}
