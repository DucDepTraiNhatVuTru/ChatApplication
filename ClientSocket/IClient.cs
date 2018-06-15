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
        void Logout(string email);
        void RequestGetGroup(string email);
        void RequestGetUserInGroup(string email, string groupId);
        void SendGroupMessage(ChatGroupMessage message);
        void RequestGetHistoryGroupChat(string email, string groupId);
        void RequestGetFriendNotInGroup(string email, string groupId);
        void RequestAddUserToGroup(string email, string groupId, string emailRequest);
        void RequestLeaveGroup(string email, string groupId);
        void RequestKickUserOutGroup(string emailRequest, string kickEmail, string groupId);
    }
}
