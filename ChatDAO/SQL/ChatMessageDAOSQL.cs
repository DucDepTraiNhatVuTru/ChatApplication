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
    }
}
