﻿using ChatDataModel;
using Ozeki.Media;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall
{
    public interface IAudioCall
    {
        void RegisterAccount(ChatDataModel.Account account);
        event Action PhoneLineRegisterStateChange;
        void ConnectMedia();
        void DisconnectMedia();
        event Action<string> SoftPhoneInComingCall;
        event Action<int> CallStateChange;
        void CreateCall(string dial);
        void Answer();
        IPhoneCall GetPhoneCall();
        RegState GetPhoneLineInformation();
    }
}
