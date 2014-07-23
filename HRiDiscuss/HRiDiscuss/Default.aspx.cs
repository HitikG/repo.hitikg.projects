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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ArticleQuery = "SELECT TOP 1 FROM Accounts ORDER BY ArticleID DESC "; //Our Query To Insert
            SqlConnection ArticleConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["DsAccounts"].ConnectionString); //Declaring Our Connection String
            SqlCommand ArticleCmd = new SqlCommand(ArticleQuery, ArticleConnect); //Create A Command To Add To The Database




        }
    }
} 