using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StreamProtocol.Protocol;
using ChatApplication.View;

namespace ChatApplication.StreamHandle
{
    public class StreamingHandle : IStreamHandle
    {
        public void Handling(IProtocol protocol, Form form)
        {
            var ptc = protocol as StreamingProtocol;
            if (!(form is FormWatchStream)) return;
            var f = form as FormWatchStream;

            if (!f.IsStream(ptc.StreamID)) return;

            f.Render(ptc.Image, ptc.Sound);
        }
    }
}
