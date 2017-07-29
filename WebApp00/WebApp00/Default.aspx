<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp00.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div style="height: 197px">
            <asp:Label ID="lblInfo" runat="server" Text="Label">
                Click the button to fill the table
            </asp:Label>
            <br />
            <asp:GridView ID="CarGridView" runat="server" Width="226px">
            </asp:GridView>
            <br />
            <asp:Button ID="btnFillData" runat="server" Text="FillGrid"
                OnClick="btnFillData_Click"/>
        </div>
                      
    </form>

</body>
</html>
