using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISSD_TP4_DLP3_DAI5_clase09
{
    public partial class UsoVariableCookiesSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ejemplo"];
            string valorLabel = cookie != null ? cookie.Value : "No existe la cookie.";
            Label1.Text = valorLabel;
            if (this.Session["nombreSesion"] != null) { 
                Label2.Text = Session["nombreSesion"].ToString();
            
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie httpCookie = new HttpCookie("ejemplo", TextBox1.Text);
            int segundos = int.Parse(TextBox3.Text);
            DateTime dateTime = DateTime.Now.AddSeconds(segundos);
            httpCookie.Expires = dateTime;
            Response.Cookies.Add(httpCookie);
            Response.Redirect(Request.RawUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Session["nombreSesion"] = TextBox2.Text;
            Response.Redirect(Request.RawUrl);
        }
    }
}