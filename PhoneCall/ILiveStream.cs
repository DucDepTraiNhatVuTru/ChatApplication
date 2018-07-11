using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall
{
    public interface ILiveStream
    {
        void Register(string streamId);
        bool StartCamera();
        void ConnectMicrophone();
        void ConnectSpeaker();
        void ConnectProvider();
        void ConnectVideoSender();
        void StartMicrophone();
        void StartSpeaker();
        void StartCamrera();
        void ShowUI();
    }
}
