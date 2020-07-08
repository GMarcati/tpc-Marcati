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
                comando.CommandText = "Select ID,ID_Usuario,PrecioTotal,Fecha From Ventas Where Estado = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Venta aux = new Venta();
                    aux.ID = lector.GetInt64(0);
                    aux.ID_Usuario = lector.GetInt64(1);
                    aux.PrecioTotal = lector.GetDecimal(2);
                    aux.Fecha = lector.GetDateTime(3);


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
                comando.Parameters.AddWithValue("@ID_Usuario", nuevo.ID_Usuario);
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
                comando.Parameters.AddWithValue("@ID_Producto", nuevo.ID_Producto);
                comando.Parameters.AddWithValue("@ID_Venta", nuevo.ID_Venta);
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


    }
}
