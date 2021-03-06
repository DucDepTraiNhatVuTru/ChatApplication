﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using SimpleTCP;
using ChatProtocol.Protocol;
using ChatProtocol.Packet;
using ChatProtocol;

namespace ClientSocket.SimpleTcp
{
    public class SimpleTCPClient : IClient
    {
        private SimpleTcpClient _client;
        public bool IsSending { get; set; }
        public event Action<byte,IProtocol> OnNewRecieve;

        public SimpleTCPClient()
        {
            _client = new SimpleTcpClient();
            _client.DataReceived += _client_DataReceived;
        }

        private void _client_DataReceived(object sender, Message e)
        {
            var packet = new BasicPacket();
            if (!packet.Parse(e.Data))
                return;
            var protocol = ProtocolFactory.CreateProtocol(packet.Opcode);
            if (!protocol.Parse(Encoding.Unicode.GetString(packet.Data)))
                return;

            if (OnNewRecieve != null)
                OnNewRecieve.Invoke(packet.Opcode,protocol);
        }

        public void Connect(string ip, int port)
        {
            try
            {
                _client.Connect(ip, port);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        public void Send(string data)
        {
            _client.WriteLine(data);
        }

        public void RequestCreateAccount(Account account)
        {
            CreateAccountProtocol ptc = new CreateAccountProtocol();
            ptc.Account = account;
            BasicPacket packet = new BasicPacket();
            packet.Opcode = 1;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestLogin(string email, string password)
        {
            var ptc = new LoginRequestProtocol();
            ptc.Email = email;
            ptc.Password = password;
            var packet = new BasicPacket();
            packet.Opcode = 3;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestUpdateAvatar(string email,string driveFileId)
        {
            var ptc = new UpdateAvatarRequestProtocol();
            ptc.Email = email;
            ptc.DriveFileId = driveFileId;
            var packet = new BasicPacket();
            packet.Opcode = 5;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequsetGetListFriend(string email)
        {
            var ptc = new GetListFriendsRequestProtocol();
            ptc.Email = email;
            var packet = new BasicPacket();
            SendPacket(7, ptc);
        }

        public void SendMessage(ChatMessage message)
        {
            var ptc = new MessageProtocol();
            ptc.Message = message;
            var packet = new BasicPacket();
            packet.Opcode = 9;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestGetHistory(string personOne, string personTwo)
        {
            var ptc = new HistoryChatRequestProtocol();
            ptc.PersonOne = personOne;
            ptc.PersonTwo = personTwo;
            var packet = new BasicPacket();
            packet.Opcode = 11;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void Logout(string email)
        {
            var ptc = new LogoutProtocol();
            ptc.Email = email;
            var packet = new BasicPacket();
            packet.Opcode = 99;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestGetGroup(string email)
        {
            var ptc = new GetGroupChatRequestProtocol();
            ptc.Email = email;
            var packet = new BasicPacket();
            SendPacket(13, ptc);
        }

        public void RequestGetUserInGroup(string email, string groupId)
        {
            var ptc = new GetUserInGroupResquestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            var packet = new BasicPacket();
            packet.Opcode = 15;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void SendGroupMessage(ChatGroupMessage message)
        {
            var ptc = new GroupMessageProtocol();
            ptc.message = message;
            var packet = new BasicPacket();
            packet.Opcode = 17;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestGetHistoryGroupChat(string email, string groupId)
        {
            var ptc = new HistoryChatGroupRequestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            var packet = new BasicPacket();
            packet.Opcode = 19;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestGetFriendNotInGroup(string email, string groupId)
        {
            var ptc = new GetFriendNotInGroupRequestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            var packet = new BasicPacket();
            packet.Opcode = 21;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
        }

        public void RequestAddUserToGroup(string email, string groupId, string emailRequest)
        {
            var ptc = new AddUsersToGroupRequestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            ptc.EmailRequest = emailRequest;
            SendPacket(23, ptc);
        }

        private void SendPacket(byte opcode, IProtocol protocol)
        {
            IsSending = true;
            var packet = new BasicPacket();
            packet.Opcode = opcode;
            packet.Data = protocol.ToBytes();
            _client.Write(packet.ToBytes());
            IsSending = false;
        }

        public void RequestLeaveGroup(string email, string groupId)
        {
            var ptc = new LeaveGroupRequestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            SendPacket(25, ptc);
        }

        public void RequestKickUserOutGroup(string emailRequest, string kickEmail, string groupId)
        {
            var ptc = new KickUserOutGroupRequestProtocol();
            ptc.EmailRequest = emailRequest;
            ptc.KickEmail = kickEmail;
            ptc.GroupId = groupId;
            SendPacket(27, ptc);
        }

        public void RequestCreateGroupChat(Group group, List<string> accounts)
        {
            var ptc = new CreateGroupRequestProtocol();
            ptc.Group = group;
            ptc.Accounts = accounts;
            SendPacket(29, ptc);
        }

        public void RequestFindFriend(string email, string query)
        {
            var ptc = new FindUserRequestProtocol();
            ptc.Email = email;
            ptc.Query = query;
            SendPacket(31, ptc);
        }

        public void SendFriendRequest(string sender, string receiver)
        {
            var ptc = new AskBeFriendRequestProtocol();
            ptc.SenderEmail = sender;
            ptc.ReceiverEmail = receiver;
            SendPacket(33, ptc);
        }

        public void RequestGetListFriendRequest(string email)
        {
            var ptc = new GetListAskBeFriendRequestProtocol();
            ptc.Email = email;
            SendPacket(35, ptc);
        }

        public void RequestGetListFriendIRequest(string email)
        {
            var ptc = new GetListAskBeFriendRequestProtocol();
            ptc.Email = email;
            SendPacket(37, ptc);
        }

        public void RequestDeleteFriendInvatation(string sender, string receiver)
        {
            var ptc = new AskBeFriendRequestProtocol();
            ptc.SenderEmail = sender;
            ptc.ReceiverEmail = receiver;
            SendPacket(39, ptc);
        }

        public void RequestAcceptAddFriend(int isAccept, string userRequest, string userAccept)
        {
            var ptc = new AcceptFriendRequestProtocol();
            ptc.IsAccept = isAccept;
            ptc.UserAccept = userAccept;
            ptc.UserRequest = userRequest;
            SendPacket(41, ptc);
        }

        public void RequetsDeleteFriend(string emailRequest, string emailDelete)
        {
            var ptc = new DeleteFriendRequestProtocol();
            ptc.UserRequest = emailRequest;
            ptc.UserDelete = emailDelete;
            SendPacket(43, ptc);
        }

        public void RequestCreateLiveStream(string email)
        {
            var ptc = new LiveStreamRequestProtocol();
            ptc.Email = email;
            SendPacket(45, ptc);
        }

        public void RequestGetListFriendStreaming(string email)
        {
            var ptc = new GetFriendStreamingRequestProtocol();
            ptc.Email = email;
            SendPacket(47, ptc);
        }
    }
}
