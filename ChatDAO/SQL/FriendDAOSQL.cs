using Database;
using Database.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAO.SQL
{
    public class FriendDAOSQL : IFriendDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }
        public int Insert(string email1, string email2)
        {
            try
            {
                Connect();
                var sql ="INSERT INTO Friend Values('"+email1+"','"+email2+"','"+DateTime.Now+"')";
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
