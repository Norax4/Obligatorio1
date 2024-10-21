using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Persona
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? PaisOrigen { get; set; }

        public Persona(string nombre, string apellidos, string fechaNacimiento, string paisOrigen)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            PaisOrigen = paisOrigen;
        }
    }
}
