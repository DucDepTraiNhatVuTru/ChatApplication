using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Custom
{
    public class User
    {
        public Image Avatar { get; set; }
        public string Name { get; set; }

        public User()
        {

        }

        public User(Image avatar, string name)
        {
            this.Avatar = avatar;
            this.Name = name;
        }
    }
}
