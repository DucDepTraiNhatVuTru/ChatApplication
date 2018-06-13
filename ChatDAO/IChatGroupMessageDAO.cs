using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO.SQL
{
    public interface IChatGroupMessageDAO
    {
        int Insert(ChatDataModel.ChatGroupMessage message);
        List<ChatGroupMessage> GetMessages(string groupId);
    }
}
