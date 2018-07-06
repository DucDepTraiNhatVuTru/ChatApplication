using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Ozeki.Media;
using Ozeki.VoIP;
using Ozeki.Camera;

namespace PhoneCall.Ozeki
{
    public class OzekiGroupCall : IGroupCall
    {
        private ISoftPhone softPhone;
        private IPhoneLine phoneLine;
        private RegState phoneLineInformation;
        private IPhoneCall call;
        SIPAccount sipAccount;
        ConferenceRoom conferenceRoom;
        OzekiCamera camera;

        public OzekiGroupCall()
        {
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
            softPhone.IncomingCall += SoftPhone_IncomingCall;
        }

        private void SoftPhone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            throw new NotImplementedException();
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

        private void PhoneLine_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            throw new NotImplementedException();
        }
        public void InitializeConferenceRoom()
        {
            conferenceRoom = new ConferenceRoom();
            conferenceRoom.StartConferencing();
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
    }
}
