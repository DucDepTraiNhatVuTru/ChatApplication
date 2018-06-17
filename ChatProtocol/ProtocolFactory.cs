using ChatProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol
{
    public class ProtocolFactory
    {
        public static IProtocol CreateProtocol(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new CreateAccountProtocol();
                case 2:
                    return new CreateAccountResponseProtocol();
                case 3:
                    return new LoginRequestProtocol();
                case 4:
                    return new LoginResponseProtocol();
                case 5:
                    return new UpdateAvatarRequestProtocol();
                case 6:
                    return new UpdateAvatarResponseProtocol();
                case 7:
                    return new GetListFriendsRequestProtocol();
                case 8:
                    return new GetListFriendsResponseProtocol();
                case 9:
                    return new MessageProtocol();
                case 11:
                    return new HistoryChatRequestProtocol();
                case 12:
                    return new HistoryChatResponseProtocol();
                case 13:
                    return new GetGroupChatRequestProtocol();
                case 14:
                    return new GetGroupChatResponseProtocol();
                case 15:
                    return new GetUserInGroupResquestProtocol();
                case 16:
                    return new GetUserInGroupResponseProtocol();
                case 17:
                    return new GroupMessageProtocol();
                case 19:
                    return new HistoryChatGroupRequestProtocol();
                case 20:
                    return new HistoryChatGroupResponseProtocol();
                case 21:
                    return new GetFriendNotInGroupRequestProtocol();
                case 22:
                    return new GetListFriendsResponseProtocol();
                case 23:
                    return new AddUsersToGroupRequestProtocol();
                case 24:
                    return new AddUserInGroupResponseProtocol();
                case 25:
                    return new LeaveGroupRequestProtocol();
                case 26:
                    return new LeaveGroupResponseProtocol();
                case 27:
                    return new KickUserOutGroupRequestProtocol();
                case 28:
                    return new KickUserOutGroupResponseProtocol();
                case 29:
                    return new CreateGroupRequestProtocol();
                case 30:
                    return new CreateGroupResponseProtocol();
                case 31:
                    return new FindUserRequestProtocol();
                case 32:
                    return new GetListFriendsResponseProtocol();
                default:
                    throw new Exception("chưa hỗ trợ opcode");
            }
        }
    }
}
