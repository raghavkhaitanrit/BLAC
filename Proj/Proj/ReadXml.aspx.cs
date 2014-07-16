using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;

namespace Proj
{
    public partial class ReadXml1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void readXml1()
        {
            XmlDocument doc = new XmlDocument();
            string department = "";
            string provider = "";
            string location = "";
            string relationship = "";
            //Load XML from the file into XmlDocument object
            doc.Load(Server.MapPath("~/Data/policy2.xml"));
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            readXml1();
        }
    }
}