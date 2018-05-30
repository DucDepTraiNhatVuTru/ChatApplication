using ChatDataModel;
using ClientSocket;
using ClientSocket.SimpleTcp;
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

namespace ChatApplication.View
{
    public partial class FormLogin : Form
    {
        private IClient _client = new SimpleTCPClient();
        private bool _isMouseDown = false;
        private Point _oldPoint;
        public FormLogin()
        {
            ConnectToServer();
            InitializeComponent();
            init();
        }

        private void init()
        {
            _ptbSignIn.SizeMode = PictureBoxSizeMode.StretchImage;
            _panelLogin.BackColor = Color.FromArgb(120, 255, 255, 255);
            var bm = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = bm;
            var bm1 = new Bitmap(_ptbSignIn.Image);
            _lbDangNhap.BackColor = bm1.GetPixel(10, 10);
            _btnClose.BackColor = Color.FromArgb(0, 255, 255, 255);
            _lbEmail.BackColor = Color.FromArgb(0, 255, 255, 255);
            _lbPassword.BackColor = Color.FromArgb(0, 255, 255, 255);
            _lbCreateNewAccount.BackColor = Color.FromArgb(0, 255, 255, 255);
            var color = Color.FromArgb(0, 255, 255, 255);
            _panelSignUp.BackColor = Color.FromArgb(120, 255, 255, 255);
            _lbEmailSignUp.BackColor = color;
            _lbNameSignUp.BackColor = color;
            _lbPasswordSignUp.BackColor = color;
            _lbConfirmPasswordSignUp.BackColor = color;
            _lbBackToLogin.BackColor = color;
            var bm2 = new Bitmap(_ptbSignUp.Image);
            _lbCreateAccountSignUp.BackColor = bm2.GetPixel(5, 5);
            _ptbSignUp.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void _ptbSignIn_Click(object sender, EventArgs e)
        {

        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _oldPoint = new Point(e.X, e.Y);
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                this.Location = new Point(this.Location.X - (_oldPoint.X - e.X)
                    , this.Location.Y - (_oldPoint.Y - e.Y));
            }
        }

        private void FormLogin_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void _lbCreateNewAccount_Click(object sender, EventArgs e)
        {
            _panelLogin.Visible = false;
            _panelSignUp.Visible = true;
        }

        private void InvisibleControlsLogin()
        {
            
            _lbCreateNewAccount.Visible = false;
            _lbEmail.Visible = false;
            _lbPassword.Visible = false;
            _txtEmail.Visible = false;
            _txtPassword.Visible = false;
            button1.Visible = false;
            /*
            _lbCreateNewAccount.Hide();
            _lbDangNhap.Hide();
            _lbEmail.Hide();
            _lbPassword.Hide();
            _txtEmail.Hide();
            _txtPassword.Hide();
            _btnClose.Hide();
            */
        }

        private void _lbBackToLogin_Click(object sender, EventArgs e)
        {
            _panelSignUp.Visible = false;
            _panelLogin.Visible = true;
        }

        private void ConnectToServer()
        {
            try
            {
                _client.Connect("127.0.0.1", 2018);
            }
            catch (Exception)
            {
                MessageBox.Show("Server đang bảo trì");
            }
        }

        private void _btnCreateAccount_Click(object sender, EventArgs e)
        {
            //_client.RequestCreateAccount(Account account);
        }
    }
}
