using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class AccesoDatos
    {


        public SqlDataReader Lector { get; set; }
        public SqlConnection Conexion { get; }
        public SqlCommand Comando { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source=DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetearQuery(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }

        public void SetearSP(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;

        }
        public void AgregarParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);

        }

        public void EjecutarLector()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void CerrarConexion()
        {
            Conexion.Close();
        }

        internal void EjecturAccion()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }

    }
}
