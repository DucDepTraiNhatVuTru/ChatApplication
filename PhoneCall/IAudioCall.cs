using ChatDataModel;
using Ozeki.Media;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall
{
    public interface IAudioCall
    {
        bool IsShowFormCall { get; set; }
        void RegisterAccount(ChatDataModel.Account account);
        void RegisterGroup(ChatDataModel.Group group);
        event Action PhoneLineRegisterStateChange;
        void ConnectMedia();
        void DisconnectMedia();
        event Action<string> SoftPhoneInComingCall;
        event Action<MyCallState> CallStateChange;
        event Action FormVideoCallClose;
        void CreateCall(string dial);
        void Answer();
        void Reject();
        void HangUp();
        IPhoneCall GetPhoneCall();
        RegState GetPhoneLineInformation();
        void ModifyCallStyle(MyCallStyle style);
        string GetCallId();
        void InitializeConferenceRoom();
        void AddUserToRoom();
        ImageProvider<Image> GetRemoteProvider();
        ImageProvider<Image> GetLocalProvider();
        IVideoSender GetRemoteVideo();
        IVideoSender GetLocalVideo();
        void StartCamera();
        void ShowFormCall();
        bool IsICall { get; set; }
    }
}
