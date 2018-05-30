using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Database.SQLServer
{
    public class SqlServerDB : IDatabase
    {
        SqlConnection con;
        public void Connect(string connectionString)
        {
            if (con == null)
            {
                con = new SqlConnection(connectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
        }

        public void Disconnect()
        {
            if(con!=null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public DbDataReader GetData(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
