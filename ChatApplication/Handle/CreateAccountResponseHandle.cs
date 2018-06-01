using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;

namespace ChatApplication.Handle
{
    public class CreateAccountResponseHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var f = form as View.FormLogin;
            var ptc = protocol as CreateAccountResponseProtocol;
            if (ptc.IsSuccess == 0)
            {
                f.Invoke(new MethodInvoker(delegate ()
                {
                    f.CleanTextBox();
                }));
            }
            MessageBox.Show(ptc.Message);
        }
    }
}
