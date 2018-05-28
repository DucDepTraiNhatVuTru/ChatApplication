using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormChung.PhanTichChuoi
{
    public class StringObject : IStringParse
    {
        public string Content { get; set; }

        public int StartIndex { get; set; }

        public StringObject()
        {
  
        }
        public StringObject(string content)
        {
            Content = content;
        }
        public bool Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            Content = input;
            return true;
        }
    }
}
