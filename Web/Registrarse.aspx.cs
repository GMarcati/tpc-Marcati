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
    public partial class Registrarse1 : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public List<Usuario> listaUsuario = new List<Usuario>();
        UsuarioNegocio negocio = new UsuarioNegocio();
        TipoUsuarioNegocio tipoUsuario = new TipoUsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                listaUsuario = negocio.Listar();





                if (tbxUsuario.Text != "" && tbxEmail.Text != "" && tbxPassword.Text != "" && tbxConfirmarPassword.Text != "" && tbxNombre.Text != "" && tbxApellido.Text != "" && tbxDNI.Text != "" && tbxDomicilio.Text != "" && tbxPassword.Text == tbxConfirmarPassword.Text)
                {
                    usuario.Nombre_Usuario = tbxUsuario.Text.Trim();
                    usuario.Email = tbxEmail.Text.Trim();
                    usuario.Contraseña = tbxPassword.Text.Trim();
                    usuario.Nombre = tbxNombre.Text.Trim();
                    usuario.Apellido = tbxApellido.Text.Trim();
                    usuario.DNI = Int64.Parse(tbxDNI.Text.Trim());
                    usuario.Domicilio = tbxDomicilio.Text.Trim();

                }
                else
                {

                }


            }
            catch (Exception)
            {

                Session["Error" + Session.SessionID] = "Error al registrarse";
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (tbxUsuario.Text != "" && tbxEmail.Text != "" && tbxPassword.Text != "" && tbxConfirmarPassword.Text != "" && tbxNombre.Text != "" && tbxApellido.Text != "" && tbxDNI.Text != "" && tbxDomicilio.Text != "" && tbxPassword.Text == tbxConfirmarPassword.Text)
            {
                listaUsuario = negocio.Listar();
                bool bandera2 = false;
                bool bandera3 = false;
                foreach (var item in listaUsuario)
                {
                    if (item.Nombre_Usuario == tbxUsuario.Text || item.Email == tbxEmail.Text)
                    {
                        bandera2 = true;

                    }
                    if (item.DNI.ToString() == tbxDNI.Text)
                    {
                        bandera3 = true;
                    }
                }

                if (bandera2 || bandera3)
                {
                    Session["Error" + Session.SessionID] = "Nombre de usuario/Email/DNI ya registrado.";
                    Response.Redirect("ErrorLogin.aspx", false);
                }
                else
                {
                    negocio.Agregar(usuario);
                    Response.Redirect("Login.aspx", false);
                }

            }
            else
            {
                Session["Error" + Session.SessionID] = "Campos incompletos o las contraseñas ingresadas no coinciden.";
                Response.Redirect("ErrorLogin.aspx", false);

            }
                
            

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            Response.Redirect("Login.aspx");
        }
    }
}