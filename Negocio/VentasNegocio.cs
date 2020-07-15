using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class VentasNegocio
    {

        public List<Venta> Listar()
        {
            List<Venta> listado = new List<Venta>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select V.ID,V.ID_Usuario as idUsuario, U.NombreUsuario as Usuario, U.Domicilio,  V.PrecioTotal,V.Fecha From Ventas AS V Left Join Usuarios AS U ON V.ID_Usuario = U.IdUsuario Where V.Estado = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Venta aux = new Venta();
                    aux.ID = lector.GetInt64(0);

                    //aux.usuario.ID_Usuario = lector.GetInt64(1);
                    if (!Convert.IsDBNull(lector["idUsuario"]))
                    {
                        aux.usuario = new Usuario();
                        aux.usuario.ID_Usuario = (Int64)lector["idUsuario"];
                        aux.usuario.Nombre_Usuario = (string)lector["Usuario"];

                    }
                    aux.PrecioTotal = lector.GetDecimal(4);
                    aux.Fecha = lector.GetDateTime(5);


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
        public void Agregar(Venta nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spAltaVenta";
                comando.Parameters.AddWithValue("@ID_Usuario", nuevo.usuario.ID_Usuario);
                //comando.Parameters.AddWithValue("@PrecioTotal", nuevo.Total);
                comando.Parameters.AddWithValue("@PrecioTotal", nuevo.PrecioTotal);
                comando.Parameters.AddWithValue("@Fecha", nuevo.Fecha);


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

        public void AgregarItem(Producto_X_Venta nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spAltaProducto_X_Venta";
                comando.Parameters.AddWithValue("@ID_Producto", nuevo.producto.ID);
                comando.Parameters.AddWithValue("@ID_Venta", nuevo.venta.ID);
                comando.Parameters.AddWithValue("@Cantidad", nuevo.Cantidad);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);


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


        public List<Venta> ListarConNombre()
        {
            List<Venta> listado = new List<Venta>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select V.ID,V.ID_Usuario as idUsuario, U.NombreUsuario as Usuario, U.Domicilio,  V.PrecioTotal,V.Fecha From Ventas AS V Left Join Usuarios AS U ON V.ID_Usuario = U.IdUsuario Where V.Estado = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Venta aux = new Venta();
                    aux.ID = lector.GetInt64(0);
                    aux.usuario.ID_Usuario = lector.GetInt64(1);
                    aux.PrecioTotal = lector.GetDecimal(2);
                    aux.Fecha = lector.GetDateTime(3);
                    //if (!Convert.IsDBNull(datos.Lector["idUsuario"]))
                    //{
                    //    aux.ID_Usuario = new Categoria();
                    //    aux.Categoria.ID = (int)datos.Lector["idUsuario"];
                    //    aux.Categoria.Nombre = (string)datos.Lector["Usuario"];

                    //}

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

        public List<Producto_X_Venta> ListarProductoVenta()
        {
            List<Producto_X_Venta> listado = new List<Producto_X_Venta>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select PXV.ID_Venta as idVenta,PXV.ID_Producto as idProducto, P.Nombre as Producto, PXV.Cantidad From Producto_X_Venta AS PXV Inner Join Productos AS P ON P.ID = PXV.ID_Producto";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {


                    Producto_X_Venta aux = new Producto_X_Venta();
                    if (!Convert.IsDBNull(lector["idVenta"]))
                    {
                        aux.venta = new Venta();
                        aux.venta.ID= (Int64)lector["idVenta"];

                    }

                    if (!Convert.IsDBNull(lector["idProducto"]))
                    {
                        aux.producto = new Producto();
                        aux.producto.ID = (Int64)lector["idProducto"];
                        aux.producto.Nombre = (string)lector["Producto"];
                    }

                    aux.Cantidad = lector.GetInt64(3);

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE Ventas set Estado = 0 where ID=" + id);
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
