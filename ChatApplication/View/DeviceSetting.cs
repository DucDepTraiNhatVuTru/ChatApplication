using LiveStream;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
using CSCore.CoreAudioAPI;

namespace ChatApplication.View
{
    public partial class DeviceSetting : Form
    {
        private MediaStream _media;
        public event Action<FilterInfo, MMDevice, MMDevice> ApplyDevices;
        public DeviceSetting()
        {
            InitializeComponent();
        }

        public DeviceSetting(MediaStream media)
        {
            _media = media;
            InitializeComponent();
            InitComboBoxCamera();
            InitComboBoxSpeaker();
            InitComboBoxMicrophone();
        }

        private void InitComboBoxCamera()
        {
            foreach(FilterInfo item in _media.GetCameraDevices())
            {
                _cbListCam.Items.Add(item.Name);
            }
            _cbListCam.SelectionStart = 0;
        }

        private void InitComboBoxSpeaker()
        {
            foreach(var item in _media.GetSpeakerDevices())
            {
                _cbListSpeaker.Items.Add(item.FriendlyName);
            }
            _cbListSpeaker.SelectionStart = 0;
        }

        private void InitComboBoxMicrophone()
        {
            foreach(var item in _media.GetMicrophoneDevices())
            {
                _cbListMic.Items.Add(item.FriendlyName);
            }
            _cbListMic.SelectionStart = 0;
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            if (ApplyDevices != null)
                ApplyDevices.Invoke(_media.GetCameraDevices()[_cbListCam.SelectedIndex], _media.GetMicrophoneDevices()[_cbListMic.SelectedIndex], _media.GetSpeakerDevices()[_cbListSpeaker.SelectedIndex]);
            this.Close();
        }
    }
}
