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
    public partial class CommentBoxControl : UserControl
    {
        private TextBox _txtCommentInput;
        public CommentBoxControl()
        {
            InitializeComponent();
        }

        private void InitTextBox()
        {
            _txtCommentInput = new TextBox();
            _txtCommentInput.Multiline = true;
            _txtCommentInput.Size = new Size(this.Width, 50);
            _txtCommentInput.Location = new Point();
        }
    }
}
