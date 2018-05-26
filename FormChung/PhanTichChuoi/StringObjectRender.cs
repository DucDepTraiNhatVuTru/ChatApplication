using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormChung.PhanTichChuoi
{
    public class StringObjectRender
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public bool Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            var tach = input.Split('`');
            if (tach.Length < 2)
                return false;
            int id = 0;
            if (!int.TryParse(tach[0], out id))
                return false;
            Id = id;
            Content = tach[1];
            return true;
        }

        public override string ToString()
        {
            return Id + "~" + Content;
        }
    }
}
