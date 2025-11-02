<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="TablaArchivos.aspx.cs" Inherits="EjemploParcial2.TablaArchivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tabla de archivos</h1>
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Descargar" Text="Descargar" />
            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
            <asp:CommandField CancelText="" DeleteText="" EditText="" HeaderText="Seleccionar" InsertText="" NewText="" ShowSelectButton="True" UpdateText="" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Image ID="Image1" runat="server" Height="214px" Width="410px" />
    <br />
    <br />
            <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
    <br />
            <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
    <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
    <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar producto" />
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="url" HeaderText="url" SortExpression="url" />
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:parcial2pl3 %>" DeleteCommand="DELETE FROM [Productos] WHERE [id] = @id" InsertCommand="INSERT INTO [Productos] ([descripcion], [url], [precio]) VALUES (@descripcion, @url, @precio)" ProviderName="<%$ ConnectionStrings:parcial2pl3.ProviderName %>" SelectCommand="SELECT * FROM [Productos]" UpdateCommand="UPDATE [Productos] SET [descripcion] = @descripcion, [url] = @url, [precio] = @precio WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="url" Type="String" />
                    <asp:Parameter Name="precio" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="url" Type="String" />
                    <asp:Parameter Name="precio" Type="Decimal" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </asp:Content>
