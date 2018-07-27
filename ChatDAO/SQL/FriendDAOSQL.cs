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
            con.Connect(DBHelper.ConnecttionString);
        }

        public int Delete(string email1, string email2)
        {
            try
            {
                Connect();
                var sql = "DELETE FROM Friend WHERE (User1 = '" + email1 + "' AND User2 = '" + email2 + "') OR (User2 = '" + email1 + "' AND User1 = '" + email2 + "')";
                return con.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {

                throw new Exception(exx.Message);
            }
            finally { con.Disconnect(); }
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
