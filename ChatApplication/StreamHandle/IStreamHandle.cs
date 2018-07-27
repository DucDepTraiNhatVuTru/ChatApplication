using StreamProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.StreamHandle
{
    public interface IStreamHandle
    {
        void Handling(IProtocol protocol, Form form);
    }
}
