using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Habitacion
    {
        public int NumHabitacion { get; set; }
        public string? TipoHabitacion { get; set; }
        public int CantidadPersonas { get; set; }
        public int Tarifa { get; private set; }
    }
}
