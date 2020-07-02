using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public Int64 ID { get; set; }

        public Int64 ID_Usuario { get; set; }

        public List<ItemCarrito> listaItem { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }

        public Carrito()
        {
            listaItem = new List<ItemCarrito>();
        }

        public decimal SubTotal()
        {
            decimal subtotal = 0;

            foreach (var item in listaItem)
            {
                subtotal += item.PrecioItem();
            }
            Total = subtotal;
            return subtotal;
        }
    }
}
