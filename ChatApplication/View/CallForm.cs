using PhoneCall;
using PhoneCall.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class CallForm : Form
    {
        private IAudioCall _call = null;
        public CallForm()
        {
                
        }
        public CallForm(IAudioCall call)
        {
            InitializeComponent();
            _call = call;
            _call.ModifyCallStyle(MyCallStyle.AudioVideo);
            _call.StartCamera();
            _call.ConnectMedia();
            CallView callView = new CallView();
            this.Controls.Add(callView);
            this.Size = callView.Size;
            callView.SetRemoteProvider(_call.GetRemoteProvider());
            callView.SetLocalProvider(_call.GetLocalProvider());
        }


    }
}
