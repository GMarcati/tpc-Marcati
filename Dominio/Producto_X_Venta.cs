using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto_X_Venta
    {
        public Producto producto { get; set; }

        public Venta venta { get; set; }

        public Int64 Cantidad { get; set; }

        public decimal Precio { get; set; }


    }
}
