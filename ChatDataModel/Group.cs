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
    }
}
