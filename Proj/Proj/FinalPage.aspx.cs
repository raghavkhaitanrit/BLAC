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

namespace Proj
{
    public partial class FinalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool access = Convert.ToBoolean(Session["Access"]);
            if (access = true)
            {
                Response.Write("Successfull:"+"\n");
                string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                SqlConnection connect = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("Select * from Object where ObjectId = @objectid", connect);
                connect.Open();
                command.Parameters.Add("@objectid", SqlDbType.Int).Value = Convert.ToInt32(Session["ObjectId"]);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Response.Write(reader["Object"].ToString()); 
                }
            }
        }
    }
}