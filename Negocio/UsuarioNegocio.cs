using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("spListaUsuario");
                datos.EjecutarLector();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID_Usuario = datos.Lector.GetInt64(0);
                    aux.Nombre_Usuario = datos.Lector.GetString(1);
                    aux.Email = datos.Lector.GetString(2);
                    aux.Contraseña = datos.Lector.GetString(3);
                    aux.Nombre = datos.Lector.GetString(4);
                    aux.Apellido = datos.Lector.GetString(5);
                    aux.DNI = datos.Lector.GetInt64(6);
                    if (!Convert.IsDBNull(datos.Lector["idTipoUsuario"]))
                    {
                        aux.TipoUsuario = new TipoUsuario();
                        aux.TipoUsuario.ID = (int)datos.Lector["idTipoUsuario"];
                        aux.TipoUsuario.Nombre = (string)datos.Lector["TipoUsuario"];

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

        public void Agregar(Usuario nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=MARCATI_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "spRegistroUsuario";
                comando.Parameters.AddWithValue("@NombreUsuario", nuevo.Nombre_Usuario);
                comando.Parameters.AddWithValue("@Email", nuevo.Email);
                comando.Parameters.AddWithValue("@Contraseña", nuevo.Contraseña);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Apellido", nuevo.Apellido);
                comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                comando.Parameters.AddWithValue("@Domicilio", nuevo.Domicilio);

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

        public Usuario login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("Select IdUsuario from Usuarios Where NombreUsuario = @Usuario AND Contraseña = @Pass");
                datos.AgregarParametro("@Usuario", usuario.Nombre_Usuario);
                datos.AgregarParametro("@Pass", usuario.Contraseña);

                datos.EjecutarLector();
                if (datos.Lector.Read())
                    usuario.ID_Usuario = (Int64)datos.Lector["ID_Usuario"];

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
