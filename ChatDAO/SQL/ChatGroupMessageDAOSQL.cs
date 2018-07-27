using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Database;
using Database.SQLServer;

namespace ChatDAO.SQL
{
    public class ChatGroupMessageDAOSQL : IChatGroupMessageDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(DBHelper.ConnecttionString);
        }

        public List<ChatGroupMessage> GetMessages(string groupId)
        {
            try
            {
                Connect();
                string sql = "SELECT * FROM ChatGroupMessage WHERE GroupReceive = '" + groupId + "'";
                var data = con.GetData(sql);
                var message = new List<ChatGroupMessage>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        int id = data.GetOrdinal("Id");
                        string sender = data.GetString(1);
                        string groupReceive = data.GetString(2);
                        string mess = data.GetString(3);
                        string image = data.GetString(4);
                        DateTime time = (DateTime)data.GetValue(5);
                        message.Add(new ChatGroupMessage(id, sender, groupReceive, mess, image, time));
                    }
                }
                return message;
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

        public int Insert(ChatGroupMessage message)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO ChatGroupMessage VALUES ('" + message.Sender + "','" + message.GroupReceive + "',N'" + message.Message + "','" + message.ImageMessageDriveId + "','" + message.TimeSend + "')";
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
    }
}
