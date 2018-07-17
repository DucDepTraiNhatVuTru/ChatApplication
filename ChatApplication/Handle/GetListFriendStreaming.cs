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
    public class GetListFriendStreaming : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            if (!(form is FormListLiveStream)) return;
            var f = form as FormListLiveStream;
            var ptc = protocol as GetListUserStreamResponseProtocol;
            f.Invoke(new MethodInvoker(delegate ()
            {
                f.LoadListUser(ptc.AccountStream);
            }));
        }
    }
}
