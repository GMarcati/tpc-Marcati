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
        public List<Venta> listaVenta { get; set; }
        ProductoNegocio negocioProducto = new ProductoNegocio();
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
                    Response.Redirect("Carrito.aspx", false);

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
                if (idCarrito != null)
                {
                    Usuario usuario = (Usuario)Session["usersession"];


                    if ((List<ItemCarrito>)Session[Session.SessionID + "listaCarrito"] == null)
                    {
                        Session["Error" + Session.SessionID] = "Error al realizar la compra.";
                        Response.Redirect("Error.aspx", false);
                    }
                    else if (usuario == null)
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                    else
                    {


                        carrito.listaItem = (List<ItemCarrito>)Session[Session.SessionID + "listaCarrito"];

                        Producto_X_Venta productoXventa = new Producto_X_Venta();
                        List<Venta> listaVenta = new List<Venta>();
                        Producto producto = new Producto();


                        Venta venta = new Venta();
                        DateTime fechaHoy = DateTime.Now;


                        //decimal subtotal = 0;

                        //foreach (var item in listaItem)
                        //{
                        //    subtotal += item.PrecioItem();
                        //}
                        //Total = subtotal;

                        decimal total = carrito.SubTotal();
                        venta.usuario = usuario;
                        venta.PrecioTotal = total;
                        venta.Fecha = fechaHoy;
                        negocioVenta.Agregar(venta);

                        VentasNegocio negocioVentas = new VentasNegocio();
                        listaVenta = negocioVentas.Listar();

                        Int64 idVenta=0;

                        foreach (var item in listaVenta)
                        {

                            if (item.usuario.ID_Usuario == usuario.ID_Usuario)
                            {
                                idVenta = item.ID;

                            }
                        }

                        foreach (var itemCarrito in carrito.listaItem)
                        {
                            productoXventa.ID_Venta = idVenta;
                            productoXventa.ID_Producto = itemCarrito.Producto.ID;
                            productoXventa.Cantidad = itemCarrito.Cantidad;
                            //productoXventa.Precio = itemCarrito.PrecioItem();
                            productoXventa.Precio = itemCarrito.Producto.Precio;

                            producto.ID = itemCarrito.Producto.ID;
                            producto.Stock = itemCarrito.Producto.Stock - itemCarrito.Cantidad;

                            negocioProducto.ModificarStock(producto);
                            negocioVenta.AgregarItem(productoXventa);
                        }











                        Response.Redirect("CompraFinalizada.aspx", false);
                    }

                    //else
                    //{
                    //    Session["Error" + Session.SessionID] = "Error al realizar la compra.";
                    //    Response.Redirect("Error.aspx", false);
                    //}


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
                Session["Error" + Session.SessionID] = "Error en el carrito.";
                //Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }



    }
}