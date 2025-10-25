<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="EjemploParcial2.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registar usuario
    </h1>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
&nbsp;
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="Button1_Click" />
&nbsp;<br />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="El campo usurio es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
</asp:Content>
