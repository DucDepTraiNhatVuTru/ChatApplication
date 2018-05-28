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
        //xác định chiều dài chuỗi trong textbox
        //mục địch xác định đó là thao tác thêm hay xóa
        private int textLegth = 0;
        private int kpselectstart = 0;
        public ChatLogControl()
        {
            InitializeComponent();
        }

        private StringObject StringCode(string content, int startIndex = 0)
        {
            StringObject stringObject = new StringObject();
            stringObject.Content = content;
            stringObject.StartIndex = startIndex;
            return stringObject;
        }

        private IconObject IconCode(string icon, int startIndex = 0)
        {
            var result = new IconObject();
            result.Id = icon;
            result.StartIndex = startIndex;
            result.IconImage = AddIconTextBox(result.Id, result.StartIndex);
            _txtChatBox.Controls.Add(result.IconImage);
            ThayTheIconBangWhiteSpace(icon);
            return result;
        }

        private void ThayTheIconBangWhiteSpace(string strIcon)
        {
            _txtChatBox.TextChanged -= new EventHandler(textBox1_TextChanged);
            _txtChatBox.Text = _txtChatBox.Text.Replace(strIcon, "    ");
            _txtChatBox.SelectionStart = kpselectstart + 3;
            _txtChatBox.TextChanged += new EventHandler(textBox1_TextChanged);
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
            if (_txtChatBox.TextLength > textLegth)
            {
                string newString = RecentlyString();
                if (!string.IsNullOrEmpty(CheckIconContainsInString(newString)))
                {
                    AddStringContainsIcon(newString);
                }
            }
        }

        private void AddStringContainsIcon(string newString)
        {
            var listISP = CreateListIStringParse(newString);
        }

        private IList<IStringParse> CreateListIStringParse(string str)
        {
            var tmpString = "";
            for(int i=0; i<str.Length; i++)
            {
                tmpString += str[i];
                var icon = CheckIconContainsInString(tmpString);
                if (!string.IsNullOrEmpty(icon))
                {

                }
            }
            return null;
        }

        private IList<IStringParse> CreateListIStringParse(string str, string icon)
        {
            IList<IStringParse> tmpList = new List<IStringParse>();
            var startIndexOfIconInStr = str.IndexOf(icon);
            var iconLength = icon.Length;
            string chuoi = str.Substring(0, startIndexOfIconInStr);
            if (!string.IsNullOrEmpty(chuoi)) tmpList.Add(new StringObject(chuoi));
            tmpList.Add(IconCode(icon));
            var vitricattiep = chuoi.Length + icon.Length;
            chuoi = str.Substring(vitricattiep);
            if (!string.IsNullOrEmpty(chuoi)) tmpList.Add(StringCode(chuoi));
            return tmpList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>ICON or null</returns>
        private string CheckIconContainsInString(string str)
        {
            foreach(var item in Icon)
            {
                if (str.Contains(item))
                    return item;
            }
            return null;
        }

        private string RecentlyString()
        {
            int stringLength = _txtChatBox.TextLength - textLegth;
            int startIndex = _txtChatBox.TextLength - stringLength;
            var recentlyString = _txtChatBox.Text.Substring(startIndex, stringLength);
            return recentlyString;
        }
    }
}
