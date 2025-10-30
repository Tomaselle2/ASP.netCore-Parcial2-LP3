using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepasoLP3
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //btn agrgar
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["descripcion"].DefaultValue = TextBox1.Text;
            SqlDataSource1.InsertParameters["precio"].DefaultValue = TextBox2.Text;
            SqlDataSource1.InsertParameters["url"].DefaultValue = FileUpload1.FileName;
            SqlDataSource1.Insert();

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string nombreArchivo = row.Cells[3].Text;
            Image1.ImageUrl = "~/images/" + nombreArchivo;
        }
    }
}