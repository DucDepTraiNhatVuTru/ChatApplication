using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Ozeki.VoIP;
using Ozeki.Media;
using Ozeki.Common;
using Ozeki.Camera;
using System.Drawing;
using System.Windows.Forms;

namespace PhoneCall.Ozeki
{
    public class OzekiAudioCall : IAudioCall
    {
        private ISoftPhone softPhone;
        private IPhoneLine phoneLine;
        private RegState phoneLineInformation;
        private IPhoneCall call;
        private Microphone microphone = Microphone.GetDefaultDevice();
        private Speaker speaker = Speaker.GetDefaultDevice();
        MediaConnector connector = new MediaConnector();
        PhoneCallAudioSender mediaSender = new PhoneCallAudioSender();
        PhoneCallAudioReceiver mediaReceiver = new PhoneCallAudioReceiver();
        PhoneCallVideoReceiver videoReceiver = new PhoneCallVideoReceiver();
        PhoneCallVideoSender videoSender = new PhoneCallVideoSender();
        SIPAccount sipAccount;
        ConferenceRoom conferenceRoom;
        OzekiCamera camera;
        ImageProvider<Image> remoteProvider = new DrawingImageProvider();
        ImageProvider<Image> localProvider = new DrawingImageProvider();
        IVideoSender remoteVideo, localVideo;
        private IPhoneCall _grCall;

        private bool inComingCall;

        private string reDialNumber;

        private bool localHeld;

        public event Action PhoneLineRegisterStateChange;
        public event Action<string> SoftPhoneInComingCall;
        public event Action<MyCallState> CallStateChange;

        public OzekiAudioCall()
        {
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
            softPhone.IncomingCall += SoftPhone_IncomingCall;
        }

        public void StartCamera()
        {
            var data = new CameraURLBuilderData { DeviceTypeFilter = DiscoverDeviceType.USB };
            var myCameraBuilder = new CameraURLBuilderWF(data);
            var result = myCameraBuilder.ShowDialog();
            if(result!= System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            camera = new OzekiCamera(myCameraBuilder.CameraURL);
            camera.Start();
        }

        public void InitializeConferenceRoom()
        {
            conferenceRoom = new ConferenceRoom();
            conferenceRoom.StartConferencing();
        }

        private void SoftPhone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            call = e.Item;
            WireUpCallEvents();
            if (SoftPhoneInComingCall != null)
            {
                SoftPhoneInComingCall.Invoke(call.DialInfo.CallerDisplay);
            }
        }

        private void WireUpCallEvents()
        {
            call.CallStateChanged += Call_CallStateChanged;
        }

        private void WireDownCallEvents()
        {
            call.CallStateChanged -= Call_CallStateChanged;
        }

        private void Call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            IPhoneCall grCall = sender as IPhoneCall;
            _grCall = grCall;
            MyCallState tmp = MyCallState.DoNotthing;
            if (e.State == CallState.Answered)
            {
                StartDevices();
                mediaReceiver.AttachToCall(call);
                mediaSender.AttachToCall(call);
                videoReceiver.AttachToCall(call);
                videoSender.AttachToCall(call);
                tmp = MyCallState.Answered;
            }

            if (e.State == CallState.InCall)
            {
                StartDevices();
                tmp = MyCallState.InCall;
            }

            if (e.State.IsCallEnded() == true)
            {
                StopDevices();
                mediaReceiver.Detach();
                mediaSender.Detach();
                videoSender.Detach();
                videoReceiver.Detach();
                WireDownCallEvents();
                call = null;
                tmp = MyCallState.CallEnd;
            }

            if (e.State == CallState.LocalHeld)
            {
                StopDevices();
            }
            if (e.State == CallState.Busy)
            {
                StopDevices();
                tmp = MyCallState.Busy;
            }
            if (e.State == CallState.Cancelled)
            {
                StopDevices();
                tmp = MyCallState.Canceled;
            }
            if (CallStateChange != null)
            {
                CallStateChange.Invoke(tmp);
            }
        }

        private void StartDevices()
        {
            if (microphone != null)
            {
               microphone.Start();
            }

            if (speaker != null)
            {
                speaker.Start();
            }

            if (camera != null)
            {
                camera.Start();
            }
        }

        private void StopDevices()
        {
            if (microphone != null)
            {
                microphone.Stop();
            }

            if (speaker != null)
            {
                speaker.Stop();
            }

            if (camera != null)
            {
                camera.Stop();
            }
        }

        public void RegisterAccount(ChatDataModel.Account account)
        {
            var tach = account.Email.Split('@');
            sipAccount = new SIPAccount(true, tach[0], tach[0], tach[0], tach[0], "192.168.0.109",5060);
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

        private void PhoneLine_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            if (PhoneLineRegisterStateChange != null)
            {
                PhoneLineRegisterStateChange.Invoke();
            }
        }

        public void ConnectMedia()
        {
            if (microphone != null)
            {
                connector.Connect(microphone, mediaSender);
            }

            if (speaker != null)
            {
                connector.Connect(mediaReceiver, speaker);
            }

            if (camera != null)
            {
                connector.Connect(camera.VideoChannel,localProvider);
                connector.Connect(camera.VideoChannel, videoSender);
            }

            connector.Connect(videoReceiver,remoteProvider);
        }

        public void DisconnectMedia()
        {
            if (microphone != null)
            {
                connector.Disconnect(microphone, mediaSender);
            }

            if (speaker != null)
            {
                connector.Disconnect(mediaReceiver, speaker);
            }

            if(camera!= null)
            {
                connector.Disconnect(camera.VideoChannel, localProvider);
                connector.Disconnect(camera.VideoChannel, videoSender);
            }

            connector.Disconnect(videoReceiver, remoteProvider);
        }

        public void CreateCall(string dial)
        {
            call = softPhone.CreateCallObject(phoneLine, dial);
            WireUpCallEvents();
            call.Start();
        }

        public void Answer()
        {
            call.Answer();
        }

        public void Reject()
        {
            call.Reject();
        }

        public void HangUp()
        {
            call.HangUp();
        }
        public IPhoneCall GetPhoneCall()
        {
            return call;
        }

        public RegState GetPhoneLineInformation()
        {
            return phoneLineInformation;
        }

        public string GetCallId()
        {
            return call.CallID;
        }

        public void RegisterGroup(Group group)
        {
            sipAccount = new SIPAccount(true, group.Name, group.Id, group.Id, "123456", "192.168.0.109", 5060);
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

        public void AddUserToRoom()
        {
            conferenceRoom.AddToConference(_grCall);
        }

        public void ModifyCallStyle(MyCallStyle style)
        {
            if (style == MyCallStyle.Audio)
            {
                call.ModifyCallType(CallType.Audio);
            }else if (style == MyCallStyle.Video)
            {
                call.ModifyCallType(CallType.Video);
            }else if (style == MyCallStyle.AudioVideo)
            {
                call.ModifyCallType(CallType.AudioVideo);
            }
        }

        public ImageProvider<Image> GetRemoteProvider()
        {
            return remoteProvider;
        }

        public ImageProvider<Image> GetLocalProvider()
        {
            return localProvider;
        }

        public IVideoSender GetRemoteVideo()
        {
            return remoteVideo;
        }

        public IVideoSender GetLocalVideo()
        {
            return localVideo;
        }

        public void ShowFormCall()
        {
            Form form = new Form();
            form.Size = new Size(774, 440);
            VideoViewerWF remoteViewer = new VideoViewerWF();
            remoteViewer.Location = new Point(0, 0);
            remoteViewer.Size = new Size(696, 434);
            remoteViewer.SetImageProvider(remoteProvider);
            remoteViewer.Start();

            VideoViewerWF localViewer = new VideoViewerWF();
            localViewer.Location = new Point(702, 375);
            localViewer.Size = new Size(69, 62);
            localViewer.SetImageProvider(localProvider);
            localViewer.Start();

            form.Size = new Size(774, 440);
            form.Controls.Add(remoteViewer);
            form.Controls.Add(localViewer);
            form.ShowDialog();
        }
    }
}
