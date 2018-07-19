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
    public class MediaStream
    {
        private FilterInfoCollection _devices;
        private MMDeviceCollection _speakers;
        private MMDeviceCollection _microphones;
        private VideoCaptureDevice _video;
        private WasapiCapture _soundIn = new WasapiCapture(true, CSCore.CoreAudioAPI.AudioClientShareMode.Shared, 30);
        private IWaveSource _source;
        private WasapiOut _soundOut = new WasapiOut();
        private byte[] _buffer = new byte[1024];
        public event Action<Bitmap,byte[]> OnVideoNewFrame;
        public FilterInfoCollection GetCameraDevices()
        {
            _devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return _devices;
        }

        public MMDeviceCollection GetSpeakerDevices()
        {
            var deviceEnum = new MMDeviceEnumerator();
            _speakers = deviceEnum.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
            return _speakers;
        }

        public MMDeviceCollection GetMicrophoneDevices()
        {
            var deviceEnumerator = new MMDeviceEnumerator();
            _microphones = deviceEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
            return _microphones;
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
            if (_soundIn.RecordingState == RecordingState.Recording) _soundIn.Stop();
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

        public void StartAudio(MMDevice speaker)
        {
            if (_soundOut.PlaybackState == PlaybackState.Playing) _soundOut.Stop();
            _soundOut.Device = speaker;
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

        public FilterInfo GetDefaultCamera()
        {
            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return devices[0];
        }

        public MMDevice GetDefaultMicrophone()
        {
            var devicesEnum = new MMDeviceEnumerator();
            var devicesCollection = devicesEnum.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
            return devicesCollection[0];
        }

        public MMDevice GetDefaultSpeaker()
        {
            var devicesEnum = new MMDeviceEnumerator();
            var devicesCollection = devicesEnum.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
            return devicesCollection[0];
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
