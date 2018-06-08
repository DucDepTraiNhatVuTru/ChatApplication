using ChatDataModel;
using ChatProtocol.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket
{
    public interface IClient
    {
        void Connect(string ip, int port);
        void Disconnect();
        event Action<byte,IProtocol> OnNewRecieve;
        void Send(string data);
        void RequestCreateAccount(Account account);
        void RequestLogin(string email, string password);
        void RequestUpdateAvatar(string email, string driveFileId);
        void RequsetGetListFriend(string email);
        void SendMessage(ChatMessage message);
        void RequestGetHistory(string personOne, string personTwo);
    }
}
