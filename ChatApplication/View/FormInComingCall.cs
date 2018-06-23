using PhoneCall;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class FormInComingCall : Form
    {
        private IAudioCall _call;
        public FormInComingCall()
        {
            InitializeComponent();
        }

        public FormInComingCall(IAudioCall call, string caller)
        {
            InitializeComponent();
            _call = call;
            
            _lbCaller.Text = caller + " đang gọi cho bạn!";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\ThucTap\ChatApplication\ChatApplication\Asset\telephone-ring-01a.wav");
            
            Thread thread = new Thread(delegate ()
            {
                radWaitingBar1.StartWaiting();
                player.Play();
                player.PlayLooping();
            });
            thread.Start();

            this.FormClosed +=delegate{
                player.Stop();
                thread.Abort();
            };
        }

        private void _btnPickUp_Click(object sender, EventArgs e)
        {
            _call.Answer();
            this.Close();
        }

        private void _btnTuChoi_Click(object sender, EventArgs e)
        {
            _call.Reject();
            this.Close();
        }
    }
}
