using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Web.Security;


namespace Proj
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //string userName = Login1.UserName;
            //Guid userId;
            //string password = Login1.Password;
            //string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            //using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            //{
            //    //' declare the command that will be used to execute the select statement 
            //    SqlCommand com = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", con);

            //    // set the username and password parameters
            //    com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
            // //   com.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

            //    con.Open();
            //    //' execute the select statment 
            //    Guid result = new Guid(Convert.ToString(com.ExecuteNonQuery()));
            //    //' check the result 
            //    if (!string.IsNullOrEmpty(result.ToString()))
            //    {
            //        //invalid user/password , return flase 
            //        // return false;


            //        // valid login
            //        userId = result;
            //        bool result1 = UserLogin(userId, password);
            //        if ((result1))
            //        {
            //            e.Authenticated = true;
            //            Response.Redirect("WebForm2.aspx");
            //        }
            //        else
            //        {
            //            e.Authenticated = false;
            //        }
            //        //return true;
            //    }
            //    else {
            //        e.Authenticated = false;
            //    }
            //}
            if (Membership.ValidateUser(Login1.UserName, Login1.Password))
            {
                MembershipUser mu = Membership.GetUser(Login1.UserName);
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Select UniqueId from aspnet_Users where UserName= @username";

                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = Login1.UserName;
                int userid = Convert.ToInt32(command.ExecuteScalar());
                
                Session["UserId"] = userid;
                //string userid = Membership.GetUser(
                Response.Redirect("Webform2.aspx");
                e.Authenticated = true;

            }
            else
            {
                e.Authenticated = false;
            }

        }
        public bool UserLogin(Guid username, string password)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            {
                //' declare the command that will be used to execute the select statement 
                SqlCommand com = new SqlCommand("SELECT Email FROM aspnet_Membership WHERE UserId = @UserName AND Password = @Password", con);

                // set the username and password parameters
                com.Parameters.Add("@UserName", SqlDbType.UniqueIdentifier).Value = username;
                com.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                con.Open();
                //' execute the select statment 
                string result = Convert.ToString(com.ExecuteNonQuery());
                //' check the result 
                if (string.IsNullOrEmpty(result))
                {
                    //invalid user/password , return flase 
                    return false;
                }
                else
                {
                    // valid login
                    return true;
                }
            }
        }
    }
}