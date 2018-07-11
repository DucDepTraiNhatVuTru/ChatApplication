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
using System.Threading;

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
        Label _lbTime;
        public bool IsCameraStart { get; set; }
        public bool IsICall { get; set; }

        public event Action PhoneLineRegisterStateChange;
        public event Action<string> SoftPhoneInComingCall;
        public event Action<MyCallState> CallStateChange;
        public event Action FormVideoCallClose;
        public bool IsShowFormCall { get; set; }

        public OzekiAudioCall()
        {
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
            softPhone.IncomingCall += SoftPhone_IncomingCall;
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
                CallDuration();
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
                Instance.IsLocalCameraUsed = false;
                timer.Stop();
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
            if(e.State == CallState.Completed)
            {
                tmp = MyCallState.CallEnd;
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
            sipAccount = new SIPAccount(true, tach[0], tach[0], tach[0], tach[0], "192.168.0.86",5060);
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

            //if (camera != null)
            {
                //if (Instance.IsLocalCameraUsed == false)
                {
                    Instance.SendingVideo = camera.VideoChannel;
                    Instance.LocalProvider.Add(new DrawingImageProvider());
                    connector.Connect(Instance.SendingVideo, Instance.LocalProvider[Instance.LocalProvider.Count-1]);
                    Instance.IsLocalCameraUsed = true;
                }
                    connector.Connect(Instance.SendingVideo, videoSender);
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
                //connector.Disconnect(camera.VideoChannel, Instance.LocalProvider);
                connector.Disconnect(camera.VideoChannel, videoSender);
            }

            connector.Disconnect(videoReceiver, remoteProvider);
        }

        public void CreateCall(string dial)
        {
            call = softPhone.CreateCallObject(phoneLine, dial);
            WireUpCallEvents();
            call.Start();
            IsICall = true;
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

        private bool IsCameraStarted = true;
        private int min = 0;
        private int sec = 0;
        public void ShowFormCall()
        {
            Form form = new Form();
            form.Text = "cuộc gọi video";
            form.Size = new Size(800, 500);
            form.BackColor = Color.White;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.FormClosing += Form_FormClosing;

            Button closeCamera = new Button();
            closeCamera.Location = new Point(655, 200);
            closeCamera.Size = new Size(125, 25);
            closeCamera.Text = "Tắt camera";
            closeCamera.Click += CloseCamera_Click;

            Button hangUp = new Button();
            hangUp.Location = new Point(655, 235);
            hangUp.Size = new Size(125, 25);
            hangUp.Text = "Tắt máy";
            hangUp.Click += HangUp_Click;

            _lbTime = new Label();
            _lbTime.Location = new Point(710, 325);
            _lbTime.Text = "Đang gọi ... ";

            VideoViewerWF remoteViewer = new VideoViewerWF();
            remoteViewer.Location = new Point(0, 0);
            remoteViewer.Size = new Size(650, 500);
            remoteViewer.SetImageProvider(remoteProvider);
            remoteViewer.Start();

            VideoViewerWF localViewer = new VideoViewerWF();
            localViewer.Location = new Point(655, 350);
            localViewer.Size = new Size(150, 150);
            localViewer.SetImageProvider(Instance.LocalProvider[Instance.LocalProvider.Count-1]);
            localViewer.Start();

            form.Controls.Add(_lbTime);
            form.Controls.Add(hangUp);
            form.Controls.Add(closeCamera);
            form.Controls.Add(remoteViewer);
            form.Controls.Add(localViewer);
            form.ShowDialog();

            IsShowFormCall = true;
        }



        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsShowFormCall = false;
            try
            {
                call.HangUp();
            }
            catch
            {}
            if (FormVideoCallClose != null)
                FormVideoCallClose.Invoke();
        }

        private void HangUp_Click(object sender, EventArgs e)
        {
            var hangupButton = sender as Button;
            hangupButton.FindForm().Close();
            try
            {
                call.HangUp();
            }
            catch{ }
        }

        private void CloseCamera_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            if (IsCameraStarted)
            {
                currentButton.Text = "Mở Camera";
                IsCameraStarted = false;
                camera.Stop();
            }
            else if (!IsCameraStarted)
            {
                currentButton.Text = "Tắt Camera";
                IsCameraStarted = true ;
                StartCamera();
                ConnectMedia();
            }
        }

        System.Timers.Timer timer;
        public void CallDuration()
        {
            timer = new System.Timers.Timer(1000);
            //timer.Interval = 1000;
            timer.Enabled = true;
            //timer.Elapsed += new EEventHandler(Timer_Tick);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var tick = sender as System.Windows.Forms.Timer;
            sec++;
            _lbTime.Invoke(new MethodInvoker(delegate ()
            {
                _lbTime.Text = TimeSpan.FromSeconds(sec).ToString(@"mm\:ss");
            }));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào!");
            var tick = sender as System.Windows.Forms.Timer;
            sec++;
            _lbTime.Invoke(new MethodInvoker(delegate ()
            {
                _lbTime.Text = TimeSpan.FromSeconds(sec).ToString(@"mm\:ss");
            }));
        }

        public int GetDuration()
        {
            return sec;
        }
    }
}
