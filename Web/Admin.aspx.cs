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
    public partial class Admin : System.Web.UI.Page
    {
        public List<Producto> listaProducto { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        public List<Venta> listaVenta { get; set; }

        public List<Producto> listaProductosEliminados { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usersession"];
                if (usuario == null)
                {
                    Session["Error" + Session.SessionID] = "El usuario no tiene permisos para ingresar a la pagina.";
                    Response.Redirect("Error.aspx", false);
                } else if (usuario.TipoUsuario.ID != 1)
                {
                    Session["Error" + Session.SessionID] = "El usuario " + usuario.Nombre_Usuario + " no tiene permisos para ingresar a la pagina.";
                    Response.Redirect("Error.aspx", false);
                }




                CategoriaNegocio negocioCat = new CategoriaNegocio();
                listaCategoria = negocioCat.Listar();
                ProductoNegocio negocio = new ProductoNegocio();
                listaProducto = negocio.Listar();
                VentasNegocio negocioVentas = new VentasNegocio();
                listaVenta = negocioVentas.Listar();

                listaProductosEliminados = negocio.ListarEliminados();

                //Session[Session.SessionID + "listaProducto"] = listaProducto;

                var id = Request.QueryString["idQuitar"];
                //Int64 id = Int64.Parse(Request.QueryString["idQuitar"]);
                if (id != null)
                {
                    //negocio.Eliminar(Int64.Parse(id));
                    negocio.Eliminar(Convert.ToInt64(id));
                    listaProducto = negocio.Listar();
                    Response.Redirect("Admin.aspx", false);
                }

                var idCat = Request.QueryString["idQuitarCat"];
                if (idCat != null)
                {
                    negocioCat.Eliminar(Int32.Parse(idCat));
                    listaCategoria = negocioCat.Listar();
                    ////negocio.Eliminar(Int64.Parse(id));
                    //negocio.Eliminar(Convert.ToInt64(id));
                    //listaProducto = negocio.Listar();
                    Response.Redirect("Admin.aspx", false);
                }

                var idQuitarV = Request.QueryString["idQuitarVenta"];
                if (idQuitarV != null)
                {
                    negocioVentas.Eliminar(Int32.Parse(idQuitarV));
                    listaVenta = negocioVentas.Listar();
                    Response.Redirect("Admin.aspx", false);

                }


            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            try
            {
                //DialogResult dialogResult = MessageBox.Show("¿Estas seguro de eliminar el articulo seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    int id = ((Articulo)dgvArticulos.CurrentRow.DataBoundItem).ID;
                //    negocio.Eliminar(id);
                //    cargarGrilla();

                //}
                Int64 id = Int64.Parse(Request.QueryString["idQuitar"]);
                //Int64 id = Int64.Parse(Request.QueryString["idQuitar"]);
                if (id != 0)
                {
                    negocio.Eliminar(id);
                }




            }
            catch (Exception ex)
            {

                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

    }
}