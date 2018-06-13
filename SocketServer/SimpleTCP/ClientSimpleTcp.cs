﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChatProtocol.Protocol;
using ChatProtocol.Packet;
using ChatDataModel;

namespace SocketServer.SimpleTCP
{
    public class ClientSimpleTcp : IChatClient
    {
        private TcpClient _client;

        public ClientSimpleTcp(TcpClient client)
        {
            this._client = client;
            _client.Client.NoDelay = true;
        }

        public void Disconnect()
        {
            if (_client.Connected)
            {
                _client.Close();
            }
        }

        public EndPoint GetEndPoint()
        {
            return _client.Client.RemoteEndPoint;
        }

        public void ResponseCreateAccount(int isSuccess, string message)
        {
            var ptc = new CreateAccountResponseProtocol();
            ptc.IsSuccess = isSuccess;
            ptc.Message = message;
            var packet = new BasicPacket();
            packet.Opcode = 2;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseGetChatHistory(List<ChatMessage> messages)
        {
            var ptc = new HistoryChatResponseProtocol();
            ptc.Messages = messages;
            var packet = new BasicPacket();
            packet.Opcode = 12;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseGetGroups(List<Group> groups)
        {
            var ptc = new GetGroupChatResponseProtocol();
            ptc.Groups = groups;
            var packet = new BasicPacket();
            packet.Opcode = 14;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseGetChatGroupHistory(List<ChatGroupMessage> messages)
        {
            var ptc = new HistoryChatGroupResponseProtocol();
            ptc.Messages = messages;
            var packet = new BasicPacket();
            packet.Opcode = 20;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseGetListFriends(List<Account> listFriends)
        {
            var ptc = new GetListFriendsResponseProtocol();
            ptc.ListAccount = listFriends;
            var packet = new BasicPacket();
            packet.Opcode = 8;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseGetUserInGroup(string groupID,List<Account> accounts)
        {
            var ptc = new GetUserInGroupResponseProtocol();
            ptc.Accounts = accounts;
            ptc.GroupId = groupID;
            var packet = new BasicPacket();
            packet.Opcode = 16;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseLogin(int isAccept, Account account)
        {
            var ptc = new LoginResponseProtocol();
            ptc.IsAccept = isAccept;
            ptc.Account = account;
            var packet = new BasicPacket();
            packet.Opcode = 4;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void ResponseUpdateAvatar(int isSuccess, string driveFileId)
        {
            var ptc = new UpdateAvatarResponseProtocol();
            ptc.IsSuccess = isSuccess;
            ptc.DriveFileId = driveFileId;
            var packet = new BasicPacket();
            packet.Opcode = 6;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void SendGroupMessage(ChatGroupMessage message)
        {
            var ptc = new GroupMessageProtocol();
            ptc.message = message;
            var packet = new BasicPacket();
            packet.Opcode = 17;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }

        public void SendMessage(ChatMessage message)
        {
            var ptc = new MessageProtocol();
            ptc.Message = message;
            var packet = new BasicPacket();
            packet.Opcode = 9;
            packet.Data = ptc.ToBytes();
            _client.Client.Send(packet.ToBytes());
        }
    }
}
