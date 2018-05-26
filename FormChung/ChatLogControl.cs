using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormChung.PhanTichChuoi;

namespace FormChung
{
    public partial class ChatLogControl : UserControl
    {
        public string[] Icon = new string[] { ":D", ":p", ":e", "8/", "8)", "8o" };
        public ChatLogControl()
        {
            InitializeComponent();
        }

        public void Serialize(string input)
        {
            
        }

        private void Render(IList<IStringParse> input)
        {
            foreach(var item in input)
            {
                if(item is StringObject)
                {
                    var tmp = item as StringObject;
                    _rtbChatLog.AppendText(tmp.Content);
                }
                else if(item is IconObject)
                {
                    var tmp = item as IconObject;
                    //Add hình lên richtextbox
                }
            }
        }

        private PictureBox AddIcon(string s)
        {
            var position = _rtbChatLog.GetPositionFromCharIndex(_rtbChatLog.TextLength);
            PictureBox ptb = new PictureBox();
            ptb.Size = new Size(20, 20);
            ptb.Location = position;
            var link = LinkHinh(s);
            ptb.Image = Image.FromFile(link);
            return ptb;
        }

        private PictureBox AddIconTextBox(string icon, int startIndex)
        {
            var p = _txtChatBox.GetPositionFromCharIndex(startIndex);
            PictureBox ptb = new PictureBox();
            ptb.Size = new Size(20, 20);
            ptb.Location = p;
            var link = LinkHinh(icon);
            ptb.Image = Image.FromFile(link);
            return ptb;
        }
        public string LinkHinh(string s)
        {
            string result = null;
            if (s == Icon[0]) result = @"D:\Download\Projectas\hinhapp\laught.gif";
            if (s == Icon[1]) result = @"D:\Projectas\hinhapp\ple.png";
            if (s == Icon[2]) result = @"D:\Projectas\hinhapp\006.gif";
            if (s == Icon[3]) result = @"D:\Projectas\hinhapp\icon_cool.gif";
            if (s == Icon[4]) result = @"D:\Projectas\hinhapp\longlanh.gif";
            if (s == Icon[5]) result = @"D:\Projectas\hinhapp\tim.gif";
            return result;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
