﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Protocol
{
    public class FindUserRequestProtocol : IProtocol
    {
        public string Email { get; set; }
        public string Query { get; set; }
        public bool Parse(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            var tach = data.Split('\0');
            if (tach.Length < 2) return false;
            Email = tach[0];
            Query = tach[1];
            return true;
        }

        public byte[] ToBytes()
        {
            var data = "";
            data += Email + "\0";
            data += Query + "\0";
            return Encoding.Unicode.GetBytes(data);
        }
    }
}