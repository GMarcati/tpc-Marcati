using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("spListarProducto");
                datos.EjecutarLector();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.ID = datos.Lector.GetInt64(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.ImagenURL = datos.Lector.GetString(4);
                    aux.Precio = datos.Lector.GetDecimal(5);
                    aux.Stock = datos.Lector.GetInt64(6);
                    if (!Convert.IsDBNull(datos.Lector["idCategoria"]))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.ID = (int)datos.Lector["idCategoria"];
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];

                    }

                    
                    
                    lista.Add(aux);

                }

                return lista;
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

        public void Agregar(Producto nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spAltaProducto";
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Parameters.AddWithValue("@Stock", nuevo.Stock);
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.ID);

                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

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
        public void Eliminar(Int64 id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearSP("spEliminarLogico");
                //datos.SetearQuery("UPDATE Productos set Estado = 0 where ID=" + id);
                datos.AgregarParametro("@ID", id);
                datos.EjecturAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearSP("spModificarProducto");

                datos.AgregarParametro("@Codigo", producto.Codigo);
                datos.AgregarParametro("@Nombre", producto.Nombre);
                datos.AgregarParametro("@Descripcion", producto.Descripcion);
                datos.AgregarParametro("@ImagenURL", producto.ImagenURL);
                datos.AgregarParametro("@Precio", producto.Precio);
                datos.AgregarParametro("@Stock", producto.Stock);
                datos.AgregarParametro("@IdCategoria", producto.Categoria.ID);               
                //datos.AgregarParametro("@IdCategoria", 1);
                datos.AgregarParametro("@ID", producto.ID);
                datos.EjecturAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarStock(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearSP("spModificarStockProducto");

                datos.AgregarParametro("@Stock", producto.Stock);
                datos.AgregarParametro("@ID", producto.ID);
                datos.EjecturAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<Producto> ListarEliminados()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("select * from VW_ProductosEliminados");
                datos.EjecutarLector();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.ID = datos.Lector.GetInt64(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.ImagenURL = datos.Lector.GetString(4);
                    aux.Precio = datos.Lector.GetDecimal(5);
                    aux.Stock = datos.Lector.GetInt64(6);
                    if (!Convert.IsDBNull(datos.Lector["idCategoria"]))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.ID = (int)datos.Lector["idCategoria"];
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];

                    }



                    lista.Add(aux);

                }

                return lista;
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

    }
}
