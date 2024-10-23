using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionHabitaciones
    {
        public static List<Habitacion> CargaHabitaciones()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();

            for (int i = 1; i <= 10; i++)
            {
                string tipo = "Simple";
                habitaciones.Add(new Habitacion(i + 100, tipo, 2));
            }

            for (int i = 1; i <= 5; i++)
            {
                string tipo = "Doble";
                habitaciones.Add(new Habitacion(i + 200, tipo, 4));
            }

            for (int i = 1; i <= 5; i++)
            {
                string tipo = "Suite";
                habitaciones.Add(new Habitacion(i + 300, tipo, 4));
            }

            return habitaciones;
        }

        public static void ListarHabitaciones(List<Habitacion> lista)
        {
            bool salir = false;

            do
            {
                Console.WriteLine("--- Ingrese los siguientes datos para encontrar la habitación perfecta para su estancia ---");
                Console.WriteLine("Ingrese una fecha:");


                foreach (var habitacion in lista)
                {
                    Console.WriteLine(habitacion);
                }

                
            } while (!salir);


        }
    }
}
