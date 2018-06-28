using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Media;

namespace PhoneCall.UI
{
    public partial class CallView : UserControl
    {
        private VideoViewerWF _remoteViewer;
        private VideoViewerWF _localViewer;
        private ImageProvider<Image> _remoteProvider;
        private ImageProvider<Image> _localProvider;

        public CallView()
        {
            InitializeComponent();
            InitViewer();
        }

        private void InitViewer() {
            _remoteViewer = new VideoViewerWF(); ;
            _remoteViewer.Location = new Point(0, 0);
            _remoteViewer.Size = _flpRemoteVideo.Size;
            _remoteViewer.SetImageProvider(_remoteProvider);

            _localViewer = new VideoViewerWF();
            _localViewer.Location = new Point(0,0);
            _localViewer.Size = _panelLocalVideo.Size;
            _localViewer.SetImageProvider(_localProvider);

            _panelLocalVideo.Controls.Add(_localViewer);
            _flpRemoteVideo.Controls.Add(_remoteViewer);

            _remoteViewer.Start();
            _localViewer.Start();
        }

        public void StartRemoteVideoViewer()
        {
            _remoteViewer.Start();
        }

        public void StartLocalVideoViewer()
        {
            _localViewer.Start();
        }

        public void SetRemoteProvider(ImageProvider<Image> remoteProvider)
        {
            _remoteProvider = remoteProvider;
        }

        public void SetLocalProvider(ImageProvider<Image> localProvider)
        {
            _localProvider = localProvider;
        }

        public void SetRemoteProvider(IVideoSender remoteProvider)
        {
            MediaConnector connect = new MediaConnector();
            connect.Connect(remoteProvider, _remoteProvider);
        }

        public void SetLocalProvider(IVideoSender localProvider)
        {
            MediaConnector connect = new MediaConnector();
            connect.Connect(localProvider, _localProvider);
        }
    }
}
