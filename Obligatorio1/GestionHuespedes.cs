using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionHuespedes
    {
        //Precarga de huespedes
        public static List<Huesped> CargaHuespedes()
        {
            Huesped huesped1 = new Huesped("Jose", "Garcia", "24/10/1998", "Uruguay", "Cédula", 55555555, 098111111, "garciajose@gmail.com");
            Huesped huesped2 = new Huesped("Jose", "Martinez", "27/04/1987", "Mexico", "Pasaporte", 333333, 987333222, "josemartinez@gmail.com");
            Huesped huesped3 = new Huesped("Maria", "Jimenez Arboleda", "03/11/2001", "Uruguay", "Cédula", 66666666, 093222222, "mariajiar@gmail.com");
            List<Huesped> huespedes = new List<Huesped> { huesped1, huesped2, huesped3 };

            return huespedes;
        }

        //Precarga de usuarios usando la lista de huespedes
        public static List<Usuario> CargaUsuarios(List<Huesped> lista)
        {
            List<Usuario> usuarios = new List<Usuario>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == 0) {
                    Usuario newUsuario = new Usuario(lista[i], lista[i].Nombre, lista[i].CorreoElec, "199824Gar");
                    usuarios.Add(newUsuario);
                } else if (i == 1)
                {
                    Usuario newUsuario = new Usuario(lista[i], lista[i].Nombre, lista[i].CorreoElec, "198727Mar");
                    usuarios.Add(newUsuario);
                } else
                {
                    Usuario newUsuario = new Usuario(lista[i], lista[i].Nombre, lista[i].CorreoElec, "200103JiAr");
                    usuarios.Add(newUsuario);
                }
            }

            return usuarios;
        }

        //Listado de Huespedes
        public static void ListaHuespedes(List<Usuario> users)
        {
            Console.Clear();
            bool salir = false;
            List<Usuario> sortedUsers = users.OrderBy(u => u.Nombre).ToList();

            do
            {
                Console.WriteLine("--- Lista de Huespedes ---");

                foreach ( Usuario user in sortedUsers )
                {
                    Console.WriteLine($"{user.Huesped.IdHuesped}. {user.Huesped}");
                }
                Console.WriteLine("--- Fin de la Lista ---");

                Console.WriteLine("\n Si quiere salir, presione '1'.");
                Console.WriteLine("Si quiere ver el historial de reservas de un huesped, presione '2'.");
                string? option = Console.ReadLine();

                if ( option == "1" )
                {
                    salir = true;
                } else if (option == "2")
                {
                    HistorialReservas(users);
                } else
                {
                    Console.WriteLine("La opción es invalida. Presione una tecla e intente nuevamente.");
                    Console.ReadKey();
                }

            } while (!salir);
        }

        public static void HistorialReservas(List<Usuario> users)
        {
            bool salir = false;

            do
            {
                Console.WriteLine("Ingrese el ID del huesped:");
                string? idHuesped = Console.ReadLine();
                int idHues = int.Parse(idHuesped);

                if (users.Any(u => u.Huesped.IdHuesped == idHues))
                {
                    Console.WriteLine("--- Reservas del huesped ---");
                    foreach (Usuario user in users)
                    {
                        if (user.Huesped.IdHuesped == idHues)
                        {
                            user.Reservas.ForEach(r => Console.WriteLine(r));
                        }
                    }
                    Console.WriteLine("--- Fin de la Lista ---");
                } else
                {
                    Console.WriteLine("El huesped que busca no existe en el sistema.");
                }

                
                Console.WriteLine("\n Si quiere volver a buscar, presione '1'.");
                Console.WriteLine("Si quiere salir, presione '2'.");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción es invalida. Presione una tecla para intentar nuevamente.");
                        Console.ReadKey();
                        break;
                }

            } while (!salir);
        }

        //Ingreso de datos para el registro de nuevos usuarios
        public static void IngresarDatos(List<Huesped> list, List<Usuario> users)
        {
            //Variables para los datos
            string? nombre;
            string? apellidos;
            string? fechaNacimientoS;
            string? paisOrigen;
            string? tipoDoc;
            string? numDocS;
            string? telefonoS;
            int telefono = 0;
            int numDoc;
            string? correoElec;
            string? contrasenia;

            //Chequeo de los datos ingresados para el huesped
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

                if (!int.TryParse(numDocS, out numDoc) && !int.TryParse(telefonoS, out telefono))
                {
                    Console.WriteLine("El numero de su documento o el telefono no pueden tener carácteres alfabeticos");
                }
            } while (!int.TryParse(numDocS, out numDoc) && !int.TryParse(telefonoS, out telefono));

            //Chequeo de datos para el usuario
            do
            {
                Console.WriteLine("Ingrese el correo para su usuario. Su nombre se autocompletara.");
                correoElec = Console.ReadLine();
                Console.WriteLine("Inggrese la contraseña.");
                contrasenia = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(contrasenia) && String.IsNullOrWhiteSpace(correoElec))
                {
                    Console.WriteLine("La contraseña no puede ser un campo nulo o un espacio en blanco.");
                }
                else if (contrasenia.Length < 8)
                {
                    Console.WriteLine("La contraseña debe tener 8 caracteres cómo minimo");
                }
            } while (String.IsNullOrWhiteSpace(contrasenia) && contrasenia.Length < 8);

            //Creacion de objetos y adicion a las listas correspondientes
            Huesped newHuesped = new Huesped(nombre, apellidos, fechaNacimientoS, paisOrigen, tipoDoc, numDoc, telefono, correoElec);
            Usuario newUsuario = new Usuario(newHuesped, nombre, correoElec, contrasenia);
            list.Add(newHuesped);
            users.Add(newUsuario);
            
        }
    }
}
