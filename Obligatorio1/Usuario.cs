using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Usuario : Huesped
    {
        static int IdHuesped;
        public string? CorreoElec {  get; set; }
        public string? Contraseña { get; set; }
        public int Tarifa { get; set; }
    }
}
