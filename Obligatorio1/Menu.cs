using Obligatorio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Menu
    {
        //Metodo para el inicio de sesión, antes de entrar al menu principal
        internal static void InicioSesion(List<Usuario> users, List<Habitacion> lista)
        {
            Console.Clear();
            Console.WriteLine("Inicio de sesion");

            string? correo;
            string? contrasenia;
            do
            {
                Console.WriteLine("Ingrese su correo electronico:");
                correo = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña:");
                contrasenia = Console.ReadLine();

                //Control para asegurar que el correo y contraseña contienen información
                if (!String.IsNullOrWhiteSpace(correo) && !String.IsNullOrWhiteSpace(contrasenia))
                {
                    
                        foreach (Usuario user in users)
                        {
                            //Si el usuario existe en la lista de usuarios, entra al menu principal.
                            if (correo == user.CorreoElec && contrasenia == user.Contrasenia)
                            {
                                MenuPrincipal(user, lista);
                            }
                        }
                        if (!users.Any(u => u.CorreoElec == correo)){
                            Console.WriteLine("Este correo no esta registrado en el sistema.");
                        } else if (!users.Any(u => u.Contrasenia == contrasenia))
                        {
                            Console.WriteLine("La contraseña ingresada es incorrecta.");
                        }
                } else 
                { 
                    Console.WriteLine("El correo o contraseña no pueden ser valores nulos o espacios vacios.");
                    Console.WriteLine("Si no tiene un usuario en el sistema, por favor registrese.");
                    Console.WriteLine("Presione una tecla para intentar nuevamente.");
                    Console.ReadKey();
                }

            } while (String.IsNullOrWhiteSpace(correo) || String.IsNullOrWhiteSpace(contrasenia));
        }

        //Metodo de registro del nuevo usuario
        internal static void Registro(List<Huesped> lista, List<Usuario> users)
        {
            Console.Clear();
            Console.WriteLine("Escriba sus datos para llevar a cabo el registro:");

            GestionHuespedes.IngresarDatos(lista, users);

        }

        //Menú de las estadisticas del hotel
        internal static void Estadisticas(List<Usuario> users, List<Habitacion> habitaciones)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- Estadisticas del sistema ---");

                Console.WriteLine("1. Listado de Huespedes.");
                Console.WriteLine("2. Habitaciones libres.");
                Console.WriteLine("3. Reservas por habitacion.");
                Console.WriteLine("4. Salir.\n");
                Console.WriteLine("Ingrese la opción deseada:");
                string? option = Console.ReadLine();

                //Switch para las opciones, enlazadas con metodos
                switch (option)
                {
                    case "1":
                        GestionHuespedes.ListarHuespedes(users);
                        break;
                    case "2":
                        GestionHabitaciones.ListarHabitaciones(habitaciones);
                        break;
                    case "3":
                        GestionHabitaciones.HabitacionesReservas(habitaciones);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción es invalida. Presione una tecla e intente nuevamente.");
                        Console.ReadKey();
                        break;

                }
            }
        }

        //Menu principal del sistema
        internal static void MenuPrincipal(Usuario user, List<Habitacion> lista)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine($"--- Bienvenido/a, {user} ---\n");
                Console.WriteLine("--- Menú Principal ---\n");
                Console.WriteLine("1. Lista de Habitaciones");
                Console.WriteLine("2. Reservar una habitación");
                Console.WriteLine("3. Ver reservas en su perfil");
                Console.WriteLine("4. Salir");
                Console.WriteLine("--- Fin de la lista --- \n");
                Console.WriteLine("Ingrese la opción deseada:");
                string? option = Console.ReadLine();

                //Switch para las opciones, relacionadas con metodos
                switch (option)
                {
                    case "1":
                        GestionHabitaciones.ListarHabitaciones(user, lista);
                        break;
                    case "2":
                        GestionReservas.ReservarHabitacion(user, lista);
                        break;
                    case "3":
                        GestionReservas.ReservasPerfil(user, lista);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción es invalida. Presione una tecla e intente nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}
