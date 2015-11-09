<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Login - App Management</h1>
    
        Username&nbsp;
        <asp:TextBox ID="UsernameText" runat="server"></asp:TextBox>
        <br />
        Password&nbsp;
        <asp:TextBox ID="PasswordText" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    
        <br />
        <br />
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
