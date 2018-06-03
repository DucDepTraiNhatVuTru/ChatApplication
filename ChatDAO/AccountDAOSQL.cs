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
                string sql = "SELECT * FROM Account WHERE User1 = '" + email + "' or User2 = '" + email + "'";
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
    }
}
