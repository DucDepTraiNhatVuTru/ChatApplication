using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IDatabase
    {
        void Connect(string connectionString);
        void Disconnect();
        void ExecuteNonQuery(string sql);
        DataSet GetData(string sql);
    }
}
