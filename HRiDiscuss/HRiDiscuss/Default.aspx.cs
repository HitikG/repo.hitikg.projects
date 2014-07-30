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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ArticleQuery = "SELECT * FROM Articles ORDER BY ArticleID DESC "; //Our Query To Insert
            SqlConnection ArticleConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand ArticleCmd = new SqlCommand(ArticleQuery, ArticleConnect); //Create A Command To Add To The Database
            ArticleConnect.Open();
            SqlDataReader DrData = ArticleCmd.ExecuteReader();
;

            /*/*foreach (DataRow row in table.Rows) // Loop over the rows.
            {
                LblPostTitle1.Text = DrData["ArticleTitle"].ToString();
                LblPostInfo1.Text = DrData["ArticlePostDate"].ToString();

                LblPostText1.Text = DrData["ArticleText"].ToString();



                LblPostTitle2.Text = DrData["ArticleTitle"].ToString();
                LblPostInfo2.Text = DrData["ArticlePostDate"].ToString();

                LblPostText2.Text = DrData["ArticleText"].ToString();

        //    }*/

            ArticleConnect.Close();
        }
    }
}