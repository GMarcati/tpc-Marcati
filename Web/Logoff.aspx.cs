using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web
{
    public partial class Logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usersession"];
            if (usuario == null)
            {
                Session["Error" + Session.SessionID] = "No hay usuario logeado.";
                Response.Redirect("Error.aspx", false);
            }

            Session.Contents.Remove("usersession");
        }
    }
}