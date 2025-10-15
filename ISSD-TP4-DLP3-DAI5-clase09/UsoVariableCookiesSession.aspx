<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsoVariableCookiesSession.aspx.cs" Inherits="ISSD_TP4_DLP3_DAI5_clase09.UsoVariableCookiesSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            COOKIES<br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
            Valor<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            Segundos Expiracion<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear" />
            <br />
            <br />
            SESSIONS<br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Crear" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Ir al Menu</asp:HyperLink>
        </div>
    </form>
</body>
</html>
