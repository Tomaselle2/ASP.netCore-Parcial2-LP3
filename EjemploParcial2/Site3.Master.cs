using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000); // 2 segundos de demora

            if (Session["usuarioLogueado"] != null)
            {
                Session["usuarioLogueado"] = null;
                Response.Redirect("Login.aspx");
            }
        }
    }
}