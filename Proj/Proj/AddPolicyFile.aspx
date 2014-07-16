<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPolicyFile.aspx.cs" Inherits="Proj.AddPolicyFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label3" runat="server" Text="Associate a Policy File with the Object" Font-Size="Large"></asp:Label>
        <br />
        <br />
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
       
      
        <asp:Label ID="Label1" runat="server" Text="File Uploaded" Visible="false"></asp:Label>
    <br />
     <asp:Label ID="Label2" runat="server" Text="Select the object associated with it."></asp:Label>
       <%-- <asp:TextBox ID="TextBox2" runat="server" Text="Select the object associated with it."></asp:TextBox>--%>
     <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="ObjectId" 
            DataValueField="ObjectId">
        </asp:DropDownList>
        <br />

         <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" />
         <br />

         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=localhost;Initial Catalog=projectcapstone;Integrated Security=True;Pooling=False" 
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Object]">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
