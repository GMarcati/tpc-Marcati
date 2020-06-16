using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : Persona
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Constraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public int Estado { get; set; }

    }
}
