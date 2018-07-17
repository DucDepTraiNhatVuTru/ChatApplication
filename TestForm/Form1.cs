using AForge.Video.DirectShow;
using ChatDAO;
using ChatDataModel;
using LiveStream;
using Ozeki.Camera;
using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        private StreamAForge cam = new StreamAForge();
        public Form1()
        {
            InitializeComponent();
            foreach(FilterInfo item in cam.GetListDevices())
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectionStart = 0;

            foreach(var item in cam.GetListAudioDevices())
            {
                comboBox2.Items.Add(item.FriendlyName);
            }
            comboBox2.SelectionStart = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam.StartVideo(cam.GetListDevices()[comboBox1.SelectedIndex].MonikerString);
            /*Thread thread = new Thread(delegate ()
            {
                cam.RecordAudio();
                cam.StartAudio();
            });
            thread.Start*/
            cam.RecordAudio(cam.GetListAudioDevices()[comboBox2.SelectedIndex]);
            cam.StartAudio();
            cam.OnVideoNewFrame += Cam_OnVideoNewFrame;
        }

        private void Cam_OnVideoNewFrame(Bitmap bitmap,byte[] buffer)
        {
            
            pictureBox1.Image = bitmap;
            /*richTextBox1.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.Text = "";
                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                var b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
                foreach (var item in b)
                {
                    richTextBox1.AppendText(item.ToString());
                }
            }));*/
            /*Thread thread1 = new Thread(delegate ()
            {
                richTextBox1.Invoke(new MethodInvoker(delegate ()
                {
                    richTextBox1.Text = "";
                    System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                    var b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
                    foreach (var item in b)
                    {
                        richTextBox1.AppendText(item.ToString());
                    }
                }));
            });
            thread1.Start();*/

            /*Thread thread2 = new Thread(delegate ()
            {
                richTextBox2.Invoke(new MethodInvoker(delegate ()
                {
                    richTextBox2.Text = "";
                    foreach (var item in buffer)
                    {
                        richTextBox2.AppendText(item.ToString());
                    }
                }));
            });
            thread2.Start();*/
            richTextBox2.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox2.Text = "";
                foreach (var item in buffer)
                {
                    richTextBox2.AppendText(item.ToString());
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cam.StopAudio();
            cam.StopVideo();
        }
    }
}
