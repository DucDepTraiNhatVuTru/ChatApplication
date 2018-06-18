using ChatDataModel;
using Database;
using Database.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO.SQL
{
    public class FriendRequestNotExceptDAOSQL : IFriendRequestNotExceptDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }
        public int Insert(FriendResquestNotExcept requets)
        {
            try
            {
                Connect();
                var sql = "INSERT INTO FriendRequestNotExcepted VALUES ('" + requets.Sender + "','" + requets.Receiver + "','" + requets.Time + "')";
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
