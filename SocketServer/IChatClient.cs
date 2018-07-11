using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public interface IChatClient
    {
        void Disconnect();
        EndPoint GetEndPoint();
        void ResponseCreateAccount(int isSuccess, string message);
        void ResponseLogin(int isAccept, Account account);
        void ResponseUpdateAvatar(int isSuccess, string driveFileId);
        void ResponseGetListFriends(List<Account> listFriends);
        void SendMessage(ChatMessage message);
        void ResponseGetChatHistory(List<ChatMessage> messages);
        void ResponseGetGroups(List<Group> groups);
        void ResponseGetUserInGroup(string groupID, List<Account> accounts);
        void SendGroupMessage(ChatGroupMessage message);
        void ResponseGetChatGroupHistory(List<ChatGroupMessage> messages);
        void ResponseFriendNotInGroup(List<Account> accounts);
        void ResponseAddFriendToGroup(int isSuccess,string groupId);
        void ResponseLeaveGroup(int isSuccess, string groupId);
        void ResponseKickUserOutGroup(int isSuccess, string groupId, string email, string message);
        void ResponseCreateGroupChat(int isSuccess, List<Group> groups);
        void ResponseUserDugOut(List<Account> accounts);
        void SendFriendRequestToUser(Account sender);
        void ResponseGetListUserRequestAddFriend(List<Account> accounts);
        void ResponseGetListUserIRequestAddFriend(List<Account> accounts);
        void ResponseStreamID(string StreamID);
    }
}
