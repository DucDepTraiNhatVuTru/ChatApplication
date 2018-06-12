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
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
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
