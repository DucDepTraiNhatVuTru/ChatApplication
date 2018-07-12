using ChatDAO;
using ChatDataModel;
using Ozeki.Camera;
using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        private ImageProvider<Image> localProvider, remoteProvider;
        VideoViewerWF localView,remoteView;
        OzekiCamera camera;
        MediaConnector connector = new MediaConnector();
        public Form1()
        {
            InitializeComponent();
            /*StartCam();
            localProvider = new DrawingImageProvider();
            localView = new VideoViewerWF();
            localView.Location = new Point(0, 0);
            localView.Size = new Size(200, 100);
            localView.SetImageProvider(localProvider);
            remoteProvider = new DrawingImageProvider();
            remoteView = new VideoViewerWF();
            remoteView.Location = new Point(0, 110);
            remoteView.Size = new Size(200, 100);
            remoteView.SetImageProvider(remoteProvider);
            this.Controls.Add(remoteView);
            this.Controls.Add(localView);
            localView.Start();
            remoteView.Start();
            ConnectMedia();
            */

            

            
        }

        void StartCam()
        {
            var data = new CameraURLBuilderData { DeviceTypeFilter = DiscoverDeviceType.USB };
            var myCameraBuilder = new CameraURLBuilderWF(data);
            var result = myCameraBuilder.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            camera = new OzekiCamera(myCameraBuilder.CameraURL);
            camera.Start();
        }

        void ConnectMedia()
        {
            connector.Connect(camera.VideoChannel, localProvider);
            Thread.Sleep(1000);
            Thread thread = new Thread(delegate ()
            {
                remoteView.Invoke(new MethodInvoker(delegate ()
                {
                    DrawingImageProvider provider = new DrawingImageProvider();
                    remoteProvider.CurrentVideoData.SetRtpPackets(localProvider.CurrentVideoData.GetRtpPackets());
                }));
            });
            thread.Start();
        }

    }
}
