<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppManagement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>App Management</h1>
    </div>
        <asp:Button ID="LogoutButton" runat="server" OnClick="LogoutButton_Click" Text="Logout" />
        <asp:Button ID="LogButton" runat="server" OnClick="LogButton_Click" Text="Logs" />
    </form>
</body>
</html>
