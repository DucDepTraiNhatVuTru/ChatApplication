using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace FormChung
{
    public partial class CommentBoxControl : UserControl
    {
        public CommentBoxControl()
        {
            InitializeComponent();
            _listControlComment.AutoSizeItems = true;
            DescriptionTextListDataItem item = new DescriptionTextListDataItem();
            //item.Image =  Image.FromFile(@"D:\ThucTap\avartar.jpg");
            item.Text = "Minh Đức";
            item.DescriptionText = "xin chàooooo";
            _listControlComment.Items.Add(item);
        }

        public void AddComment(string name, string comment, Image image, int time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            DescriptionTextListDataItem item = new DescriptionTextListDataItem();
            item.Image = image;
            item.Text = "[" + t.ToString(@"mm/:ss") + "]" + name;
            item.DescriptionText = comment;
        }
    }
}
