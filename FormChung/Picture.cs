using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormChung
{
    public partial class Picture : UserControl
    {
        public event Action Close;
        public Picture()
        {
            InitializeComponent();
            _btnClose.Click += _btnClose_Click;
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            if (Close != null)
            {
                Close.Invoke();
            }
        }

        public void AddImage(Image image)
        {
            _ptbHinh.Image = image;
            _ptbHinh.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
