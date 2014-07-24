using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HRiDiscuss
{
    public class PowerToInnovate
    {
        public bool LoginUser(string Username, string Password) //Checks If The User Exists
        {
            string LoginQuery = "SELECT COUNT(*) FROM Accounts WHERE (Username=@Username AND Password=@Password)"; //Our Query To Insert
            SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Create A Command To Add To The Database

            SqlParameter ParamUsername;
            ParamUsername = new SqlParameter("@Username", SqlDbType.VarChar, 25);
            ParamUsername.Value = Username;
            LoginCmd.Parameters.Add(ParamUsername);

            MD5CryptoServiceProvider Hasher = new MD5CryptoServiceProvider();
            byte[] HashedData;
            UTF8Encoding Encoder = new UTF8Encoding();
            HashedData = Hasher.ComputeHash(Encoder.GetBytes(Password));

            SqlParameter ParamPassword;
            ParamPassword = new SqlParameter("@Password", SqlDbType.Binary, 16);
            ParamPassword.Value = HashedData;
            LoginCmd.Parameters.Add(ParamPassword);
            int ExistingUsers = 0;

            LoginConnect.Open(); //Open The Connection
            ExistingUsers = Convert.ToInt32(LoginCmd.ExecuteScalar().ToString()); 
            LoginConnect.Close(); //Close Our Connection

            if (ExistingUsers > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CreateUser(string User, string Pass)
        {
            string AccountQuery = "INSERT INTO Accounts (Username, Password)  VALUES (@Username, @Password)"; //Our Query To Insert
            SqlConnection AccountConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand AccountCmd = new SqlCommand(AccountQuery, AccountConnect); //Create A Command To Add To The Database

            SqlParameter ParamUsername;
            ParamUsername = new SqlParameter("@Username", SqlDbType.VarChar, 10);
            ParamUsername.Value = User;
            AccountCmd.Parameters.Add(ParamUsername);

            MD5CryptoServiceProvider Hasher = new MD5CryptoServiceProvider();
            byte[] HashedBytes;
            UTF8Encoding Encoder = new UTF8Encoding();
            HashedBytes = Hasher.ComputeHash(Encoder.GetBytes(Pass));
            SqlParameter ParamPassword;

            ParamPassword = new SqlParameter("@Password", SqlDbType.Binary, 16);
            ParamPassword.Value = HashedBytes;
            AccountCmd.Parameters.Add(ParamPassword);

            AccountConnect.Open(); //Opens The Connection
            AccountCmd.ExecuteNonQuery(); //Excecutes
            AccountConnect.Close(); //Closes The Connection

        }
        public void AddArticle(string Title, string Text, string Username, System.Web.UI.WebControls.FileUpload UploadImages)
        {
            string ArticleQuery = "INSERT INTO Articles (ArticleTitle, ArticleText, ArticleAuthor, ArticlePostDate, ArticleImage, IsModerated)  VALUES (@ArticleTitle, @ArticleText, @ArticleAuthor, @ArticlePostDate, @ArticleImage, @IsModerated)"; //Our Query To Insert
            SqlConnection ArticleConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand ArticleCmd = new SqlCommand(ArticleQuery, ArticleConnect); //Create A Command To Add To The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleTitle", Title); //Inserts The Username Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleText", Text); //Inserts The Password Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleAuthor", Username); //Inserts The Username Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticlePostDate", DateTime.Now); //Inserts The Password Into The Database
            ArticleCmd.Parameters.AddWithValue("@IsModerated", "No"); //Inserts The Password Into The Database

            int Length = UploadImages.PostedFile.ContentLength;
            byte[] IMGByte = new byte[Length];
            HttpPostedFile img = UploadImages.PostedFile;
            img.InputStream.Read(IMGByte, 0, Length);

            ArticleCmd.Parameters.AddWithValue("@ArticleImage", IMGByte); //Inserts The Password Into The Database

                ArticleConnect.Open(); //Opens The Connection
                ArticleCmd.ExecuteNonQuery(); //Excecutes
                ArticleConnect.Close(); //Closes The Connection
            
        }
        public bool CheckUser(string Username) //Checks If The User Exists
        {
            string LoginQuery = "SELECT * FROM Accounts WHERE Username=@Username"; //Our Query String
            SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection
            SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Declaring Our Command
            LoginCmd.Parameters.AddWithValue("@Username", Username); //Stores Our Data

            int UserCount = 0; //Declaring Our Int
            LoginConnect.Open(); //Opens Our Connection
            SqlDataReader CheckReader = LoginCmd.ExecuteReader(); //Opens Our Reader

            while (CheckReader.Read()) //While It Reads
            {
                UserCount++; //Checks
            }
            LoginConnect.Close(); //Close Our Connection

            if (UserCount > 0) // If There Is 1 User
            {
                return true; //Return True
            }
            else
            {
                return false; //Return False
            }
        }        
    }
}