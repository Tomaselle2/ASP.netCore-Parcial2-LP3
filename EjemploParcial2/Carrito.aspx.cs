using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGrilla();
        }

        //boton agregar al carrito
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> carrito = new List<string>();
            if (Session["carrito"] != null)
            {
                carrito = (List<string>)Session["carrito"];
            }
            carrito.Add(TextBox1.Text);
            Session["carrito"] = carrito;
            llenarGrilla();
            TextBox1.Text = string.Empty;
        }

        private void llenarGrilla()
        {
            if (Session["carrito"] != null)
            {
                List<string> carrito = (List<string>)Session["carrito"];
                GridView1.DataSource = carrito;
                GridView1.DataBind();
            }

        }

        //vaciar carrito
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            GridView1.DataSource = Session["carrito"];
            GridView1.DataBind();
        }
    }
}