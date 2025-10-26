using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Registrar btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = TextBox1.Text;
            TextBox1.Text = string.Empty;
            string script = $@"
                        Swal.fire({{
                            title: 'Éxito',
                            text: '{$"Usuario registrado exitosamente."}',
                            icon: 'success',
                            confirmButtonText: 'Aceptar'
                        }});
                ";
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
        }
    }
}