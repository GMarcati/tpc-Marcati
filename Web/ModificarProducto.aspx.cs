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
    public partial class ModificarProducto : System.Web.UI.Page
    {
        public Producto producto = new Producto();
        public List<Producto> listaProducto = new List<Producto>();
        ProductoNegocio negocio = new ProductoNegocio();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = (Usuario)Session["usersession"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx", false);
                }

                if (!IsPostBack)
                {
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    ddlCategoria.DataSource = categoria.Listar();
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataValueField = "ID";
                    ddlCategoria.DataBind();

                    

                    listaProducto = negocio.Listar();

                    var idprod = Request.QueryString["idprod"];
                    producto = listaProducto.Find(H => H.ID == Int64.Parse(idprod));
                    //tbxID.Text = idprod;              
                    
                    tbxCodigo.Text = producto.Codigo;
                    tbxNombre.Text = producto.Nombre;
                    tbxDescripcion.Text = producto.Descripcion;
                    if (producto.Categoria != null)
                        ddlCategoria.SelectedValue = Convert.ToString(producto.Categoria.ID);

                    tbxImagenURL.Text = producto.ImagenURL;
                    string precio = Convert.ToString(producto.Precio);
                    tbxPrecio.Text = precio;
                    tbxStock.Text = Convert.ToString(producto.Stock);

                }
            }
            catch (Exception ex)
            {

                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }





        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {CategoriaNegocio categoria = new CategoriaNegocio();
            producto.ID = Int64.Parse(Request.QueryString["idprod"]);
            if (producto.ID != 0 && tbxCodigo.Text != "" && tbxNombre.Text != "" && tbxDescripcion.Text != "" && tbxImagenURL.Text != "" && tbxPrecio.Text != "" && tbxStock.Text != "")
            {               
                producto.Codigo = tbxCodigo.Text.Trim();
                producto.Nombre = tbxNombre.Text.Trim();
                producto.Descripcion = tbxDescripcion.Text.Trim();
                producto.Categoria = new Categoria();
                producto.Categoria.ID = int.Parse(ddlCategoria.SelectedValue);
                producto.ImagenURL = tbxImagenURL.Text.Trim();
                producto.Precio = Convert.ToDecimal(tbxPrecio.Text.Trim());
                producto.Stock = Int64.Parse(tbxStock.Text.Trim());

                negocio.Modificar(producto);
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