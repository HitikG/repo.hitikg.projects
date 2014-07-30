using HRiDiscuss;
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
            PowerToInnovate Power = new PowerToInnovate();
            if (Power.CheckUser(TbCreateUser.Text)) //Validates If The User Already Exists
            {
                LblCreateMsg.Text = "This Username Already Exists"; //Displays A Message
                TbCreateUser.Text = ""; //Clears The Textbox
            }
            else
            {
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
                    Power.CreateUser(TbCreateUser.Text, TbCreatePass.Text);
                    LblCreateMsg.Text = "Account Creation Succeded! Redirecting..."; //Displays A Message
                    TbCreateUser.Text = ""; //Clears The Textbox
                    Session["LoggedIn"] = "true"; //Sets The User As LoggedIn
                    Session["Username"] = TbCreateUser.Text;
                    Response.AddHeader("REFRESH", "1;URL=Default.aspx"); //Redirects To The Addlink Page
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            PowerToInnovate Power = new PowerToInnovate();

            if (Power.LoginUser(TbLoginUser.Text, TbLoginPass.Text))
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
    }
}
