using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserCreate { get; set; }
        public DateTime TimeCreate { get; set; }

        public Group()
        {

        }

        public Group(string id, string name, string userCreate, DateTime time)
        {
            Id = id;
            Name = name;
            UserCreate = userCreate;
            TimeCreate = time;
        }

        public override string ToString()
        {
            var data = "";
            data += Id + "\v";
            data += Name + "\v";
            data += UserCreate + "\v";
            data += TimeCreate + "\v";
            return data;
        }

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\v');
            if (tach.Length < 4) return false;
            Id = tach[0];
            Name = tach[1];
            UserCreate = tach[2];
            DateTime time;
            if (!DateTime.TryParse(tach[3], out time)) return false;
            TimeCreate = time;
            return true;
        }
    }
}
