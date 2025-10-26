using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null && Session["usuario"].ToString() == TextBox1.Text)
            {
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                string script = $@"
                        Swal.fire({{
                            title: 'Error',
                            text: '{$"Usuario incorrecto, intente nuevamente."}',
                            icon: 'error',
                            confirmButtonText: 'Aceptar'
                        }});
                ";
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
            }

        }
    }
}