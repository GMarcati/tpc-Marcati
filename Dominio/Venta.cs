using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
            public Int64 ID { get; set; }
            public Int64 ID_Usuario { get; set; }
            
            public decimal PrecioTotal { get; set; }
            
            public DateTime Fecha { get; set; }
            
    }
}
