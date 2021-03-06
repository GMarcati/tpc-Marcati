﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web
{
    public partial class CompraFinalizada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usersession"];
            if (usuario == null)
            {
                Session["Error" + Session.SessionID] = "El usuario no tiene permisos para ingresar a la pagina.";
                Response.Redirect("Error.aspx", false);
            }

            Session.Contents.Remove(Session.SessionID + "listaCarrito");
        }
    }
}