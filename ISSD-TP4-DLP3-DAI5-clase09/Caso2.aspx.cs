using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISSD_TP4_DLP3_DAI5_clase09
{
    public partial class Caso2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carrito"] != null)
            {
                List<string> carrito = (List<string>)Session["carrito"];
                Label1.Text = string.Empty;
                Label1.Text = "<hr>";
                foreach (string item in carrito) { 
                    Label1.Text += $"{item} <br>";
                }
            }
        }
    }
}