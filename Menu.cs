﻿using Obligatorio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Menu
    {
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


                if (!String.IsNullOrWhiteSpace(correo) && !String.IsNullOrWhiteSpace(contrasenia))
                {
                    foreach (Usuario user in users)
                    {
                        if (correo == user.CorreoElec && contrasenia == user.Contrasenia)
                        {
                            MenuPrincipal(user, lista);
                        }
                    }
                } else
                {
                    Console.WriteLine("El correo o contraseña no pueden ser valores nulos o espacios vacios. Para intentar nuevamente presione '1'. Para recuperar su contraseña, presione '2'.");
                    string? obtain = Console.ReadLine();
                    if (obtain == "2")
                    {
                        Console.WriteLine("--- Recuperacion de contraseña ---");
                        Console.WriteLine("\n Ingrese su Correo Electronico:");
                        string? correoRec = Console.ReadLine();

                        Console.WriteLine("Se enviará un correo para la recuperación de su contraseña.");
                        //File.CreateText(@"");
                    }
                }

            } while (String.IsNullOrWhiteSpace(correo) || String.IsNullOrWhiteSpace(contrasenia));
        }

        internal static void Registro(List<Huesped> lista, List<Usuario> users)
        {
            Console.Clear();
            Console.WriteLine("Escriba sus datos para llevar a cabo el registro:");

            GestionHuespedes.IngresarDatos(lista, users);

            Console.WriteLine("Registro completado. Inicie sesión en el sistema.");
        }

        internal static void MenuPrincipal(Usuario user, List<Habitacion> lista)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine($"--- Bienvenido/a, {user} ---\n");
                Console.WriteLine("--- Menú Principal ---\n");
                Console.WriteLine("1. Lista de Habitaciones");
                Console.WriteLine("2. Reservar una habitación");
                Console.WriteLine("3. Ver reservas en su perfil");
                Console.WriteLine("4. Salir");
                Console.WriteLine("--- Fin de la lista --- \n");
                Console.WriteLine("Ingrese la opción deseada:");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        GestionHabitaciones.ListarHabitaciones(user, lista);
                        break;
                    case "2":
                        GestionReservas.ReservarHabitacion(user, lista);
                        break;
                    case "3":
                        GestionReservas.ReservasPerfil(user);
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