<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Proj.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Select the Object" Font-Size="Large"></asp:Label>
    <br />
        <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="ObjectId" 
            DataValueField="ObjectId">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>View</asp:ListItem>
            <asp:ListItem>Update</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=localhost;Initial Catalog=projectcapstone;Integrated Security=True;Pooling=False" 
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Object]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
