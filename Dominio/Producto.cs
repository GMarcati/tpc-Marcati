using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public Int64 ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public decimal Precio { get; set; }
        public Int64 Stock { get; set; }
        public Categoria Categoria { get; set; }

        public Boolean Estado { get; set; }

    }
}
