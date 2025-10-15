<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjemploRealCookie.aspx.cs" Inherits="ISSD_TP4_DLP3_DAI5_clase09.EjemploRealCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body runat="server" id="cuerpo">
    <form id="form1" runat="server">
        
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="white">Blanco</asp:ListItem>
            <asp:ListItem Value="black">Negro</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Ir al menu</asp:HyperLink>
        </div>
    </form>
</body>
</html>
