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

                //datos.SetearQuery(" Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, C.ID AS idCategoria, C.Nombre AS Categoria" +
                //                    "From Producto AS P" +
                //                    "Left Join Categoria AS C ON P.ID_Categoria = C.ID" +
                //                    "Left Join Usuario_x_Producto AS UxP ON P.ID = UxP.IDProducto" +
                //                    "Left Join Usuario AS U ON UxP.IDUsuario = U.ID_Usuario" +
                //                    "Left Join TipoUsuario AS TU ON U.ID_TipoUsuario = TU.ID");

                //datos.SetearQuery("Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, C.ID AS idCategoria, C.Nombre AS Categoria" +
                //                    "From Producto AS P" +
                //                    "Left Join Categoria AS C ON P.ID_Categoria = C.ID");
                datos.SetearQuery("Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, C.ID AS idCategoria, C.Nombre AS Categoria , C.Estado From Productos AS P Left Join Categorias AS C ON P.IdCategoria = C.ID");
                datos.EjecutarLector();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.ImagenURL = datos.Lector.GetString(4);
                    aux.Precio = datos.Lector.GetDecimal(5);

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
