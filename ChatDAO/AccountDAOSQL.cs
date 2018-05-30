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
                sql += "values ('" + account.Email + "','" + account.Password + "','" + account.Name + "','" + ImageConverter.ImageConverter.ConvertImageToBase64(account.Avatar) + "','" + account.Gender + "','" + account.TimeCreate + "')";
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
                        account.Avatar = ImageConverter.ImageConverter.ConvertBase64ToImage(data.GetString(3));
                        /*account.Avatar = ImageConverter.ImageConverter.CovertByteArrayToImage((Byte[])data.GetValue(3));*/
                        //Console.WriteLine(datas.ToString());
                        /*account.Avatar = ImageConverter.ImageConverter.CovertByteArrayToImage()*/
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
    }
}
