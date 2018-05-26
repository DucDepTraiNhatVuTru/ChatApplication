using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Form1 : Form
    {
        private bool _isMouseDown = false;
        private Point _oldPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _oldPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                this.Location = new Point(this.Location.X - (_oldPoint.X - e.X)
                    ,this.Location.Y - (_oldPoint.Y - e.Y));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }
    }
}
