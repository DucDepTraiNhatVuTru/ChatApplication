using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormChung.PhanTichChuoi
{
    public class StringObject : IStringParse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Parse(string input)
        {
            throw new NotImplementedException();
        }
    }
}
