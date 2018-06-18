using ChatProtocol.Handle;
using SocketServer.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol
{
    public class HandleFactory
    {
        public static IHandle CreateHandle(byte opcode)
        {
            switch (opcode)
            {
                case 1:
                    return new CreateAccountRequestHandle();
                case 3:
                    return new LoginRequestHandle();
                case 5:
                    return new UpdateAvatarHandle();
                case 7:
                    return new GetListFriendsRequestHandle();
                case 9:
                    return new MessageHandle();
                case 11:
                    return new GetChatHistoryHandle();
                case 13:
                    return new GetGroupHandle();
                case 15:
                    return new GetUserInGroupHandle();
                case 17:
                    return new GroupMessageHandle();
                case 19:
                    return new HistoryChatGroupHandle();
                case 21:
                    return new GetFriendNotInGroupHandle();
                case 23:
                    return new AddUserInGroupHandle();
                case 25:
                    return new LeaveGroupHandle();
                case 27:
                    return new KickUserOutGroupHandle();
                case 29:
                    return new CreateGroupChatHandle();
                case 31:
                    return new FindUserRequestHandle();
                case 33:
                    return new AskBeFriendRequestHandle();
                case 35:
                    return new GetListAskBeFriendRequestHandle();
                default:
                    throw new Exception("chưa hỗ trợ opcode!");
            }
        }
    }
}
