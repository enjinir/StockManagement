<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="AppManagement.Logs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="LogsView" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="StockDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="OperationType" HeaderText="OperationType" SortExpression="OperationType" />
                <asp:BoundField DataField="OperationDetails" HeaderText="OperationDetails" SortExpression="OperationDetails" />
                <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                <asp:BoundField DataField="OperationDate" HeaderText="OperationDate" SortExpression="OperationDate" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="StockDataSource" runat="server" ConnectionString="Data Source=.\SqlExpress;Initial Catalog=StockManagement;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [OperationType], [OperationDetails], [FullName], [OperationDate] FROM [Logs] ORDER BY [OperationDate] DESC"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
