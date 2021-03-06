﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class AddUsersToGroupRequestProtocol : IProtocol
    {
        public string EmailRequest { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            GroupId = tach[0];
            Email = tach[1];
            EmailRequest = tach[2];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = GroupId + "\0";
            data += Email + "\0";
            data += EmailRequest + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}
