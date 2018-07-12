using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using SocketServer;
using ChatDAO;

namespace SocketServer.Handle
{
    public class UpdateAvatarHandle : IHandle
    {
        private object syncLock = new object();
        public string Handling(IProtocol protocol, IChatClient client)
        {
            var ptc = protocol as UpdateAvatarRequestProtocol;
            string toView = "[" + DateTime.Now + "] [" + client.GetEndPoint() + "] [user:" + ptc.Email + "] request Change avatar ";
            int isSuccess = UpdateAvatar(ptc.Email, ptc.DriveFileId);
            if (isSuccess != 1)
            {
                // gửi về không thành công
                client.ResponseUpdateAvatar(0, ptc.DriveFileId);
                toView += "\n non successful";
                return toView;
            }

            client.ResponseUpdateAvatar(1, ptc.DriveFileId);
            toView += "\n update successful";

            return toView;
        }

        private int UpdateAvatar(string email, string driveFileId)
        {
            lock (syncLock)
            {
                IAccountDAO db = new AccountDAOSQL();
                return db.UpdateAvatar(email, driveFileId);
            }
        }
    }
}
