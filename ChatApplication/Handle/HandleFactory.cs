using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Handle
{
    public class HandleFactory
    {
        public static IHandle CreateHandle(byte opcode)
        {
            switch (opcode)
            {
                case 2:
                    return new CreateAccountResponseHandle();
                case 4:
                    return new LoginResponseHandle();
                case 6:
                    return new UpdateAvatarResponseHandle();
                case 8:
                    return new GetListFriendsResponseHandle();
                case 9:
                    return new MessageHandle();
                case 12:
                    return new ChatHistoryHandle();
                case 14:
                    return new GetGroupHandle();
                case 16:
                    return new GetUserInGroupHandle();
                case 17:
                    return new GroupMessageHandle();
                case 20:
                    return new HistoryChatGroupHandle();
                case 22:
                    return new GetListFriendNotInGroupHandle();
                case 24:
                    return new AddUserToGroupHandle();
                case 26:
                    return new LeaveGroupHandle();
                case 28:
                    return new KickUserOutGroupHandle();
                case 30:
                    return new CreateGroupResponseHandle();
                case 32:
                    return new FindUserHandle();
                case 34:
                    return new AskBeFriendHandle();
                case 36:
                    return new AskBeFriendHandle();
                default:
                    throw new Exception("Chưa hỗ trợ opcode");
            }
        }
    }
}
