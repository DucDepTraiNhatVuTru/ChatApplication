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
                default:
                    throw new Exception("Chưa hỗ trợ opcode");
            }
        }
    }
}
