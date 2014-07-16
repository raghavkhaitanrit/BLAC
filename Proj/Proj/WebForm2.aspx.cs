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
using System.Xml;

namespace Proj
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string objectid = DropDownList2.SelectedValue;
            Session["ObjectId"] = objectid;
            checkUserIdConstraints();

        }
        protected void checkUserIdConstraints()
        {
            string department="";
            string location = "" ;
            string provider = "";
            int userid = Convert.ToInt32(Session["UserId"]);
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("Select * from SubjectPseudoRole where UserId = @userid", connect);
            connect.Open();
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
            //command.ExecuteNonQuery();
            SqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                 department = myReader["Department"].ToString();
                 provider = myReader["Provider"].ToString();
                 location = myReader["Location"].ToString();
            }
            checkAgainstPolicy(department, provider, location);
            connect.Close();
        }
        protected void checkAgainstPolicy(string dept, string provider, string locn)
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);
           // SqlConnection connect = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("Select Policy_Id from Object_Policy_Assignment where Object_id = @objectid", connect);
            connect.Open();
            command.Parameters.Add("@objectid", SqlDbType.Int).Value = Convert.ToInt32(Session["ObjectId"]);
            int policyid = Convert.ToInt32(command.ExecuteScalar());
            //Response.Write(policyid.ToString());
            command.CommandText = "Select Rules from Policy where PolicyId=@policyid";
            command.Parameters.Add("@policyid", SqlDbType.Int).Value = policyid;
            SqlDataReader reader = command.ExecuteReader();
            string filename = "";
            while (reader.Read())
            {
                filename = reader["Rules"].ToString();
            }
            readXml1(filename,dept,provider,locn);
        }
        public void readXml1(string filename, string dept, string prov,string locn)
        {
            bool flag = false;
            XmlDocument doc = new XmlDocument();
            string department = "";
            string provider = "";
            string location = "";
            string relationship = "";
            //Load XML from the file into XmlDocument object
            doc.Load(Server.MapPath("~/Data/"+filename+""));
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("PseudoRole");
            foreach (XmlNode node in nodeList)
            {
                department = node.SelectSingleNode("Department").InnerText;
                provider = node.SelectSingleNode("Provider").InnerText;
                location = node.SelectSingleNode("Location").InnerText;
                relationship = node.SelectSingleNode("Relationship").InnerText; ;
            }
            string[] relationships = relationship.Split(',');
            if (relationships[1] == "And")
            {
                if ((location == locn) && (provider == prov))
                {
                    flag = true;
                }
                else {
                    if (department == dept)
                        flag = true;
                }
            }

            Session["Access"] = flag;
            Response.Redirect("FinalPage.aspx");
        }
    }
}