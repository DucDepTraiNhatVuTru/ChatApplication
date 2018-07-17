using Ozeki.Camera;
using Ozeki.Media;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormChung;
using AForge.Imaging;

namespace LiveStream.Ozeki
{
    public class OzekiLiveStream { 
        private ISoftPhone softPhone;
        private IPhoneLine phoneLine;
        private RegState phoneLineInformation;
        private IPhoneCall call;
        SIPAccount sipAccount;
        ConferenceRoom conferenceRoom;
        OzekiCamera camera;
        private MediaConnector connector = new MediaConnector();
        private Microphone microphone = Microphone.GetDefaultDevice();
        private Speaker speaker = Speaker.GetDefaultDevice();
        private PhoneCallAudioSender audioSender = new PhoneCallAudioSender();
        private PhoneCallAudioReceiver audioReceiver = new PhoneCallAudioReceiver();
        private PhoneCallVideoSender videoSender = new PhoneCallVideoSender();
        private PhoneCallVideoReceiver videoReceiver = new PhoneCallVideoReceiver();
        private ImageProvider<System.Drawing.Image> provider;

        public OzekiLiveStream()
        {
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
            softPhone.IncomingCall += SoftPhone_IncomingCall;
            conferenceRoom = new ConferenceRoom();
            conferenceRoom.StartConferencing();
        }

        public void Register(string streamID)
        {
            sipAccount = new SIPAccount(true, streamID, streamID, streamID, streamID, "192.168.0.86", 5060);
            try
            {
                phoneLine = softPhone.CreatePhoneLine(sipAccount);
                phoneLine.RegistrationStateChanged += PhoneLine_RegistrationStateChanged;
                softPhone.RegisterPhoneLine(phoneLine);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void StartCamera()
        {

            var data = new CameraURLBuilderData { DeviceTypeFilter = DiscoverDeviceType.USB };
            var myCameraBuilder = new CameraURLBuilderWF(data);
            var result = myCameraBuilder.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            camera = new OzekiCamera(myCameraBuilder.CameraURL);
            camera.Start();
        }

        public void ConnectMicrophone()
        {
            if (microphone != null)
            {
                connector.Connect(microphone, audioSender);
            }
        }

        public void ConnectSpeaker()
        {
            if (speaker != null)
            {
                connector.Connect(audioReceiver, speaker);
            }
        }

        public void ConnectLiverProvider()
        {
            provider = new DrawingImageProvider();
            connector.Connect(camera.VideoChannel, provider);
        }
    
        public void ConnectViewerProvider()
        {
            provider = new DrawingImageProvider();
            connector.Connect(videoReceiver, provider);
        }

        public void ConnectVideoSender()
        {
            if (camera != null)
                connector.Connect(camera.VideoChannel, videoSender);
        }

        public void ConnectVideoReceiver()
        {
            connector.Connect(videoReceiver, provider);
        }

        public void ConnectAudioSender()
        {
            connector.Connect(microphone, audioSender);
        }

        public void ConnectAudioReceiver()
        {
            connector.Connect(audioReceiver, speaker);
        }

        public void StartMicrophone()
        {
            if (microphone != null)
                microphone.Start();
        }

        public void StartSpeaker()
        {
            if (speaker != null)
                speaker.Start();
        }

        public void ShowUI()
        {
            Form form = new Form();
            form.Size = new Size(1080, 490);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.Text = "Video trực tiếp";

            VideoViewerWF videoViewer = new VideoViewerWF();
            videoViewer.Location = new Point(0, 0);
            videoViewer.Size = new Size(800, 450);
            videoViewer.SetImageProvider(provider);
            videoViewer.Start();
            form.Controls.Add(videoViewer);

            CommentBoxControl commentControls = new CommentBoxControl();
            commentControls.Location = new Point(810, 0);
            form.Controls.Add(commentControls);

            form.ShowDialog();
        }

        private void PhoneLine_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {

        }

        private void SoftPhone_IncomingCall(object sender, global::Ozeki.Media.VoIPEventArgs<IPhoneCall> e)
        {
            call = e.Item;
            call.Answer();
            AttachSendCall();
        }

        public void CreateCallToStream(string dial)
        {
            call = softPhone.CreateCallObject(phoneLine, dial);
            StartEvent();
            call.ModifyCallType(CallType.AudioVideo);
            call.Start();
        }

        public void StartStream()
        {
            StartCamera();
            StartMicrophone();
            ConnectMicrophone();
            ConnectVideoSender();
            ConnectLiverProvider();
            ShowUI();
        }

        public void WatchStream(string streamID)
        {
            CreateCallToStream(streamID);
            ConnectSpeaker();
            ShowUI();
        }

        public void StartEvent()
        {
            call.CallStateChanged += Call_CallStateChanged;
        }

        public void StopEvent()
        {
            call.CallStateChanged -= Call_CallStateChanged;
        }

        public void AttachReceiveCall()
        {
            videoReceiver.AttachToCall(call);
            audioReceiver.AttachToCall(call);
        }

        public void AttachSendCall()
        {
            videoSender.AttachToCall(call);
            audioReceiver.AttachToCall(call);
        }

        private void Call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            if (e.State == CallState.Answered)
            {
                MessageBox.Show("tra loi");
                StartSpeaker();
                StartMicrophone();
                AttachSendCall();
                AttachReceiveCall();
                ConnectViewerProvider();
            }
        }
    }
}
