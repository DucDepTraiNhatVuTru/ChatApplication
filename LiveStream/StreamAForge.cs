using AForge.Video.DirectShow;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Streams.Effects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStream
{
    public class StreamAForge
    {
        private FilterInfoCollection _devices;
        private VideoCaptureDevice _video;
        //private MMDevice _audioDevices;
        private WasapiCapture _soundIn = new WasapiCapture(true, CSCore.CoreAudioAPI.AudioClientShareMode.Shared, 30);
        private IWaveSource _source;
        private DmoEchoEffect _echoSource;
        private WasapiOut _soundOut = new WasapiOut();
        private byte[] _buffer = new byte[1024];
        /* private WaveInEvent wavein;
         private WaveOutEvent waveout;
         private WaveFileWriter writer;*/
        //private AsioOut _audio = new AsioOut(AsioOut.GetDriverNames()[1]);
        public event Action<Bitmap,byte[]> OnVideoNewFrame;
        public FilterInfoCollection GetListDevices()
        {
            _devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return _devices;
        }

        public MMDeviceCollection GetListAudioDevices()
        {
            var deviceEnumerator = new MMDeviceEnumerator();
            var deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
            return deviceCollection;
        }
        
        public void StartVideo(string monikerString)
        {
            _video = new VideoCaptureDevice();
            if (_video.IsRunning) _video.Stop();
            _video = new VideoCaptureDevice(monikerString);
            _video.NewFrame += _video_NewFrame;
            _video.Start();
        }

        public void RecordAudio(MMDevice device)
        {
            _soundIn.Device = device;
            _soundIn.Initialize();
            var src = new SoundInSource(_soundIn);
            src.DataAvailable += (s, e) =>
             {
                 int read;
                 read = _source.Read(_buffer, 0, _buffer.Length);
             };
            //_source = new SoundInSource(_soundIn) { FillWithZeros = true };
            var singleBlockNotificationStream = new SingleBlockNotificationStream(src.ToSampleSource());
            //_echoSource = new DmoEchoEffect(_source);
            _source = singleBlockNotificationStream.ToWaveSource();
            _soundIn.Start();
        }

        private void _soundIn_DataAvailable(object sender, DataAvailableEventArgs e)
        {
            //StartAudio();
        }

        public void StartAudio()
        {
            _soundOut.Initialize(_source);
            _soundOut.Play();
        }

        public void StopVideo()
        {
            _video.Stop();
        }

        public void StopAudio()
        {
            _soundIn.Stop();
            _soundOut.Stop();
        }

        /*public void StartAudio()
        {
            _audio.InputChannelOffset = 4;
            var recordChanelCount = 0;
            var sampleRate = 44100;
            _audio.InitRecordAndPlayback(null, recordChanelCount, sampleRate);
            _audio.AudioAvailable += _audio_AudioAvailable;
            _audio.Play();
        }*/

        private void _video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            if (OnVideoNewFrame != null)
                OnVideoNewFrame.Invoke(frame,_buffer);
        }
    }
}
