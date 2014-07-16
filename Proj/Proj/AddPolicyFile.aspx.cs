using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace Proj
{
    public partial class AddPolicyFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("Data") + "//" + FileUpload1.FileName);
            FileUpload1.Visible = false;
            Button1.Visible = false;
           // TextBox1.Visible = true;
            Label1.Visible = true;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("Insert into Policy(Rules) values (@filename)", connect);
            connect.Open();
            command.Parameters.Add("@filename", SqlDbType.NVarChar).Value = FileUpload1.FileName;
            command.ExecuteNonQuery();
            command.CommandText = "Select @@Identity";
            int id = Convert.ToInt32(command.ExecuteScalar());
            string objectid = DropDownList2.SelectedValue;
            command.CommandText = "Insert into Object_Policy_Assignment values(@policyid,@objectid)";
            command.Parameters.Add("@policyid", SqlDbType.Int).Value = id;
            command.Parameters.Add("objectid", SqlDbType.Int).Value = Convert.ToInt32(objectid);
            command.ExecuteNonQuery();
           // Response.Write(id.ToString());

        }
    }
}