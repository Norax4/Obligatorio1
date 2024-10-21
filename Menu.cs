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
        internal static void InicioSesion(Dictionary<string, Usuario> dictionary)
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


                if (!String.IsNullOrWhiteSpace(correo) && !String.IsNullOrWhiteSpace(contrasenia))
                {
                    foreach (Usuario user in dictionary.Values)
                    {
                        if (correo == user.CorreoElec && contrasenia == user.Contrasenia)
                        {
                            MenuPrincipal();
                        }
                    }
                } else
                {
                    Console.WriteLine("El correo o contraseña no pueden ser valores nulos o espacios vacios. Para intentar nuevamente presione '1'. Para recuperar su contraseña, presione '2'.");
                    //recuperacion de contraseña
                }

            } while (String.IsNullOrWhiteSpace(correo) || String.IsNullOrWhiteSpace(contrasenia));
        }

        internal static void Registro(List<Huesped> lista, Dictionary<string, Usuario> dict)
        {
            Console.Clear();
            Console.WriteLine("Escriba sus datos para llevar a cabo el registro:");

            string? nombre;
            string? apellidos;
            string? fechaNacimientoS;
            string? paisOrigen;
            string? tipoDoc;
            string? numDocS;
            string? telefonoS;
            int numDoc;
            int telefono;

            do
            {
                do
                {
                    Console.WriteLine("Ingrese su nombre:");
                    nombre = Console.ReadLine();

                    Console.WriteLine("\n Ingrese sus apellidos:");
                    apellidos = Console.ReadLine();

                    Console.WriteLine("\n Ingrese su fecha de nacimiento (dia/mes/año):");
                    fechaNacimientoS = Console.ReadLine();

                    Console.WriteLine("\n Ingrese su pais de origen:");
                    paisOrigen = Console.ReadLine();

                    Console.WriteLine("\n Ingrese su tipo de documento:");
                    tipoDoc = Console.ReadLine();

                    Console.WriteLine("\n Ingrese el numero de su documento:");
                    numDocS = Console.ReadLine();

                    Console.WriteLine("\n Ingrese su telefono:");
                    telefonoS = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(apellidos) && String.IsNullOrWhiteSpace(fechaNacimientoS) && String.IsNullOrWhiteSpace(paisOrigen) && String.IsNullOrWhiteSpace(tipoDoc) && String.IsNullOrWhiteSpace(numDocS) && String.IsNullOrWhiteSpace(telefonoS))
                    {
                        Console.WriteLine("No puede ingresar espacios en blanco o valores nulos. Intente nuevamente.");
                    }
                    
                } while (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(apellidos) && String.IsNullOrWhiteSpace(fechaNacimientoS) && String.IsNullOrWhiteSpace(paisOrigen) && String.IsNullOrWhiteSpace(tipoDoc) && String.IsNullOrWhiteSpace(numDocS) && String.IsNullOrWhiteSpace(telefonoS));
                
                if (int.TryParse(numDocS, out numDoc) && int.TryParse(telefonoS, out telefono))
                {

                }
            } while (!int.TryParse(numDocS, out numDoc) && !int.TryParse(telefonoS, out telefono));
            

        }

        internal static void MenuPrincipal()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Bienvenido. \n");
                Console.WriteLine("Menú Principal \n");
                Console.WriteLine("1. Lista de Habitaciones");
                Console.WriteLine("2. Reservar una habitación");
                Console.WriteLine("3. Ver reservas en su perfil");
                Console.WriteLine("4. Salir \n");
                Console.WriteLine("Ingrese la opción deseada:");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Habitacion.ListarHabitaciones();
                        break;
                    case "2":
                        Reserva.ReservarHabitacion();
                        break;
                    case "3":
                        Reserva.ReservasPerfil();
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
