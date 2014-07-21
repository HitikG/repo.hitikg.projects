using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            if (Session["LoggedIn"] == null)
            {
                Response.AddHeader("REFRESH", "1;URL=Login.aspx"); //Redirects To The Addlink Page
            }
            if (Session["LoggedIn"] != null)
            {
                string Username = Session["Username"].ToString();
                Session["Username"] = Username.ToString();
            }

        }

        protected void BtnAddArticle_Click(object sender, EventArgs e)
        {
            string ArticleQuery = "INSERT INTO Articles (ArticleTitle, ArticleText, ArticleAuthor, ArticlePostDate, ArticleImage, IsModerated)  VALUES (@ArticleTitle, @ArticleText, @ArticleAuthor, @ArticlePostDate, @ArticleImage, @IsModerated)"; //Our Query To Insert
            SqlConnection ArticleConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand ArticleCmd = new SqlCommand(ArticleQuery, ArticleConnect); //Create A Command To Add To The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleTitle", TbArticleTitle.Text); //Inserts The Username Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleText", TbArticleText.Text); //Inserts The Password Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticleAuthor", Session["Username"].ToString()); //Inserts The Username Into The Database
            ArticleCmd.Parameters.AddWithValue("@ArticlePostDate", DateTime.Now); //Inserts The Password Into The Database
            ArticleCmd.Parameters.AddWithValue("@IsModerated", "No"); //Inserts The Password Into The Database


            bool test = true;
            int Length = UploadImages.PostedFile.ContentLength;
            byte[] IMGByte = new byte[Length];
            HttpPostedFile img = UploadImages.PostedFile;
            img.InputStream.Read(IMGByte, 0, Length);

            ArticleCmd.Parameters.AddWithValue("@ArticleImage", IMGByte); //Inserts The Password Into The Database

            if (TbArticleText.Text == "") //Checks If The Textbox Is Empty
            {
                LblError.Text = "Enter A Valid Article Body."; //Displays An Error
                if (TbArticleTitle.Text == "") //Checks If The Textbox Is Empty
                {
                    LblError.Text = "Enter A Valid Title."; //Displays An Error                   
                }
            }
            else
            {
                ArticleConnect.Open(); //Opens The Connection
                ArticleCmd.ExecuteNonQuery(); //Excecutes
                ArticleConnect.Close(); //Closes The Connection
                LblError.Text = "Article Added, Awaiting Moderation!"; //Displays A Message
                TbArticleTitle.Text = ""; //Clears The Textbox
                TbArticleText.Text = ""; //Clears The Textbox
            }
        }
    }
}
