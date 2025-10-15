<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjemploRealSession.aspx.cs" Inherits="ISSD_TP4_DLP3_DAI5_clase09.EjemploRealSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar al Carrito" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Vaciar Carrito" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Volver Menu</asp:HyperLink>
        </div>
    </form>
</body>
</html>
