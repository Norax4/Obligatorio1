using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Obligatorio1
{
    internal class GestionReservas
    {
        //Precarga de Reservas
        public static List<Reserva> CargaReservas(List<Habitacion> habitaciones, List<Usuario> usuarios)
        {
            DateTime fechaInicio = DateTime.Parse("27 / 12 / 2024");
            DateTime fechaFinal = DateTime.Parse("12/1/2025");
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (i == 0)
                { 
                    Reserva newReserva = new Reserva(usuarios[i].Huesped, habitaciones[2], fechaInicio, fechaFinal);
                    habitaciones[2].CountReservas += 1;
                    habitaciones[2].Estado = true;
                    usuarios[i].Reservas.Add(newReserva);
                } else if (i == 1)
                {
                    Reserva newReserva = new Reserva(usuarios[i].Huesped, habitaciones[4], fechaInicio, fechaFinal);
                    habitaciones[4].CountReservas += 1;
                    habitaciones[4].Estado = true;
                    usuarios[i].Reservas.Add(newReserva);
                } else
                {
                    Reserva newReserva = new Reserva(usuarios[i].Huesped, habitaciones[8], fechaInicio, fechaFinal);
                    habitaciones[8].CountReservas += 1;
                    habitaciones[8].Estado = true;
                    usuarios[i].Reservas.Add(newReserva);
                }
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
            double duracionReserva = (fechaSalida - fechaInicio).TotalDays;
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
                    //Si la fecha actual es mayor o igual a la ingresada para la llegada
                    else if (fechaInicio <= DateTime.Now)
                    {
                        Console.WriteLine("No puede reservar para el mismo día o ingresar una fecha pasada.");
                    } 
                    // Si la fecha actual es mayor o igual a la ingresada para la salida
                    else if (fechaSalida <= DateTime.Now)
                    {
                        Console.WriteLine("La fecha de salida no puede ser en el pasado.");
                    } 
                    //Si la fecha de llegada es mayor o igual a la fecha de salida
                    else if (fechaSalida <= fechaInicio)
                    {
                        Console.WriteLine("La fecha de salida no puede ser anterior a la fecha de llegada");
                    }
                    //Si la reserva dura más de 30 dias
                    else if (duracionReserva > 30)
                    {
                        Console.WriteLine("Lo sentimos. No puede hacer reservas de un lapso de tiempo mayor a 30 dias.");
                    }
                    else
                    {
                        //Si la reserva no existe en la lista, se ejecuta el tramite
                        foreach (Reserva reserva in user.Reservas) {

                            if (reserva.FechaInicio != fechaInicio || reserva.FechaFinal != fechaInicio)
                            {
                                Reserva newReserva = new Reserva(user.Huesped, hab, fechaInicio, fechaSalida);
                                string? response;
                                user.Reservas.Add(newReserva);
                                hab.FechasReservadas.Add(fechaInicio, fechaSalida);
                                hab.CountReservas += 1;
                                do
                                {
                                    //Pago de la reserva
                                    Console.WriteLine($"El pago es de: {hab.Tarifa * (int)duracionReserva}\n¿Desea realizar el pago de manera inmediata? Si no, se realizará cuando llegue al hotel:");
                                    response = Console.ReadLine();

                                    if (response.ToLower() == "si")
                                    {
                                        Console.WriteLine("Ingrese el numero de su tarjeta:");
                                        Console.ReadLine();

                                        //Comprobante de pago en consola
                                        Console.WriteLine("...");
                                        Console.ReadKey();
                                        Console.WriteLine("...");
                                        Console.ReadKey();
                                        Console.WriteLine("...");
                                        Console.ReadKey();

                                        Console.WriteLine("--- Comprobante de Pago de la Reserva ---");
                                        Console.WriteLine("Cliente:  " + user.Nombre + user.Huesped.Apellidos);
                                        Console.WriteLine("Fecha de Emisión:  " + DateTime.Now);
                                        Console.WriteLine("Monto del Pago:  $" + newReserva.PagoReserva.Monto);
                                        Console.WriteLine("Código de transacción:  1111");


                                        newReserva.PagoReserva.FechaPago = DateTime.Now;
                                        newReserva.PagoReserva.MetodoPago = "Tarjeta";
                                        newReserva.PagoReserva.RealizacionPago = true;

                                        Console.WriteLine("Pago realizado.");
                                        Console.WriteLine("Su reserva se ha registrado con exito.");
                                    }
                                    else if (response.ToLower() == "no")
                                    {
                                        newReserva.PagoReserva.MetodoPago = "Durante Check-In";
                                        Console.WriteLine("El pago se realizará en la llegada al hotel.");
                                        Console.WriteLine("Su reserva se ha registrado con exito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Por favor, responda 'si' o 'no' a la pregunta.");
                                    }
                                } while (response.ToLower() == "si" || response.ToLower() == "no");
                            }
                        }
                    }
                }
            }
        }

        public static void ModificarReserva(Usuario user, List<Habitacion> habitaciones)
        {
            Console.WriteLine("Ingrese el numero de la reserva que quiere modificar:");
            string? numResString = Console.ReadLine();
            int numRes = int.Parse(numResString);

            Console.WriteLine("Ingrese el número de habitacion en la que se quiere hospedar:");
            string? numHabString = Console.ReadLine();
            int numHab = int.Parse(numHabString);

            Console.WriteLine("Ingrese la fecha de llegada al hotel");
            DateTime newFechaI = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de salida al hotel");
            DateTime newFechaS = DateTime.Parse(Console.ReadLine());

            foreach (Reserva reserva in user.Reservas)
            {
                if (reserva.FechaInicio != newFechaI || reserva.FechaFinal != newFechaS)
                {
                    foreach (Habitacion hab in habitaciones)
                    {
                        if (!hab.FechasReservadas.ContainsKey(newFechaI))
                        {
                            reserva.HabitacionElegida = hab;
                            reserva.FechaInicio = newFechaI;
                            reserva.FechaFinal = newFechaS;

                            Console.WriteLine(reserva);
                            Console.WriteLine("Modificacion completada. Presione una tecla para volver.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
            }
        }

        public static void CancelarReserva(Usuario user)
        {
            Console.WriteLine("Ingrese el numero de la reserva que quiere cancelar:");
            string? numResString = Console.ReadLine();
            int numRes = int.Parse(numResString);

            //Obteniendo la reserva elegida
            for (int i = 0; i < user.Reservas.Count; i++)
            {
                if (user.Reservas[i].IdReserva == numRes)
                {
                    Console.WriteLine("Reserva obtenida");
                    Console.ReadKey();
                    if (user.Reservas[i].FechaInicio < DateTime.Now)
                    {
                        Console.WriteLine("Lo sentimos. No puede cancelar la reserva debido a que ya transcurrio la fecha limite   .");
                    }
                    else
                    {
                        string? response;
                        //Cancelando la reserva
                        Console.WriteLine("¿Esta seguro de cancelar esta reserva?");
                        response = Console.ReadLine();

                        if (response.ToLower() == "si")
                        {
                            user.Reservas.Remove(user.Reservas[i]);
                            Console.WriteLine("Reserva cancelada y eliminada de la lista. Presione una tecla para volver.");
                            Console.ReadKey();
                        }
                        else if (response.ToLower() != "no" || response.ToLower() != "si")
                        {
                            Console.WriteLine("Por favor, responda 'si' o 'no' a la pregunta. Presione una tecla para intentar nuevamente.");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public static void ReservasPerfil(Usuario user, List<Habitacion> habitaciones)
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
                        ModificarReserva(user, habitaciones);
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
