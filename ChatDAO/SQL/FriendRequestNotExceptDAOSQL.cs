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

        public int Delete(FriendResquestNotExcept request)
        {
            throw new NotImplementedException();
        }

        public int DeleteByMe(FriendResquestNotExcept request)
        {
            try
            {
                Connect();
                var sql = "DELETE FROM FriendRequestNotExcepted WHERE Sender = '" + request.Sender + "'AND Receiver = '" + request.Receiver + "'";
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

        public List<Account> GetMyRequest(string email)
        {
            try
            {
                Connect();
                var sql = "SELECT Account.Email, Account.Password, Account.Name, Account.Avatar, Account.Gender, Account.TimeCreate FROM Account,(SELECT FriendRequestNotExcepted.Sender FROM FriendRequestNotExcepted WHERE FriendRequestNotExcepted.Sender = '" + email + "') AS T WHERE T.Receiver = Account.Email";
                var data = con.GetData(sql);
                var accounts = new List<Account>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        var userEmail = data.GetString(0);
                        var pass = data.GetString(1);
                        var name = data.GetString(2);
                        var avatar = data.GetString(3);
                        var gender = data.GetString(4);
                        var time = (DateTime)data.GetValue(5);
                        var account = new Account(userEmail, pass, name, avatar, gender, time);
                        accounts.Add(account);
                    }
                }
                return accounts;
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

        public List<Account> GetRequest(string email)
        {
            try
            {
                Connect();
                var sql = "SELECT Account.Email, Account.Password, Account.Name, Account.Avatar, Account.Gender, Account.TimeCreate FROM Account,(SELECT FriendRequestNotExcepted.Sender FROM FriendRequestNotExcepted WHERE FriendRequestNotExcepted.Receiver = '" + email + "') AS T WHERE T.Sender = Account.Email";
                var data = con.GetData(sql);
                var accounts = new List<Account>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        var userEmail = data.GetString(0);
                        var pass = data.GetString(1);
                        var name = data.GetString(2);
                        var avatar = data.GetString(3);
                        var gender = data.GetString(4);
                        var time = (DateTime)data.GetValue(5);
                        var account = new Account(userEmail, pass, name, avatar, gender, time);
                        accounts.Add(account);
                    }
                }
                return accounts;
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
