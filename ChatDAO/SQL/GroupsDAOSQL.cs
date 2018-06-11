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
    public class GroupsDAOSQL : IGroupDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }

        public List<Group> GetListGroup(string email)
        {
            try
            {
                Connect();
                string sql = "SELECT GroupChat.Id, GroupChat.Name, GroupChat.UserCreate, GroupChat.TimeCreate FROM GroupChat,(SELECT UserInGroup.GroupId FROM UserInGroup WHERE UserInGroup.UserEmail = '" + email + "') AS T WHERE GroupChat.Id = T.GroupId";
                var data = con.GetData(sql);
                var groups = new List<Group>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        string id = data.GetString(0);
                        string name = data.GetString(1);
                        string userCreate = data.GetString(2);
                        DateTime time = (DateTime)data.GetValue(3);
                        groups.Add(new Group(id, name, userCreate, time));
                    }
                }
                return groups;
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

        public int Insert(Group group)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO Group VALUES ('" + group.Id + "','" + group.Name + "','" + group.UserCreate + "','" + group.TimeCreate + "')";
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
