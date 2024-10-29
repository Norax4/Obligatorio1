using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionHabitaciones
    {
        //Precarga de Habitaciones con su numero, tipo y tarifa
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

        //Listado de habitaciones segun datos ingresados por el usuario
        public static void ListarHabitaciones(Usuario user, List<Habitacion> lista)
        {
            bool salir = false;

            do
            {
                //Ingreso de datos para la busqueda
                Console.WriteLine("--- Ingrese los siguientes datos para encontrar la habitación perfecta para su estancia ---");
                Console.WriteLine("Ingrese una fecha:");
                string? fechaS = Console.ReadLine();
                DateTime fecha = DateTime.Parse(fechaS);

                Console.WriteLine("\n Ingrese el tipo (Simple, Doble, Suite):");
                string? tipo = Console.ReadLine();

                Console.WriteLine("\n Ingrese la cantidad de personas:");
                string? capacidadS = Console.ReadLine();
                int capacidad;
                if (String.IsNullOrWhiteSpace(capacidadS))
                {
                    capacidad = 0;
                } else
                {
                    capacidad = int.Parse(capacidadS);
                }

                //Busqueda de habitaciones segun fecha, tipo y capacidad
                foreach (var habitacion in lista)
                {
                    if (!habitacion.FechasReservadas.ContainsKey(fecha) && habitacion.TipoHabitacion == tipo && habitacion.CantidadPersonas == capacidad)
                    {
                        Console.WriteLine(habitacion);
                    }
                }
                //Funciones
                Console.WriteLine("--- Final de la lista ---");
                Console.WriteLine("\n Si desea volver a buscar, ingrese '1'.");
                Console.WriteLine("Si desea reservar una habitación, ingrese '2'.");
                Console.WriteLine("Si desea volver al menu principal, ingrese '3'.");
                string? obtain = Console.ReadLine();

                if (obtain == "2")
                {
                    GestionReservas.ReservarHabitacion(user, lista);
                } else if (obtain == "3")
                {
                    salir = true;
                }
                
            } while (!salir);
        }

        //Listado de habitaciones libres para las estadisticas
        public static void ListarHabitaciones(List<Habitacion> lista)
        {
            bool salir = false;

            do
            {
                Console.WriteLine("--- Habitaciones Libres ---");

                foreach (var habitacion in lista)
                {
                    if (!habitacion.Estado)
                    {
                        Console.WriteLine(habitacion);
                    }
                }
                Console.WriteLine("--- Fin de la Lista ---");
                Console.WriteLine("Si desea salir, presione '1'.");
                string? obtain = Console.ReadLine();

                if (obtain == "1")
                {
                    salir = true;
                }
            } while (!salir);
        }

        //Listado de habitaciones de más a menos reservadas
        public static void HabitacionesReservas(List<Habitacion> habitaciones)
        {
            bool salir = false;
            Console.Clear();
            //List<Habitacion> sortedHabs = habitaciones.OrderBy(h => h.countReservas);
            do
            {
                Console.WriteLine("--- Cantidad de reservas por habitacion ---");

                Console.WriteLine("--- Fin de la Lista ---");
                Console.WriteLine("\n Si quiere salir, presione '1'.");
                string? option = Console.ReadLine();

                if (option == "1")
                {
                    salir= true;
                } else
                {
                    Console.WriteLine("La opción es invalida. Presione una tecla para intentar nuevamente.");
                    Console.ReadKey();
                }
            } while (!salir);
        }
    }
}
