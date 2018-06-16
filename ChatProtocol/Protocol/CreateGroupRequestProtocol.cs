using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class CreateGroupRequestProtocol : IProtocol
    {
        public Group Group = new Group();
        public List<string> Accounts = new List<string>();
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 5) return false;
            Group.Id = tach[0];
            Group.Name = tach[1];
            Group.UserCreate = tach[2];
            DateTime time;
            if (!DateTime.TryParse(tach[3], out time)) return false;
            Group.TimeCreate = time;
            for(int i=4; i<tach.Length; i++)
            {
                Accounts.Add(tach[i]);
            }
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Group.Id + "\0";
            data += Group.Name + "\0";
            data += Group.UserCreate + "\0";
            data += Group.TimeCreate + "\0";
            foreach(var item in Accounts)
            {
                data += item.ToString() + "\0";
            }
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
