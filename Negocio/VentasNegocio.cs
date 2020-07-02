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
        public void Agregar(Dominio.Carrito nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spAltaVenta";
                comando.Parameters.AddWithValue("@ID_Usuario", nuevo.ID_Usuario);
                comando.Parameters.AddWithValue("@PrecioTotal", nuevo.Total);
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

        public void AgregarItem(ItemCarrito nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spAltaProducto_X_Venta";
                comando.Parameters.AddWithValue("@ID_Producto", nuevo.Producto.ID);
                comando.Parameters.AddWithValue("@ID_Venta", nuevo.ID);
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
