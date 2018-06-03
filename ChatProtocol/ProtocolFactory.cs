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
                default:
                    throw new Exception("chưa hỗ trợ opcode");
            }
        }
    }
}
