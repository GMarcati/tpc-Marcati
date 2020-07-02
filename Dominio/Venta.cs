using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
            public int ID { get; set; }
            public Usuario ID_Usuario { get; set; }
            
            public decimal PrecioTotal { get; set; }
            
            public DateTime Fecha { get; set; }
            
    }
}
