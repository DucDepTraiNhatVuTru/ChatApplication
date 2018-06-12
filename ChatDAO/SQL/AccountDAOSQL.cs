using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDataModel;
using Database;
using Database.SQLServer;
using ImageConverter;
using System.Data;

namespace ChatDAO
{
    public class AccountDAOSQL : IAccountDAO
    {
        IDatabase con = new SqlServerDB();

        public void Connect()
        {
            con.Connect(@"Data Source=MINHDUC\SQLEXPRESS;Initial Catalog=ChatDB;Persist Security Info=True;User ID=sa;Password=123456");
        }

        public void Insert(Account account)
        {
            try
            {
                Connect();
                string sql = "insert into Account(Email, Password, Name, Avatar, Gender, TimeCreate) ";
                sql += "values ('" + account.Email + "','" + account.Password + "',N'" + account.Name + "','" + account.AvatarDriveID+ "',N'" + account.Gender + "','" + account.TimeCreate + "')";
                con.ExecuteNonQuery(sql);
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

        public Account GetAccount(string email)
        {
            try
            {
                Connect();
                string sql = "select * from Account where Email ='" + email + "'";
                var data = con.GetData(sql);
                Account account = new Account();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        account.Email = data.GetString(0);
                        account.Password = data.GetString(1);
                        account.Name = data.GetString(2);
                        account.AvatarDriveID = data.GetString(3);
                        account.Gender = data.GetString(4);
                        account.TimeCreate =(DateTime) data.GetValue(5);
                    }
                }
                return account;
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

        public Account GetAccount(string email, string password)
        {
            try
            {
                Connect();
                string sql = "select * from Account where Email = '" + email + "' and Password = '" + password + "'";
                var data = con.GetData(sql);
                Account account = new Account();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        account.Email = data.GetString(0);
                        account.Password = data.GetString(1);
                        account.Name = data.GetString(2);
                        account.AvatarDriveID = data.GetString(3);
                        account.Gender = data.GetString(4);
                        account.TimeCreate = (DateTime)data.GetValue(5);
                    }
                }
                return account;
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

        public int UpdateAvatar(string email, string driveFileId)
        {
            try
            {
                Connect();
                string sql = "UPDATE Account SET Avatar = '" + driveFileId + "' WHERE Email = '" + email + "'";
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

        public List<Account> GetFriendList(string email)
        {
            try
            {
                Connect();
                string sql = "SELECT Account.Email, Account.Password, Account.Name, Account.Avatar, Account.Gender, Account.TimeCreate FROM Account,((SELECT User1 FROM Friend WHERE User2 = '" + email + "' UNION SELECT User2 FROM Friend WHERE User1 ='" + email + "')) AS T WHERE Account.Email = T.User1";
                var data = con.GetData(sql);
                List<Account> listFriends = new List<Account>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        var userEmail = data.GetString(0);
                        var password = data.GetString(1);
                        var name = data.GetString(2);
                        var driveFileID = data.GetString(3);
                        var gender = data.GetString(4);
                        var time = (DateTime)data.GetValue(5);
                        listFriends.Add(new Account(userEmail, password, name, driveFileID, gender, time));
                    }
                }
                return listFriends;
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

        public List<string> EmailsFriends(string email)
        {
            List<string> emails = new List<string>();
            try
            {
                Connect();
                /*string sql = "SELECT * FROM Account WHERE Email = (SELECT User1 FROM Friend WHERE User2 = '" + email + "') OR Email = (SELECT User2 FROM Friend WHERE User1 = '" + email + "')";*/
                string sql = "(SELECT User1 FROM Friend WHERE User2 = '" + email + "') UNION (SELECT User2 FROM Friend WHERE User1 = '" + email + "')";
                var data = con.GetData(sql);
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        var user = data.GetString(0);
                        emails.Add(user);
                    }
                }

                return emails;
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
