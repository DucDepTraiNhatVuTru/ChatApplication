using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall
{
    public interface IGroupCall
    {
        void RegisterGroup(ChatDataModel.Group group);
        void InitializeConferenceRoom();
        bool StartCamera();
    }
}
