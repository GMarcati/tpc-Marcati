using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class TipoUsuarioNegocio
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
                comando.CommandText = "Select ID, Nombre from TipoUsuario";
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

    }
}
