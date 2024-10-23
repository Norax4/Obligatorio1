using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionHuespedes
    {

        public static List<Huesped> CargaHuespedes()
        {
            Huesped huesped1 = new Huesped("Jose", "Garcia", "24/10/1998", "Uruguay", "Cédula", 55555555, 098111111, "garciajose@gmail.com");
            Huesped huesped2 = new Huesped("Jose", "Martinez", "27/04/1987", "Mexico", "Pasaporte", 333333, 987333222, "josemartinez@gmail.com");
            Huesped huesped3 = new Huesped("Maria", "Jimenez Arboleda", "03/11/2001", "Uruguay", "Cédula", 66666666, 093222222, "mariajiar@gmail.com");
            List<Huesped> huespedes = new List<Huesped> { huesped1, huesped2, huesped3 };

            return huespedes;
        }

        public static Dictionary<int, Usuario> CargaUsuarios(List<Huesped> lista)
        {
            Dictionary<int, Usuario> dict = new Dictionary<int, Usuario>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (i == 0) {
                    Usuario newUsuario = new Usuario(lista[i].Nombre, lista[i].CorreoElec, "199824Gar");
                    dict.Add(lista[i].IdHuesped, newUsuario);
                } else if (i == 1)
                {
                    Usuario newUsuario = new Usuario(lista[i].Nombre, lista[i].CorreoElec, "198727Mar");
                    dict.Add(lista[i].IdHuesped, newUsuario);
                } else
                {
                    Usuario newUsuario = new Usuario(lista[i].Nombre, lista[i].CorreoElec, "200103JiAr");
                    dict.Add(lista[i].IdHuesped, newUsuario);
                }
            }

            return dict;
        }

        public static void IngresarDatos(List<Huesped> list, Dictionary<int, Usuario> dict)
        {
            string? nombre;
            string? apellidos;
            string? fechaNacimientoS;
            string? paisOrigen;
            string? tipoDoc;
            string? numDocS;
            string? telefonoS;
            int telefono;
            int numDoc;
            string? correoElec;
            string? contrasenia;

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

            Huesped newHuesped = new Huesped(nombre, apellidos, fechaNacimientoS, paisOrigen, tipoDoc, numDoc, telefono, correoElec);
            Usuario newUsuario = new Usuario(nombre, correoElec, contrasenia);
            list.Add(newHuesped);
            dict.Add(newHuesped.IdHuesped, newUsuario);
            
        }
    }
}
