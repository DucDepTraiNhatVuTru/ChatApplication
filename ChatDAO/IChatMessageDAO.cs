﻿using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO
{
    public interface IChatMessageDAO
    {
        int Insert(ChatMessage message);
    }
}