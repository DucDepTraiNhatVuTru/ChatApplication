using System;
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
            packet.Opcode = 7;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
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
            packet.Opcode = 13;
            packet.Data = ptc.ToBytes();
            _client.Write(packet.ToBytes());
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

        public void RequestAddUserToGroup(string email, string groupId)
        {
            var ptc = new AddUsersToGroupRequestProtocol();
            ptc.Email = email;
            ptc.GroupId = groupId;
            SendPacket(23, ptc);
        }

        private void SendPacket(byte opcode, IProtocol protocol)
        {
            var packet = new BasicPacket();
            packet.Opcode = opcode;
            packet.Data = protocol.ToBytes();
            _client.Write(packet.ToBytes());
        }
    }
}
