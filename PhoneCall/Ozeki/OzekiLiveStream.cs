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

namespace PhoneCall.Ozeki
{
    public class OzekiLiveStream:ILiveStream
    {
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
        private ImageProvider<Image> provider = new DrawingImageProvider();

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

        public bool StartCamera()
        {
            if (Instance.IsLocalCameraUsed == false)
            {
                var data = new CameraURLBuilderData { DeviceTypeFilter = DiscoverDeviceType.USB };
                var myCameraBuilder = new CameraURLBuilderWF(data);
                var result = myCameraBuilder.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return false;
                }

                camera = new OzekiCamera(myCameraBuilder.CameraURL);
                camera.Start();
            }
            return true;
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

        public void ConnectProvider()
        {
            connector.Connect(videoReceiver, provider);
        }

        public void ConnectVideoSender()
        {
            if (camera != null)
                connector.Connect(camera.VideoChannel, videoSender);
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

        public void StartCamrera()
        {
            if (camera != null)
                camera.Start();
        }

        public void ShowUI()
        {
            Form form = new Form();
            form.Size = new Size(960, 450);

            VideoViewerWF videoViewer = new VideoViewerWF();
            videoViewer.Location = new Point(0, 0);
            videoViewer.Size = new Size(800, 450);

        }

        private void PhoneLine_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            throw new NotImplementedException();
        }

        private void SoftPhone_IncomingCall(object sender, global::Ozeki.Media.VoIPEventArgs<IPhoneCall> e)
        {
            throw new NotImplementedException();
        }
    }
}
