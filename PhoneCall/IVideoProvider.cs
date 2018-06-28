using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall
{
    public interface IVideoProvider
    {
        ImageProvider<Image> Provider { get; set; }
    }
}
