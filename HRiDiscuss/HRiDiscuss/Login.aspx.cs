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
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5 
                // We use the MD5 hash generator as the result is a 128 bit byte array 
                // which is a valid length for the TripleDES encoder we use below
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(TbCreatePass.Text));
                // Step 2. Create a new TripleDESCryptoServiceProvider object 
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                // Step 3. Setup the encoder 
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                // Step 4. Convert the input string to a byte[] 
                byte[] DataToEncrypt = UTF8.GetBytes(TbCreatePass.Text);

                // Step 5. Attempt to encrypt the string 
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information 
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                // Step 6. Return the encrypted string as a base64 encoded string 
                Convert.ToBase64String(Results);

                string AccountQuery = "INSERT INTO Accounts (Username, Password)  VALUES (@Username, @Password)"; //Our Query To Insert
                SqlConnection AccountConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
                SqlCommand AccountCmd = new SqlCommand(AccountQuery, AccountConnect); //Create A Command To Add To The Database
                AccountCmd.Parameters.AddWithValue("@Username", TbCreateUser.Text); //Inserts The Username Into The Database
                AccountCmd.Parameters.AddWithValue("@Password", Results); //Inserts The Password Into The Database



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

        /*protected void BtnLogin_Click(object sender, EventArgs e)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5 
            // We use the MD5 hash generator as the result is a 128 bit byte array 
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(TbLoginPass.Text));
            // Step 2. Create a new TripleDESCryptoServiceProvider object 
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Setup the encoder 
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[] 
            byte[] DataToEncrypt = UTF8.GetBytes(TbLoginPass.Text);

            // Step 5. Attempt to encrypt the string 
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information 
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Return the encrypted string as a base64 encoded string 
            string based = Convert.ToBase64String(Results);

            string LoginQuery = "SELECT * FROM Accounts WHERE Username=@Username Password=@Password"; //Our Query String
            SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection
            SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Declaring Our Command

            string User = TbLoginUser.Text;
            string Pass = TbLoginPass.Text;
            byte[] b = Convert.FromBase64String(based);

            based = System.Text.Encoding.UTF8.GetString(b);

            if (Results == b)
            {
                bool treu = true;
                LblLoginMsg.Text = "YES";
            }

            else
            {
                LblLoginMsg.Text = "FAIL";
            }
        }*/

        protected void BtnLogin_Click(object sender, EventArgs e)
         {
             byte[] Results;
             System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

             // Step 1. We hash the passphrase using MD5 
             // We use the MD5 hash generator as the result is a 128 bit byte array 
             // which is a valid length for the TripleDES encoder we use below
             MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
             byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(TbCreatePass.Text));
             // Step 2. Create a new TripleDESCryptoServiceProvider object 
             TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
             // Step 3. Setup the encoder 
             TDESAlgorithm.Key = TDESKey;
             TDESAlgorithm.Mode = CipherMode.ECB;
             TDESAlgorithm.Padding = PaddingMode.PKCS7;
             // Step 4. Convert the input string to a byte[] 
             byte[] DataToEncrypt = UTF8.GetBytes(TbCreatePass.Text);

             // Step 5. Attempt to encrypt the string 
             try
             {
                 ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                 Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
             }
             finally
             {
                 // Clear the TripleDes and Hashprovider services of any sensitive information 
                 TDESAlgorithm.Clear();
                 HashProvider.Clear();
             }
             // Step 6. Return the encrypted string as a base64 encoded string 
             Convert.ToBase64String(Results);

             byte[] Results;
             System.Text.UTF8Encoding UTrF8 = new System.Text.UTF8Encoding();
             // Step 1. We hash the passphrase using MD5 
             // We use the MD5 hash generator as the result is a 128 bit byte array 
             // which is a valid length for the TripleDES encoder we use below
             MD5CryptoServiceProvider HashPrrovider = new MD5CryptoServiceProvider();
             byte[] TDrESKey = HashProvider.ComputeHash(UTF8.GetBytes(TbLoginPass.Text));
             // Step 2. Create a new TripleDESCryptoServiceProvider object 
             TripleDESCryptoServiceProvider TDESrAlgorithm = new TripleDESCryptoServiceProvider();
             // Step 3. Setup the decoder 
             TDESAlgorithm.Key = TDESKey;
             TDESAlgorithm.Mode = CipherMode.ECB;
             TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[] 
             byte[] DataToDecrypt = Convert.FromBase64String(Results);

             // Step 5. Attempt to decrypt the string 
             try
             {
                 ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                 Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
             }
             finally
             {
                 // Clear the TripleDes and Hashprovider services of any sensitive information 
                 TDESAlgorithm.Clear();
                 HashProvider.Clear();
             }
             // Step 6. Return the decrypted string in UTF8 format 
             UTF8.GetString(Results);

             string LoginQuery = "SELECT * FROM Accounts WHERE Username=@Username AND Password=@Password"; //Our Query To Insert
             SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
             SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Create A Command To Add To The Database
             LoginCmd.Parameters.AddWithValue("@Username", TbLoginUser.Text); //Stores The Data
             LoginCmd.Parameters.AddWithValue("@Password", Results); //Stores The Data

             LoginConnect.Open(); //Open The Connection
             SqlDataReader Reader = LoginCmd.ExecuteReader(); //Reads The Database
             int counter = 0; //Declaring Our Int


             while (Reader.Read()) //While It Reads
             {
                 counter++; //Checks The Database
             }

             LoginConnect.Close(); //Close Our Connection 

             if (counter > 0) //If The User Exists
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
    }

}


