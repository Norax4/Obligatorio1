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
        public int IdHuesped { get; private set; }
        public int NumHabitacion { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFinal { get; set; }
        public string? FechaReserva { get; set; }

        public Reserva(int idHuesped, int numHabitacion, string fechaInicio, string fechaFinal, string fechaReserva)
        {
            IdReserva = AutoID++;
            IdHuesped = idHuesped;
            NumHabitacion = numHabitacion;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            FechaReserva = fechaReserva;
        }

        internal static void ReservarHabitacion()
        {

        }

        internal static void ReservasPerfil()
        {

        }
    }
}
