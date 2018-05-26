using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormChung.PhanTichChuoi
{
    public class StringObjectParse
    {
        public static IList<StringObjectRender> ConvertToStringObjectRender(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new List<StringObjectRender>();
            var tach = input.Split('~');
            var result = new List<StringObjectRender>();
            foreach(var item in tach)
            {
                var tmp = new StringObjectRender();
                if (tmp.Parse(item))
                {
                    result.Add(tmp);
                }
            }
            return result;
        }
    }
}
