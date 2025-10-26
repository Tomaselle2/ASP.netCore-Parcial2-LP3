<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Archivo.aspx.cs" Inherits="EjemploParcial2.Archivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <h1>Subir archivo</h1>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir" />
</asp:Content>
