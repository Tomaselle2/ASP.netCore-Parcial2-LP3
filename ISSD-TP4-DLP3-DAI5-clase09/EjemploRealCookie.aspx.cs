using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISSD_TP4_DLP3_DAI5_clase09
{
    public partial class EjemploRealCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["colorFondo"];
            if(cookie != null)
            {
                string color = cookie.Value;
                cuerpo.Style["background-color"] = color;
                form1.Style["background-color"] = color;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie httpCookie = new HttpCookie("colorFondo", DropDownList1.SelectedValue);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(httpCookie);

            cuerpo.Style["background-color"] = DropDownList1.SelectedValue;
            form1.Style["background-color"] = DropDownList1.SelectedValue;
        }
    }
}