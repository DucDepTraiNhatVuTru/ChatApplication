using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormChung.PhanTichChuoi
{
    public class IconObject : IStringParse
    {
        public String Id{ get; set; }
        public PictureBox IconImage { get; set; }

        public int StartIndex { get; set; }
        public bool Parse(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return false;
            Id = input;
            return true;
        }
    }
}
