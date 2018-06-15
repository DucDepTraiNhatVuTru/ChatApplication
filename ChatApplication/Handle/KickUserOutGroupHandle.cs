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
    public class KickUserOutGroupHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as KickUserOutGroupResponseProtocol;
            var f = form as FormMain;

            f.Invoke(new MethodInvoker(delegate ()
            {
                FormChatGroups formChatGroup;
                if(f.FormChatGroupsOpening.TryGetValue(ptc.GroupId,out formChatGroup))
                {
                    formChatGroup.Invoke(new MethodInvoker(delegate ()
                    {
                        if (ptc.IsSuccess == 1) formChatGroup.RemoveItemInListUserInGroup(ptc.Email);
                        else formChatGroup.ShowMessage(ptc.Message, "Thông Báo");
                    }));
                }
            }));
        }
    }
}
