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
    public class UpdateAvatarResponseHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as UpdateAvatarResponseProtocol;
            var f = form as FormMain;

            if (ptc.IsSuccess == 0)
            {
                f.Invoke(new MethodInvoker(delegate ()
                {
                    MessageBox.Show("Thay đổi không thành công!");
                }));
                return;
            }

            f.Invoke(new MethodInvoker(delegate ()
            {
                f.UpdateAvatar(ptc.DriveFileId);
            }));
        }
    }
}
