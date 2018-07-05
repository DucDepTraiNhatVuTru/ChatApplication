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
    public class CallDAOSQL : ICallDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }
        public int Insert(Call call)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO Call VALUES ('" + call.ID + "'," + call.Duration + "," + call.Called + ")";
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
