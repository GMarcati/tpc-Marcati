using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Web
{
    public partial class AltaCategoria : System.Web.UI.Page
    {
        public Categoria categoria = new Categoria();
        CategoriaNegocio negocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usersession"];
                if (usuario == null || usuario.TipoUsuario.ID != 1)
                {
                    Session["Error" + Session.SessionID] = "El usuario no tiene permisos para ingresar a la pagina.";
                    Response.Redirect("Error.aspx", false);
                }

                if (tbxNombre.Text != "")
                {
                    categoria.Nombre = tbxNombre.Text.Trim();
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (tbxNombre.Text != "")
                negocio.Agregar(categoria);
            Response.Redirect("Admin.aspx");

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            Response.Redirect("Admin.aspx");
        }
    }
}