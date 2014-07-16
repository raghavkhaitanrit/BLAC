using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Proj
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void CreateUser_OnClick(object sender, EventArgs args)
        //{ 
        //}

        //protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        //{
        //    string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            
        //    MembershipUser newUser = Membership.GetUser(CreateUserWizard1.UserName);
        //    Guid newUserId = (Guid)newUser.ProviderUserKey;
        //    SqlConnection conn = new SqlConnection(conString);
        //    conn.Open();

        //    SqlCommand command = new SqlCommand();
        //    command.Connection = conn;
        //    command.CommandText = "Select UniqueId from aspnet_Users where UserName= @username";

        //    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = CreateUserWizard1.UserName;
        //    int userid = Convert.ToInt32(command.ExecuteScalar());
        //    string department = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TextBox7")).Text;
        //    string provider = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TextBox8")).Text;
        //    string location = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TextBox9")).Text;
        //    command.CommandText = "Insert into SubjectPseudorole(UserId,Provider,Department,Location) values (@userid,@provider,@departemnt,@location)";
        //    command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
        //    command.Parameters.Add("@provider", SqlDbType.VarChar).Value = provider;
        //    command.Parameters.Add("@departemnt", SqlDbType.VarChar).Value = department;
        //    command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
        //    command.ExecuteNonQuery();
        //    conn.Close();



        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            MembershipUser newUser = Membership.CreateUser(TextBox1.Text, TextBox2.Text, TextBox3.Text);
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "Select UniqueId from aspnet_Users where UserName= @username";

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = TextBox1.Text;
            int userid = Convert.ToInt32(command.ExecuteScalar());
            string department = TextBox4.Text;
            string provider = TextBox5.Text;
            string location = TextBox6.Text;
            command.CommandText = "Insert into SubjectPseudorole(UserId,Provider,Department,Location) values (@userid,@provider,@departemnt,@location)";
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@provider", SqlDbType.VarChar).Value = provider;
            command.Parameters.Add("@departemnt", SqlDbType.VarChar).Value = department;
            command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}