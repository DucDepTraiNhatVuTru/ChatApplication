using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO
{
    public interface ILiveStreamDAO
    {
        int Insert(ChatDataModel.LiveStream liveStream);
    }
}
