using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Huesped
    {
        private int ID = 1;

        public int IdHuesped {  get; private set; }
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? TipoDocumento {  get; set; }
        public int NumDocumento { get; set; }
        public string? FechaNacimiento { get; set; }
        public int Telefono {  get; set; }
        public string? CorreoElec { get; set; }
        public string? PaisOrigen {  get; set; }

        public Huesped() { }

    }
}
