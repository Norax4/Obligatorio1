using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Reserva : Usuario, Habitacion
    {
        private int AutoID = 1001;

        public int IdReserva { get; private set; }
        public int IdHuesped { get; set; }
        public int NumHabitacion { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFinal { get; set; }
        public string? FechaReserva { get; set; }
    }
}
