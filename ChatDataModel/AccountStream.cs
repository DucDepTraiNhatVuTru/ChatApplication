using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class AccountStream
    {
        //public Account Account = new Account();
        public string Name { get; set; }
        public string ImageDriveID { get; set; }
        public string StreamID { get; set; }
        public AccountStream()
        {

        }

        public AccountStream(string name, string imageDriveID, string streamID)
        {
            Name = name;
            ImageDriveID = imageDriveID;
            StreamID = streamID;
        }

        public bool Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var tach = input.Split('\n');
            if (tach.Length < 3) return false;
            Name = tach[0];
            ImageDriveID = tach[1];
            StreamID = tach[2];
            return true;
        }

        public override string ToString()
        {
            var data = "";
            data += Name + "\n";
            data += ImageDriveID + "\n";
            data += StreamID + "\n";
            return data;
        }
    }
}
