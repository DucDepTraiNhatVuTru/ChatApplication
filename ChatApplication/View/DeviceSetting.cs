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
            _cbListCam.Text = _media.GetCameraDevices()[0].Name;
        }

        private void InitComboBoxSpeaker()
        {
            foreach(var item in _media.GetSpeakerDevices())
            {
                _cbListSpeaker.Items.Add(item.FriendlyName);
            }
            _cbListSpeaker.SelectionStart = 0;
            _cbListSpeaker.Text = _media.GetSpeakerDevices()[0].FriendlyName;
        }

        private void InitComboBoxMicrophone()
        {
            foreach(var item in _media.GetMicrophoneDevices())
            {
                _cbListMic.Items.Add(item.FriendlyName);
            }
            _cbListMic.SelectionStart = 0;
            _cbListMic.Text = _media.GetMicrophoneDevices()[0].FriendlyName;
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            int camIdx = (_cbListCam.SelectedIndex < 0 ? 0 : _cbListCam.SelectedIndex);
            int micIdx = (_cbListMic.SelectedIndex < 0 ? 0 : _cbListMic.SelectedIndex);
            int speakerIdx = (_cbListSpeaker.SelectedIndex < 0 ? 0 : _cbListSpeaker.SelectedIndex);
            if (ApplyDevices != null)
                ApplyDevices.Invoke(_media.GetCameraDevices()[camIdx], _media.GetMicrophoneDevices()[micIdx], _media.GetSpeakerDevices()[speakerIdx]);
            this.Close();
        }
    }
}
