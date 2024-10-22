using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Reserva
    {
        private int AutoID = 1001;

        public int IdReserva { get; private set; }
        public Huesped Huesped { get; set; }
        public Habitacion HabitacionElegida { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaReserva { get; private set; }

        public Reserva(Huesped huesped, Habitacion habitacion, DateTime fechaInicio, DateTime fechaFinal)
        {
            IdReserva = AutoID++;
            Huesped = huesped;
            HabitacionElegida = habitacion;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            FechaReserva = DateTime.Now;
        }

        internal static void ReservarHabitacion()
        {

        }

        internal static void ReservasPerfil()
        {

        }
    }
}
