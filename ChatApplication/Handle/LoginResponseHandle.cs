﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProtocol.Protocol;
using ChatApplication.View;
using System.Threading;
using ChatApplication.Util;

namespace ChatApplication.Handle
{
    public class LoginResponseHandle : IHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as LoginResponseProtocol;
            var f = form as FormLogin;
            if (ptc.IsAccept == 0)
            {
                MessageBox.Show("sai tên tài khoản hoặc mật khẩu. \n Vui lòng kiểm tra lại", "Thông Báo");
                return;
            }

            lock (this)
            {
                Instance.CurrentUser = ptc.Account;
            }

            f.Invoke(new MethodInvoker(delegate ()
            {
                f.Hide();
                f.ExitEventReceive();
                Thread thread = new Thread(delegate ()
                {
                    FormMain main = new FormMain(f.GetClient(), ptc.Account);
                    main.ShowDialog();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                f.Close();
            }));
            
        }
    }
}
