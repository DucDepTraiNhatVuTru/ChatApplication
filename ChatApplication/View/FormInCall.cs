using ChatDataModel;
using GoogleDriveApiv3;
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
    public partial class FormInCall : Form
    {
        private IAudioCall _phoneCall;
        private Account _account;
        private int sec = 0;
        private int min = 0;
        public FormInCall()
        {
            InitializeComponent();
            _timerThoiLuongCuocGoi.Start();
            _timerThoiLuongCuocGoi.Tick += _timerThoiLuongCuocGoi_Tick;
        }
        public FormInCall(string name)
        {
            InitializeComponent();
            _timerThoiLuongCuocGoi.Start();
            _timerThoiLuongCuocGoi.Tick += _timerThoiLuongCuocGoi_Tick;
            _lbName.Text = name;
        }
        public FormInCall(IAudioCall phoneCall, Account account)
        {
            InitializeComponent();
            _phoneCall = phoneCall;
            _account = account;
            _lbName.Text = _account.Name;
            _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
    
            _timerThoiLuongCuocGoi.Interval = 1000;
            _timerThoiLuongCuocGoi.Start();
            _timerThoiLuongCuocGoi.Tick += _timerThoiLuongCuocGoi_Tick;

            Thread thread = new Thread(delegate ()
            {
                var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile((_account.AvatarDriveID)));
                _ptbAvatar.Invoke(new MethodInvoker(delegate ()
                {
                    _ptbAvatar.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 70);
                }));
            });
            thread.Start();
        }

        private void _timerThoiLuongCuocGoi_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
            _lbtime.Text = min.ToString() + ":" + sec.ToString();
        }

        private void _btnHangUp_Click(object sender, EventArgs e)
        {
            _phoneCall.HangUp();
            //gửi server lưu lại cuộc gọi
            this.Close();
        }

        private void FormInCall_FormClosed(object sender, FormClosedEventArgs e)
        {
            _phoneCall.HangUp();
        }
    }
}
