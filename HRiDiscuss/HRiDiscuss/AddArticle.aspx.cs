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
            PowerToInnovate Power = new PowerToInnovate();

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
                Power.AddArticle(TbArticleTitle.Text, TbArticleText.Text, Session["Username"].ToString(), UploadImages);
                LblError.Text = "Article Added, Awaiting Moderation!"; //Displays A Message
                TbArticleTitle.Text = ""; //Clears The Textbox
                TbArticleText.Text = ""; //Clears The Textbox
            }
        }
    }
}
