using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionReservas
    {
        //Precarga de Reservas
        public static List<Reserva> CargaReservas(List<Habitacion> habitaciones, List<Usuario> usuarios)
        {
            foreach (var user in usuarios)
            {

            }

            List<Reserva> reservas = new List<Reserva>();

            return reservas;
        }

        public static void ReservarHabitacion(Usuario user, List<Habitacion> lista)
        {
            //Obteniendo datos del usuario
            Console.WriteLine("--- Reserva ---");
            Console.WriteLine("\n Ingrese el número de la habitación que desea reservar:");
            string? numHabS = Console.ReadLine();

            Console.WriteLine("\n Ingrese la fecha en la que llegara al hotel:");
            string? fechaI = Console.ReadLine();

            Console.WriteLine("\n Ingrese la fecha en la que se irá del hotel:");
            string? fechaS = Console.ReadLine();

            int numHab = int.Parse(numHabS);
            DateTime fechaInicio = DateTime.Parse(fechaI);
            DateTime fechaSalida = DateTime.Parse(fechaS);
            //Comprobaciones para crear la reserva
            foreach (var hab in lista)
            {
                //Si la habitacion existe/esta en la lista de habitaciones
                if (hab.NumHabitacion == numHab)
                {
                    //Si la habitacion elegida ya tiene una reserva en la misma fecha
                    if (hab.FechasReservadas.ContainsKey(fechaInicio))
                    {
                        Console.WriteLine("Lo sentimos. La habitación ya fue reservada para esta fecha. ");
                    }
                    /*Si la reserva es de más de 30 dias, revisar
                    else if (fechaInicio.AddDays(30.00) > fechaSalida)
                    { 
                        Console.WriteLine("Lo sentimos. No puede hacer reservas de un lapso de tiempo mayor a 30 dias.");
                    }*/ else 
                    {
                        string? response;
                        do
                        {
                            Reserva newReserva = new Reserva(user.Huesped, hab, fechaInicio, fechaSalida);
                            TimeSpan diasEstadia = fechaSalida - fechaInicio;
                            int dias = diasEstadia.Days;
                            Pago pagoRes = new Pago(newReserva, fechaInicio, hab.Tarifa * dias, "none");
                            newReserva.pagoReserva = pagoRes;
                            user.Reservas.Add(newReserva);
                            hab.FechasReservadas.Add(fechaInicio, fechaSalida);
                            hab.countReservas += 1;

                            //Pago de la reserva
                            Console.WriteLine("¿Desea realizar el pago de manera inmediata? Si no, se realizará cuando llegue al hotel:");
                            response = Console.ReadLine();

                            if (response.ToLower() == "si")
                            {
                                Console.WriteLine("Ingrese el numero de su tarjeta:");
                                Console.ReadLine();

                                //Comprobante de pago

                                pagoRes.FechaPago = DateTime.Now;
                                pagoRes.MetodoPago = "Tarjeta";
                                newReserva.Pagada = true;

                                Console.WriteLine("Pago realizado.");
                                Console.WriteLine("Su reserva se ha registrado con exito.");
                            }
                            else if (response.ToLower() == "no")
                            {
                                pagoRes.MetodoPago = "Durante Check-In";
                                Console.WriteLine("El pago se realizará en la llegada al hotel.");
                                Console.WriteLine("Su reserva se ha registrado con exito.");
                            }
                            else
                            {
                                Console.WriteLine("Por favor, responda 'si' o 'no' a la pregunta.");
                            }
                        } while (response.ToLower() != "si" || response.ToLower() != "no");
                    }
                }
            }
        }

        public static void ModificarReserva(Usuario user)
        {
            Console.WriteLine("Ingrese el numero de la reserva que quiere modificar:");
            string? numResString = Console.ReadLine();
            int numRes = int.Parse(numResString);

        }

        public static void CancelarReserva(Usuario user)
        {
            Console.WriteLine("Ingrese el numero de la reserva que quiere cancelar:");
            string? numResString = Console.ReadLine();
            int numRes = int.Parse(numResString);

            //Obteniendo la reserva elegida
            foreach (var reserva in user.Reservas)
            {
                if (reserva.IdReserva == numRes)
                {
                    if (reserva.FechaInicio >= DateTime.Now)
                    {
                        Console.WriteLine("Lo sentimos. No puede cancelar la reserva debido a que ya transcurrio la fecha limite   .");
                    }
                    else
                    {
                        string? response;
                        do
                        {
                            //Cancelando la reserva
                            Console.WriteLine("¿Esta seguro de cancelar esta reserva?");
                            response = Console.ReadLine();

                            if (response.ToLower() == "si")
                            {
                                user.Reservas.Remove(reserva);
                            } else if (response.ToLower() != "no" || response.ToLower() != "si")
                            {
                                Console.WriteLine("Por favor, responda 'si' o 'no' a la pregunta.");
                            }
                        } while (response.ToLower() != "no" || response.ToLower() != "si");                    }
                }
            }
        }

        public static void ReservasPerfil(Usuario user)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- Lista de reservas hechas en este Perfil ---");

                foreach (var res in user.Reservas)
                {
                    Console.WriteLine(res);
                }

                Console.WriteLine("Si desea modificar una reserva, presione '1'.");
                Console.WriteLine("Si desea cancelar una reserva, presione '2'.");
                Console.WriteLine("Si desea volver al menú principal, presione '3'.");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ModificarReserva(user);
                        break;
                    case "2":
                        CancelarReserva(user);
                        break;
                    case "3":
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
