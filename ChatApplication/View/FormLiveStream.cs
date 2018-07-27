using AForge.Video.DirectShow;
using ClientSocket;
using CSCore.CoreAudioAPI;
using LiveStream;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class FormLiveStream : Form
    {
        private IClient _client;
        private string _streamID = "";
        private MediaStream _mediaStream = new MediaStream();
        private UDPClient.IClient _streamClient;
        private IPEndPoint _serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2019);
        public FormLiveStream()
        {
            InitializeComponent();

            _mediaStream.OnVideoNewFrame += _mediaStream_OnVideoNewFrame;
            _mediaStream.StartVideo(_mediaStream.GetDefaultCamera().MonikerString);
            _mediaStream.RecordAudio(_mediaStream.GetDefaultMicrophone());
            _mediaStream.StartAudio(_mediaStream.GetDefaultSpeaker());
        }

        public FormLiveStream(IClient client, string streamID)
        {
            _client = client;
            _streamClient = new UDPClient.UDPClient();
            _streamID = streamID;

            _mediaStream.OnVideoNewFrame += _mediaStream_OnVideoNewFrame;
            _mediaStream.StartVideo(_mediaStream.GetDefaultCamera().MonikerString);
            _mediaStream.RecordAudio(_mediaStream.GetDefaultMicrophone());
            _mediaStream.StartAudio(_mediaStream.GetDefaultSpeaker());

            InitializeComponent();

            _streamClient.RequestStartStream(_streamID, _serverAddress);
        }

        private void _mediaStream_OnVideoNewFrame(Bitmap frame, byte[] audioSample)
        {
            _ptbVideoView.Image = ImageConverter.ImageResize.ResizeImage(frame, 800, 450);
            Thread thread = new Thread(delegate ()
            {
                _streamClient.SendStream(_streamID, ImageConverter.ImageConverter.ConvertImageToByteArray(frame), audioSample, _serverAddress);
            });
            thread.Start();
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
            StopMedia();
            StartMedia(cameraInfo, microphoneInfo, speakerInfo);
        }

        private void StartMedia(FilterInfo camera, MMDevice microphone, MMDevice speaker)
        {
            _mediaStream.StartVideo(camera.MonikerString);
            _mediaStream.RecordAudio(microphone);
            _mediaStream.StartAudio(speaker);
        }

        private void StopMedia()
        {
            _mediaStream.StopVideo();
            _mediaStream.StopAudio();
        }

        private void FormLiveStream_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMedia();
        }
    }
}
