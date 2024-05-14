using System;
using System.Web;

namespace BaseCliente
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath == "/")
            {
                HttpContext.Current.Response.Redirect("~/Pages/ClientePesquisa.aspx");
            }
        }
    }
}