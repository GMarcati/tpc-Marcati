using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Dominio.Carrito> listaCarrito { get; set; }
        public bool bandera;
        public Dominio.Carrito carrito = new Dominio.Carrito();
        public ItemCarrito CarritoItem = new ItemCarrito();
        public VentasNegocio negocioVenta = new VentasNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bandera = false;
                }

                carrito.listaItem = (List<ItemCarrito>)Session[Session.SessionID + "listaCarrito"];
                if (carrito.listaItem == null)
                    carrito.listaItem = new List<ItemCarrito>();

                var prodQuitar = Request.QueryString["idQuitar"];
                if (prodQuitar != null)
                {


                    ItemCarrito productoQuitar = carrito.listaItem.Find(J => J.Producto.ID == int.Parse(prodQuitar));

                    carrito.listaItem.Remove(productoQuitar);

                    Session[Session.SessionID + "listaCarrito"] = carrito.listaItem;
                    Response.Redirect("Carrito.aspx", false);

                }
                else if (Request.QueryString["idprod"] != null)
                {

                    //obtengo lista original (el listado completo)
                    List<Producto> listaOriginal = (List<Producto>)Session[Session.SessionID + "listaProducto"];

                    var prodSeleccionado = Convert.ToInt32(Request.QueryString["idprod"]);
                    Producto producto = listaOriginal.Find(J => J.ID == prodSeleccionado);

                    ItemCarrito auxCarrito = carrito.listaItem.Find(B => B.Producto.ID == producto.ID);

                    if (auxCarrito == null)
                    {

                        CarritoItem.Producto = producto;
                        
                        CarritoItem.Cantidad++;

                        carrito.Total += CarritoItem.Producto.Precio;
                        carrito.listaItem.Add(CarritoItem);
                        Session[Session.SessionID + "listaCarrito"] = carrito.listaItem;
                        

                    }
                    Response.Redirect("Carrito.aspx", false);

                }

                var CantRest = Request.QueryString["idCantRest"];
                if (CantRest != null)
                {
                    if (!bandera)
                    {

                    }

                    ItemCarrito productoRestar = carrito.listaItem.Find(J => J.Producto.ID == int.Parse(CantRest));

                    if (productoRestar.Cantidad != 0 && productoRestar.Cantidad != 1)
                    {
                        productoRestar.Cantidad--;
                    }
                    else
                    {
                        
                    }
                  
                    Session[Session.SessionID + "listaCarrito"] = carrito.listaItem;
                    Response.Redirect("Carrito.aspx",false);

                }

                var CantSum = Request.QueryString["idCantSum"];
                if (CantSum != null)
                {
                    ItemCarrito productoSumar = carrito.listaItem.Find(J => J.Producto.ID == int.Parse(CantSum));

                    if (productoSumar.Cantidad == productoSumar.Producto.Stock || productoSumar.Cantidad > productoSumar.Producto.Stock)
                    {

                    }
                    else
                    {
                        productoSumar.Cantidad++;
                    }

                    Session[Session.SessionID + "listaCarrito"] = carrito.listaItem;
                    Response.Redirect("Carrito.aspx", false);
                }

                var idCarrito = Request.QueryString["idComprar"];
                if(idCarrito != null)
                {
                    Usuario usuario = (Usuario)Session["usersession"];

                    if (usuario == null)
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                    else
                    {

                    }

                    //foreach (var item in listaCarrito)
                    //{
                    //    foreach (var item2 in item.listaItem)
                    //    {
                    //        item2.

                    //        negocioVenta.AgregarItem(item2);
                    //    }

                    //}




                }



            }
            catch (Exception ex)
            {
                //Session["Error" + Session.SessionID] = "Error en el carrito";
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }



    }
}