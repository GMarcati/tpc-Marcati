using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : Persona
    {
        public Int64 ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }       
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Boolean Estado { get; set; }

    }
}
