using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISSD_TP4_DLP3_DAI5_clase09
{
    public partial class EjemploRealSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGrilla();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> carrito = new List<string>();
            if (Session["carrito"] != null)
            {
                carrito = (List<string>)Session["carrito"];
            }
            carrito.Add(TextBox1.Text);
            Session["carrito"] = carrito;
            llenarGrilla();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            llenarGrilla();
            GridView1.DataSource = Session["carrito"];
            GridView1.DataBind();
        }
    }
}