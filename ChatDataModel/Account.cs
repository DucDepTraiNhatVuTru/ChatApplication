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
        public string AvatarDriveID { get; set; }
        public string Gender { get; set; }
        public DateTime TimeCreate { get; set; }

        public Account()
        {
        }
        public Account(string email, string password, string name, string driveFileId, string gender, DateTime timeCreate)
        {
            Email = email;
            Password = password;
            Name = name;
            AvatarDriveID = driveFileId;
            Gender = gender;
            TimeCreate = timeCreate;
        }

        public override string ToString()
        {
            var account = Email + "\v";
            account += Password + "\v";
            account += Name + "\v";
            account += AvatarDriveID + "\v";
            account += Gender += "\v";
            account += TimeCreate + "\v";
            return account;
        }

        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\v');
            if (tach.Length < 6) return false;
            Email = tach[0];
            Password = tach[1];
            Name = tach[2];
            AvatarDriveID = tach[3];
            Gender = tach[4];
            DateTime time;
            if (!DateTime.TryParse(tach[5], out time)) return false;
            TimeCreate = time;
            return true;
        }
    }
}
