using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShare
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (CheckUser(TbCreateUser.Text)) //Validates If The User Already Exists
            {
                LblCreateMsg.Text = "This Username Already Exists"; //Displays A Message
                TbCreateUser.Text = ""; //Clears The Textbox
            }
            else
            {
                string AccountQuery = "INSERT INTO Accounts (Username, Password)  VALUES (@Username, @Password)"; //Our Query To Insert
                SqlConnection AccountConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
                SqlCommand AccountCmd = new SqlCommand(AccountQuery, AccountConnect); //Create A Command To Add To The Database
                
                SqlParameter ParamUsername;
                ParamUsername = new SqlParameter("@Username", SqlDbType.VarChar, 10);
                ParamUsername.Value = TbCreateUser.Text;
                AccountCmd.Parameters.Add(ParamUsername);

                MD5CryptoServiceProvider Hasher = new MD5CryptoServiceProvider();
                byte[] HashedBytes;
                UTF8Encoding Encoder = new UTF8Encoding();
                HashedBytes = Hasher.ComputeHash(Encoder.GetBytes(TbCreatePass.Text));
                SqlParameter ParamPassword;
                ParamPassword = new SqlParameter("@Password", SqlDbType.Binary, 16);
                ParamPassword.Value = HashedBytes;
                AccountCmd.Parameters.Add(ParamPassword);
                                
                if (TbCreateUser.Text == "") //Checks If The Textbox Is Empty
                {
                    LblCreateMsg.Text = "Enter A Valid Username."; //Displays An Error
                }
                else if (TbCreatePass.Text == "") //Checks If The Textbox Is Empty
                {
                    LblCreateMsg.Text = "Enter A Valid Password."; //Displays An Error
                }
                else
                {
                    AccountConnect.Open(); //Opens The Connection
                    AccountCmd.ExecuteNonQuery(); //Excecutes
                    AccountConnect.Close(); //Closes The Connection
                    LblCreateMsg.Text = "Account Creation Succeded! Redirecting..."; //Displays A Message
                    TbCreateUser.Text = ""; //Clears The Textbox
                    TbCreatePass.Text = ""; //Clears The Textbox
                    Session["LoggedIn"] = "true"; //Sets The User As LoggedIn
                    Session["Username"] = TbCreateUser.Text;
                    Response.AddHeader("REFRESH", "1;URL=Default.aspx"); //Redirects To The Addlink Page
                }

            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string LoginQuery = "SELECT COUNT(*) FROM Accounts WHERE (Username=@Username AND Password=@Password)"; //Our Query To Insert
            SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Create A Command To Add To The Database
                        
            SqlParameter ParamUsername;
            ParamUsername = new SqlParameter("@Username", SqlDbType.VarChar, 25);
            ParamUsername.Value = TbLoginUser.Text;
            LoginCmd.Parameters.Add(ParamUsername);

            MD5CryptoServiceProvider Hasher = new MD5CryptoServiceProvider();
            byte[] HashedData;
            UTF8Encoding Encoder = new UTF8Encoding();
            HashedData = Hasher.ComputeHash(Encoder.GetBytes(TbLoginPass.Text));
            
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
                Session["LoggedIn"] = "true"; //They're Logged In
                Session["Username"] = TbLoginUser.Text; //Displays The User's Username
                Response.Redirect("Default.aspx"); //Redirect
            }
            else
            {
                LblLoginMsg.Text = "Login Failed, Enter Valid Credentials."; //Logon Failed 
            }
        }

        public bool CheckUser(string Username) //Checks If The User Exists
        {
            string LoginQuery = "SELECT * FROM Accounts WHERE Username=@Username"; //Our Query String
            SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection
            SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Declaring Our Command
            LoginCmd.Parameters.AddWithValue("@Username", TbCreateUser.Text); //Stores Our Data

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
/*public static  string GetPassword(string Username, string Password)
{
    string LoginQuery = "SELECT * FROM Accounts WHERE Username=@Username Password=@Password"; //Our Query String
    SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection
    SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Declaring Our Command
    LoginCmd.Parameters.AddWithValue("@Username", TbLoginUser.Text); //Stores Our Data
    LoginCmd.Parameters.AddWithValue("@Password", TbLoginPass.Text); //Stores Our Data

    int UserCount = 0; //Declaring Our Int
    LoginConnect.Open(); //Opens Our Connection
    SqlDataReader CheckReader = LoginCmd.ExecuteReader(); //Opens Our Reader

    while (CheckReader.Read()) //While It Reads
    {
        UserCount++; //Checks
    }
    LoginConnect.Close();

    return Username;
    return Password;
}*/



