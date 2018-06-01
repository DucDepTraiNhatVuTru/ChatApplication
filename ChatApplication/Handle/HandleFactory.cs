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
                default:
                    throw new Exception("Chưa hỗ trợ opcode");
            }
        }
    }
}
