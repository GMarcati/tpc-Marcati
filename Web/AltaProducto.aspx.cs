using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Web
{
    
    public partial class AltaProducto : System.Web.UI.Page
    {
        public Producto producto = new Producto();
        public List<Producto> listaProducto = new List<Producto>();
        ProductoNegocio negocio = new ProductoNegocio();
        CategoriaNegocio categoria = new CategoriaNegocio();
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

                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = categoria.Listar();
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }

                listaProducto = negocio.Listar();



                
                
                if (tbxCodigo.Text != "" && tbxNombre.Text != "" && tbxDescripcion.Text != "" && tbxImagenURL.Text != "" && tbxPrecio.Text != "")
                {
                    producto.Codigo = tbxCodigo.Text.Trim();
                    producto.Nombre = tbxNombre.Text.Trim();
                    producto.Descripcion = tbxDescripcion.Text.Trim();
                    producto.ImagenURL = tbxImagenURL.Text.Trim();
                    producto.Categoria = new Categoria();
                    producto.Categoria.ID = int.Parse(ddlCategoria.SelectedValue);
                    producto.Precio = Convert.ToDecimal(tbxPrecio.Text.Trim());
                    producto.Stock = Int64.Parse(tbxStock.Text.Trim());
                } else
                {

                }
                    //    producto.Codigo = tbxCodigo.Text.Trim();
                    //if (tbxNombre.Text != "")
                    //    producto.Nombre = tbxNombre.Text.Trim();
                    //if (tbxDescripcion.Text != "")
                    //    producto.Descripcion = tbxDescripcion.Text.Trim();
                    ////cboCategoria.Items.Add("Pizzas");
                    ////producto.Categoria = (Categoria)cboCategoria.SelectedValue;
                    //if (tbxImagenURL.Text != "")
                    //    producto.ImagenURL = tbxImagenURL.Text.Trim();
                    //if (tbxPrecio.Text != "")
                    //    producto.Precio = Convert.ToDecimal(tbxPrecio.Text.Trim());
                    //if (!listaProducto.Contains(producto))

            }
            catch (Exception ex)
            {

                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if(tbxCodigo.Text != "" && tbxNombre.Text != "" && tbxDescripcion.Text != "" && tbxImagenURL.Text != "" && tbxPrecio.Text != "" && tbxStock.Text != "")
                negocio.Agregar(producto);
            Response.Redirect("Admin.aspx");

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            Response.Redirect("Admin.aspx");
        }



    }
}