using ClientSocket;
using LiveStream;
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
    public partial class FormLiveStream : Form
    {
        private IClient _client;
        private string _streamID = "";
        private MediaStream _mediaStream = new MediaStream();
        public FormLiveStream()
        {
            InitializeComponent();
            _mediaStream.OnVideoNewFrame += _mediaStream_OnVideoNewFrame;
            _mediaStream.StartVideo(_mediaStream.GetDefaultCamera().MonikerString);
        }

        public FormLiveStream(IClient client, string streamID)
        {
            _client = client;
            _streamID = streamID;
            _mediaStream.OnVideoNewFrame += _mediaStream_OnVideoNewFrame;
            _mediaStream.StartVideo(_mediaStream.GetDefaultCamera().MonikerString);
            InitializeComponent();
        }

        private void _mediaStream_OnVideoNewFrame(Bitmap frame, byte[] audioSample)
        {
            _ptbVideoView.Image = ImageConverter.ImageResize.ResizeImage(frame, 800, 450);
        }

        private void _btnSetting_Click(object sender, EventArgs e)
        {
            DeviceSetting deviceSetting = new DeviceSetting(_mediaStream);
            deviceSetting.ApplyDevices += DeviceSetting_ApplyDevices;
            deviceSetting.Location = new Point(this.Location.X + 100, this.Location.Y + 150);
            deviceSetting.ShowDialog();
        }

        private void DeviceSetting_ApplyDevices(AForge.Video.DirectShow.FilterInfo cameraInfo, CSCore.CoreAudioAPI.MMDevice microphoneInfo, CSCore.CoreAudioAPI.MMDevice speakerInfo)
        {
            //set lại các thông số cho stream;
        }
    }
}
