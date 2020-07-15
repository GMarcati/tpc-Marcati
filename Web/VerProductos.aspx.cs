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
    public partial class VerProductos : System.Web.UI.Page
    {

        public List<Producto_X_Venta> listaProducto_X_Venta { get; set; }
        public VentasNegocio negocioVenta = new VentasNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            var idVen = Request.QueryString["idVenta"];
            if (idVen != null)
            {
                listaProducto_X_Venta = negocioVenta.ListarProductoVenta();

            }

        }
    }
}