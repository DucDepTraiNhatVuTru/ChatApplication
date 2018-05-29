using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Image Avatar { get; set; }
        public string Gender { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}
