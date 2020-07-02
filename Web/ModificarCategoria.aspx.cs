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
    public partial class ModificarCategoria : System.Web.UI.Page
    {

        public Categoria categoria = new Categoria();
        public List<Categoria> listaCategoria = new List<Categoria>();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    
                    listaCategoria = categoriaNegocio.Listar();

                    var idcat = Request.QueryString["idcat"];
                    categoria = listaCategoria.Find(H => H.ID == Int32.Parse(idcat));             

                    tbxNombre.Text = categoria.Nombre;
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
            categoria.ID = Int32.Parse(Request.QueryString["idcat"]);
            if (categoria.ID != 0 && tbxNombre.Text != "")
            {
                categoria.Nombre = tbxNombre.Text.Trim();

                categoriaNegocio.Modificar(categoria);
            }


            Response.Redirect("Admin.aspx");

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            Response.Redirect("Admin.aspx");
        }
    }
}