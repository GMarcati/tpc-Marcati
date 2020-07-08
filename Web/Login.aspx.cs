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
    public partial class Login1 : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public List<Usuario> listaUsuario = new List<Usuario>();
        UsuarioNegocio negocio = new UsuarioNegocio();
        VentasNegocio negocioVenta = new VentasNegocio();
        public string nombre;
        public Int64 idusuario;
        public bool bandera;
        protected void Page_Load(object sender, EventArgs e)
        {
            listaUsuario = negocio.Listar();

            try
            {
                bandera = false;

                if (tbxUsuario.Text != null && tbxPassword.Text != null)
                {
                    foreach (var usuario in listaUsuario)
                    {
                        if (tbxUsuario.Text == usuario.Nombre_Usuario && tbxPassword.Text == usuario.Contraseña)
                        {
                            //Response.Redirect("Index.aspx", false);
                            Session.Add("usersession", usuario);
                            bandera = true;
                            nombre = usuario.Nombre_Usuario;
                            idusuario = usuario.ID_Usuario;

                        }

                    }

                }


            }
            catch (Exception)
            {

                Session["Error" + Session.SessionID] = "Usuario o contraseña incorrectos.";
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                if (bandera)
                {
                    //Dominio.Carrito carrito = new Dominio.Carrito();
                    //DateTime fechaHoy = DateTime.Now;
                    //carrito.Fecha = fechaHoy;
                    //carrito.ID_Usuario = idusuario;
                    //carrito.ID++;
                    //negocioVenta.Agregar(carrito);
                    Response.Redirect("Index.aspx", false);
                }
                else
                {
                    Session["Error" + Session.SessionID] = "Usuario o contraseña incorrectos.";
                    Response.Redirect("ErrorLogin.aspx", false);
                }
                //if (tbxUsuario.Text != "" && tbxEmail.Text != "" && tbxPassword.Text != "" && tbxConfirmarPassword.Text != "" && tbxNombre.Text != "" && tbxApellido.Text != "" && tbxDNI.Text != "" && tbxDomicilio.Text != "") */
                // negocio.Agregar(usuario);




                //bandera = false;

                //if (tbxUsuario.Text != null && tbxPassword.Text != null)
                //{
                //    foreach (var usuario in listaUsuario)
                //    {
                //        if (tbxUsuario.Text == usuario.Nombre_Usuario && tbxPassword.Text == usuario.Contraseña)
                //        {
                //            //Response.Redirect("Index.aspx", false);
                //            Session.Add("usersession", usuario);
                //            //bandera = true;
                //            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Bienvenido " + usuario.Nombre_Usuario + "');", true);
                //            Response.Redirect("Index.aspx", false);
                //        }

                //    }

                //}


            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                //Session["Error" + Session.SessionID] = "Error inesperado en el login.";
                Response.Redirect("ErrorLogin.aspx",false);
            }




        }
    }
}