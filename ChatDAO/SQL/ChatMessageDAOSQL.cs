using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Database;
using Database.SQLServer;

namespace ChatDAO
{
    public class ChatMessageDAOSQL : IChatMessageDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }
        public int Insert(ChatMessage message)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO ChatMessage VALUES ('" + message.Sender + "','" + message.Receiver + "',N'" + message.Message + "','" + message.ImageMessageDriveID + "','" + message.Call.ID + "','" + message.TimeSend + "')";
                return con.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Disconnect();
            }
        }
        public List<ChatMessage> AllMessage(string user1, string user2)
        {
            try
            {
                Connect();
                //string sql = "SELECT * FROM ChatMessage WHERE (Sender = '" + user1 + "' AND Receiver = '" + user2 + "') OR (Sender = '" + user2 + "' AND Receiver = '" + user1 + "')";
                string sql = "SELECT M.Id, Sender, Receiver, Message,ImageMessageDriveId, CallID, CallDuration, Called, Time FROM (SELECT * FROM ChatMessage WHERE ( ChatMessage.Sender ='" + user1 + "' AND ChatMessage.Receiver = '" + user2 + "' ) OR (ChatMessage.Sender = '" + user2 + "' AND ChatMessage.Receiver = '" + user1 + "')) M LEFT JOIN Call ON ( CallID = Call.ID )";
                var data = con.GetData(sql);
                List<ChatMessage> listMessage = new List<ChatMessage>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        int id = data.GetOrdinal("Id");
                        string sender = data.GetString(1);
                        string receiver = data.GetString(2);
                        string message = data.GetString(3);
                        string image = data.GetString(4);
                        string callId = data.GetValue(5).ToString();
                        int callDuration = 0;
                        if (!int.TryParse(data.GetValue(6).ToString(), out callDuration)) callDuration = 0;
                        bool called = false;
                        if (!bool.TryParse(data.GetValue(7).ToString(), out called)) called = false;
                        DateTime time = (DateTime)data.GetValue(8);
                        listMessage.Add(new ChatMessage(id, sender, receiver, message, image, new Call(callId, callDuration, called), time));
                    }
                }
                return listMessage;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                con.Disconnect();
            }
        }
    }
}
