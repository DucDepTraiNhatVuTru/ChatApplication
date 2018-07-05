using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class Call
    {
        public string ID { get; set; }
        public int Duration { get; set; }
        public bool Called { get; set; }

        public Call()
        {
                
        }

        public Call(string id, int duration, bool called)
        {
            ID = id;
            Duration = duration;
            Called = called;
        }

        public bool Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var tach = input.Split('@');
            if (tach.Length < 3) return false;
            ID = tach[0];
            int duration = 0;
            if (!int.TryParse(tach[1], out duration)) return false;
            Duration = duration;
            bool called = false;
            if (!bool.TryParse(tach[2], out called)) return false;
            Called = called;
            return true;
        }

        public override string ToString()
        {
            var data = "";
            data += ID + "@";
            data += Duration + "@";
            data += Called + "@";
            return data;
        }
    }
}
