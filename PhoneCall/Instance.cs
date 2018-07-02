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
    public class Instance
    {
        public static PhoneCallVideoSender videoSender = new PhoneCallVideoSender();
        public static PhoneCallAudioSender audioSender = new PhoneCallAudioSender();
        public static List<ImageProvider<Image>> LocalProvider = new List<ImageProvider<Image>>();
        public static ImageProvider<Image> NullProvider = new DrawingImageProvider();
        public static bool IsLocalCameraUsed = false;
        public static IVideoSender SendingVideo = null;
    }
}
