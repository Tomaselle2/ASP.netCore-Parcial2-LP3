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
            HttpCookie user = Request.Cookies["usuario"];
            if (user != null && user.Value.ToString() == TextBox1.Text)
            {
                //List<string> carrito = new List<string>();
                //Session["carrito"] = carrito;

                string[] usuario = {user.Value.ToString(), DropDownList1.SelectedValue.ToString()};

                Session["usuarioLogueado"] = usuario;

                if (DropDownList1.SelectedValue.ToString() == "Usuario")
                {
                    Response.Redirect("Carrito.aspx");
                }
                if (DropDownList1.SelectedValue.ToString() == "Administrador")
                {
                    Response.Redirect("Archivo.aspx");
                }
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