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
        public bool Estado { get; set; }
        public int countReservas = 0;

        public Habitacion(int numHabitacion, string tipoHabitacion, int cantidadPersonas)
        {
            NumHabitacion = numHabitacion;
            TipoHabitacion = tipoHabitacion;
            CantidadPersonas = cantidadPersonas;
            if (TipoHabitacion == "Simple")
            {
                Tarifa = 100;
            } else if (TipoHabitacion == "Doble")
            {
                Tarifa = 150;
            } else
            {
                Tarifa = 200;
            }
            Estado = false;
        }

        internal static void ListarHabitaciones()
        {

        }
    }
}
