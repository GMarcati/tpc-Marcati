﻿using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listado = new List<Categoria>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select ID, Nombre From Categorias Where Estado = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = lector.GetInt32(0);
                    aux.Nombre = lector.GetString(1);

                    listado.Add(aux);
                }

                return listado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.SetearQuery("Insert Categorias VALUES (@Nombre, 1)");
                datos.AgregarParametro("@Nombre", nuevo.Nombre);
                datos.EjecturAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();

            }
        }

        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE Categorias SET Nombre=@Nombre WHERE Id=@Id");
                datos.AgregarParametro("@Nombre", categoria.Nombre);
                datos.AgregarParametro("@ID", categoria.ID);
                datos.EjecturAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE Categorias set Estado = 0 where ID=" + id);
                datos.AgregarParametro("@ID", id);
                datos.EjecturAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
