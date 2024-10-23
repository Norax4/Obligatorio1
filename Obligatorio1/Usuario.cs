using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Usuario
    {
        private int ID = 1001;

        public int IdUsuario { get; private set; }
        public string? Nombre { get; set; }
        public string? CorreoElec { get; set; }
        public string? Contrasenia { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Usuario(string nombre, string correoElec, string contrasenia)
        {
            IdUsuario = ID++;
            Nombre = nombre;
            CorreoElec = correoElec;
            Contrasenia = contrasenia;
            Reservas = new List<Reserva>();
        }
    }
}
