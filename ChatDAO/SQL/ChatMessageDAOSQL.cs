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
                string sql = "INSERT INTO ChatMessage VALUES ('" + message.Sender + "','" + message.Receiver + "',N'" + message.Message + "','" + message.ImageMessageDriveID + "','" + message.TimeSend + "')";
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
                string sql = "SELECT * FROM ChatMessage WHERE (Sender = '" + user1 + "' AND Receiver = '" + user2 + "') OR (Sender = '" + user2 + "' AND Receiver = '" + user1 + "')";
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
                        DateTime time = (DateTime)data.GetValue(5);
                        listMessage.Add(new ChatMessage(id, sender, receiver, message, image, time));
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
