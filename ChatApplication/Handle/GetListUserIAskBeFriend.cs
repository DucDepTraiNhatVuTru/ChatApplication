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
    public class GetListUserIAskBeFriend : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as GetListFriendsResponseProtocol;

            lock (this)
            {
                Instance.ListUserAskAddFriend = ptc.ListAccount;
            }
        }
    }
}
