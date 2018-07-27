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
    public class LiveStreamDAOSQL : ILiveStreamDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(DBHelper.ConnecttionString);
        }
        public int Insert(LiveStream liveStream)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO LiveStream VALUES ('" + liveStream.ID + "','" + liveStream.LiveUser + "','" + liveStream.StartTime + "'," + liveStream.Duration + "," + liveStream.Views + ")";
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
