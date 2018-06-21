﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Ozeki.VoIP;
using Ozeki.Media;
using Ozeki.Common;

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
        SIPAccount sipAccount;

        private bool inComingCall;

        private string reDialNumber;

        private bool localHeld;

        public event Action PhoneLineRegisterStateChange;
        public event Action SoftPhoneInComingCall;
        public event Action<int> CallStateChange;

        public OzekiAudioCall()
        {
           /* var licenseCode =
"UDoyMDMzLTEyLTI1LFVQOjIwMzMtMDEtMDEsTUNDOjMwLE1QTDozMCxNU0xDOjMwLE1GQzozMCxHNzI5OnRydWUsTVdQQzozMCxNSVBDOjMwfFg1dF" +
"BsTWRTNHNDeGFLa1Yyd3V5WHU5VGlOQkV4aG9KYit3WXdERDA3blRMWFh0WnYvOHRnQThLaGtoZ05XNVE5MjRUUjgwV1p4cVNFK0g2VGw2bHRRPT0=";
            var userName = "I-Warez 2015";
            LicenseManager.Instance.SetLicense(userName, licenseCode);*/
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
            softPhone.IncomingCall += SoftPhone_IncomingCall;
        }

        private void SoftPhone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            call = e.Item;

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
            MyCallState tmp;
            if (e.State == CallState.Answered)
            {
                StartDevices();
                mediaReceiver.AttachToCall(call);
                mediaSender.AttachToCall(call);
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
                WireDownCallEvents();
                call = null;
            }

            if (e.State == CallState.LocalHeld)
            {
                StopDevices();
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
        }

        public void RegisterAccount(ChatDataModel.Account account)
        {
            sipAccount = new SIPAccount(true, account.Name, account.Email, account.Email, account.Password, "192.168.0.109",5060);
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

        public IPhoneCall GetPhoneCall()
        {
            return call;
        }

        public RegState GetPhoneLineInformation()
        {
            return phoneLineInformation;
        }
    }
}