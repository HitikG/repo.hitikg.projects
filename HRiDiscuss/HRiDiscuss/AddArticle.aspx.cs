using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRiDiscuss
{
    public partial class AddArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddArticle_Click(object sender, EventArgs e)
        {
            Session["Username"] = "HitikG";
            string AccountQuery = "INSERT INTO Articles (ArticleTitle, ArticleText, ArticleAuthor, ArticlePostDate)  VALUES (@ArticleTitle, @ArticleText, @ArticleAuthor, @ArticlePostDate)"; //Our Query To Insert
            SqlConnection AccountConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand AccountCmd = new SqlCommand(AccountQuery, AccountConnect); //Create A Command To Add To The Database
            AccountCmd.Parameters.AddWithValue("@ArticleTitle", TbArticleTitle.Text); //Inserts The Username Into The Database
            AccountCmd.Parameters.AddWithValue("@ArticleText", TbArticleText.Text); //Inserts The Password Into The Database
            AccountCmd.Parameters.AddWithValue("@ArticleAuthor", Session["Username"].ToString()); //Inserts The Username Into The Database
            AccountCmd.Parameters.AddWithValue("@ArticlePostDate", DateTime.Now); //Inserts The Password Into The Database

            /*if (TbArticleTitle.Text == "") //Checks If The Textbox Is Empty
            {
                LblCreateMsg.Text = "Enter A Valid Username."; //Displays An Error
            }
            else if (TbCreatePass.Text == "") //Checks If The Textbox Is Empty
            {
                LblCreateMsg.Text = "Enter A Valid Password."; //Displays An Error
            }
            else
            {*/
                AccountConnect.Open(); //Opens The Connection
                AccountCmd.ExecuteNonQuery(); //Excecutes
                AccountConnect.Close(); //Closes The Connection
                /*LblCreateMsg.Text = "Account Creation Succeded! Redirecting..."; //Displays A Message
                TbCreateUser.Text = ""; //Clears The Textbox
                TbCreatePass.Text = ""; //Clears The Textbox
                Session["LoggedIn"] = "true"; //Sets The User As LoggedIn
                Session["Username"] = TbCreateUser.Text;
                Response.AddHeader("REFRESH", "1;URL=Addlink.aspx"); //Redirects To The Addlink Page*/
            //}
        }
    }
}