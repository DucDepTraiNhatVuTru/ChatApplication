using ChatDataModel;
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

namespace ChatApplication
{
    public partial class FormCall : Form
    {
        private IAudioCall _phoneCall;
        private Account _account;
        public FormCall()
        {
            InitializeComponent();
        }

        public FormCall(IAudioCall phoneCall, Account account)
        {
            InitializeComponent();
            _account = account;
            _phoneCall = phoneCall;

            _lbCallTo.Text = "Bạn đang gọi cho " + _account.Name;

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\ThucTap\ChatApplication\ChatApplication\Asset\phone-calling-1.wav");

            Thread thread = new Thread(delegate ()
            {
                player.Play();
                player.PlayLooping();
            });
            thread.Start();

            this.FormClosed += delegate
            {
                player.Stop();
                thread.Abort();
            };
        }

        private void FormCall_Load(object sender, EventArgs e)
        {

        }

        private void _btnHangUp_Click(object sender, EventArgs e)
        {
            _phoneCall.HangUp();
            this.Close();
        }
    }
}
