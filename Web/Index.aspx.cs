﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        public List<Producto> listaProducto { get; set; }
        public string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usersession"];

                if (usuario != null)
                {
                    name = usuario.Nombre_Usuario;

                    if (usuario.TipoUsuario.ID == 1)
                    {
                        btnAdmin.Visible = true;
                    }
                    else
                    {
                        btnAdmin.Visible = false;
                    }
                }
                else
                {
                    name = "";
                    btnAdmin.Visible = false;
                }

                

                ProductoNegocio negocio = new ProductoNegocio();
                listaProducto = negocio.Listar();

                

                Session[Session.SessionID + "listaProducto"] = listaProducto;

            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }


        }

        protected void tbxBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada;

            try
            {
                if (tbxBusqueda.Text == "")
                {
                    listaFiltrada = listaProducto;
                }
                else
                {

                    listaFiltrada = listaProducto.FindAll(k => k.Nombre.ToLower().Contains(tbxBusqueda.Text.ToLower()) || (k.Categoria != null ? k.Categoria.Nombre.ToLower().Contains(tbxBusqueda.Text.ToLower()) : k.Nombre.Contains("")));

                }
                listaProducto = listaFiltrada;



            }
            catch (Exception)
            {

                Session["Error" + Session.SessionID] = "Error al filtrar los articulos";
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {

            Response.Redirect("Admin.aspx", false);

        }


    }
}