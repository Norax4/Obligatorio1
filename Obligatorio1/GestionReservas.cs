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
                    newReserva.PagoReserva.MetodoPago = "Tarjeta";
                    usuarios[i].Reservas.Add(newReserva);
                } else if (i == 1)
                {
                    Reserva newReserva = new Reserva(usuarios[i].Huesped, habitaciones[4], fechaInicio, fechaFinal);
                    habitaciones[4].CountReservas += 1;
                    habitaciones[4].Estado = true;

                    newReserva.PagoReserva.MetodoPago = "Durante Check-In";
                    usuarios[i].Reservas.Add(newReserva);
                } else
                {
                    Reserva newReserva = new Reserva(usuarios[i].Huesped, habitaciones[8], fechaInicio, fechaFinal);
                    habitaciones[8].CountReservas += 1;
                    habitaciones[8].Estado = true;
                    newReserva.PagoReserva.MetodoPago = "Tarjeta";
                    usuarios[i].Reservas.Add(newReserva);
                }
            }

            List<Reserva> reservas = new List<Reserva>();

            return reservas;
        }

        //Reserva de habitaciones
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

            //parseo de datos
            int numHab = int.Parse(numHabS);
            //Comprobaciones para crear la reserva
            if (DateTime.TryParse(fechaI, out DateTime fechaInicio) && DateTime.TryParse(fechaS, out DateTime fechaSalida))
            {
                double duracionReserva = (fechaSalida - fechaInicio).TotalDays;
                foreach (var hab in lista)
                {
                    //Si la habitacion existe/esta en la lista de habitaciones
                    if (hab.NumHabitacion == numHab)
                    {
                        //Si la habitacion elegida ya tiene una reserva en la misma fecha
                        if (!hab.FechasReservadas.ContainsKey(fechaInicio))
                        {
                            //Si la fecha actual es mayor o igual a la ingresada para la llegada
                            if (fechaInicio <= DateTime.Now)
                            {
                                Console.WriteLine("No puede reservar para el mismo día o ingresar una fecha pasada.");
                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadKey();
                            }
                            //Si la fecha de llegada es mayor o igual a la fecha de salida
                            else if (fechaSalida <= fechaInicio)
                            {
                                Console.WriteLine("La fecha de salida no puede ser anterior a la fecha de llegada");
                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadKey();
                            }
                            //Si la reserva dura más de 30 dias
                            else if (duracionReserva > 30)
                            {
                                Console.WriteLine("Lo sentimos. No puede hacer reservas de un lapso de tiempo mayor a 30 dias.");
                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadKey();
                            }
                            else
                            {
                                for (int i = 0; i < user.Reservas.Count; i++)
                                {
                                    //Si la reserva no existe en la lista, se ejecuta el tramite
                                    if (user.Reservas[i].FechaInicio != fechaInicio || user.Reservas[i].FechaFinal != fechaInicio)
                                    {
                                        Reserva newReserva = new Reserva(user.Huesped, hab, fechaInicio, fechaSalida);
                                        string? response;
                                        user.Reservas.Add(newReserva);
                                        try
                                        {
                                            hab.FechasReservadas.Add(fechaInicio, fechaSalida);
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        hab.CountReservas += 1;
                                        //Pago de la reserva
                                        Console.WriteLine($"El pago es de: ${hab.Tarifa * (int)duracionReserva}\n¿Desea realizar el pago de manera inmediata? Si no, se realizará cuando llegue al hotel:");
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
                                            Console.WriteLine("Cliente:  " + user.Nombre + " " + user.Huesped.Apellidos);
                                            Console.WriteLine("Fecha de Emisión:  " + DateTime.Now);
                                            Console.WriteLine("Monto del Pago:  $" + newReserva.PagoReserva.Monto);
                                            Console.WriteLine("Código de transacción:  1111");


                                            newReserva.PagoReserva.FechaPago = DateTime.Now;
                                            newReserva.PagoReserva.MetodoPago = "Tarjeta";
                                            newReserva.PagoReserva.RealizacionPago = true;

                                            Console.WriteLine("Pago realizado.");
                                            Console.WriteLine("Su reserva se ha registrado con exito.");
                                            Console.WriteLine("Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            break;
                                        }
                                        else if (response.ToLower() == "no")
                                        {
                                            newReserva.PagoReserva.MetodoPago = "Durante Check-In";
                                            Console.WriteLine("El pago se realizará en la llegada al hotel.");
                                            Console.WriteLine("Su reserva se ha registrado con exito.");
                                            Console.WriteLine("Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Algo salió mal durante el registro de la reserva. Presione una tecla e intente nuevamente.");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos. La habitación ya fue reservada para esta fecha.");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey();
                        }
                    }
                }
                if (!lista.Any(h => h.NumHabitacion == numHab))
                {
                    Console.WriteLine("El número de habitación ingresado no existe.");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } else
            {
                Console.WriteLine("La fecha ingresada es inválida. Ingrese una fecha válida.");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        //Modificación de la reserva elegida
        public static void ModificarReserva(Usuario user, List<Habitacion> habitaciones)
        {
            Console.WriteLine("--- Modificación de reservas ---");
            //Obtención y parseo de datos
            Console.WriteLine("Ingrese el numero de la reserva que quiere modificar:");
            string? numResString = Console.ReadLine();

            Console.WriteLine("Ingrese el número de habitacion en la que se quiere hospedar:");
            string? numHabString = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de llegada al hotel");
            string? newFechaI = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de salida al hotel");
            string? newFechaS = Console.ReadLine();

            if (int.TryParse(numResString, out int numRes))
            {
                if (int.TryParse(numHabString, out int numHab))
                {
                    if (DateTime.TryParse(newFechaI, out DateTime fechaI) && DateTime.TryParse(newFechaS, out DateTime fechaS))
                    {
                        double duracionReservaAct = (fechaS - fechaI).TotalDays;
                        //Recorriendo la lista de reservas del usuario
                        foreach (Reserva reserva in user.Reservas)
                        {
                            //Comprobación de que existe la reserva
                            if (reserva.IdReserva == numRes)
                            {
                                //Si la fecha actual es mayor o igual a la ingresada para la llegada
                                if (fechaI <= DateTime.Now)
                                {
                                    Console.WriteLine("No puede reservar para el mismo día o ingresar una fecha pasada.");
                                    Console.WriteLine("Presione una tecla para continuar");
                                    Console.ReadKey();
                                }
                                //Si la fecha de llegada es mayor o igual a la fecha de salida
                                else if (fechaS <= fechaI)
                                {
                                    Console.WriteLine("La nueva fecha de salida no puede ser anterior a la nueva fecha de llegada");
                                    Console.WriteLine("Presione una tecla para continuar");
                                    Console.ReadKey();
                                }
                                //Asegurando que el nuevo lapso de estadia no sea mayor a 30 dias
                                else if ((duracionReservaAct > 30))
                                {
                                    Console.WriteLine("Lo sentimos. No puede hacer reservas de un lapso de tiempo mayor a 30 dias.");
                                    Console.WriteLine("Presione una tecla para continuar");
                                    Console.ReadKey();
                                } else { 
                                    foreach (Habitacion hab in habitaciones)
                                    {
                                        //Asegurando que la habitación existe
                                        if (hab.NumHabitacion == numHab)
                                        {
                                            //Asegurando que la habitación no esta reservada para la misma fecha
                                            if (!hab.FechasReservadas.ContainsKey(fechaI))
                                            {
                                                double durResAnterior = (reserva.FechaFinal - reserva.FechaInicio).TotalDays;
                                                reserva.FechaInicio = fechaI;
                                                reserva.FechaFinal = fechaS;

                                                if (reserva.HabitacionElegida.TipoHabitacion != hab.TipoHabitacion || duracionReservaAct != durResAnterior)
                                                {
                                                    int montoAnterior = reserva.PagoReserva.Monto;
                                                    reserva.PagoReserva.Monto = hab.Tarifa * (int)duracionReservaAct;

                                                    if (montoAnterior > reserva.PagoReserva.Monto)
                                                    {
                                                        Console.WriteLine("Con la modificación de la reserva, el precio ha disminuido. Se le reembolsará la diferencia.");
                                                        Console.WriteLine("Espere un momento.");
                                                        Console.WriteLine("...");
                                                        Console.ReadKey();
                                                        Console.WriteLine("...");
                                                        Console.ReadKey();
                                                        Console.WriteLine("...");
                                                        Console.ReadKey();

                                                        Console.WriteLine("--- Comprobante de Reembolso de la Modificación de la Reserva ---");
                                                        Console.WriteLine("Cliente:  " + user.Nombre + " " + user.Huesped.Apellidos);
                                                        Console.WriteLine("Fecha de Emisión:  " + DateTime.Now);
                                                        Console.WriteLine("Monto del Reembolso:  $" + (montoAnterior - (reserva.PagoReserva.Monto)));
                                                        Console.WriteLine("Código de transacción:  1111");
                                                    }
                                                    else if (montoAnterior < reserva.PagoReserva.Monto)
                                                    {
                                                        Console.WriteLine("Con la modificación de la reserva, el precio ha aumentado. Deberá pagar la diferencia.");
                                                        Console.WriteLine($"El pago es de: ${(hab.Tarifa * (int)duracionReservaAct) - montoAnterior}\n¿Desea realizar el pago de manera inmediata? Si no, se realizará cuando llegue al hotel:");
                                                        string? response = Console.ReadLine();

                                                        if (response.ToLower() == "si" && reserva.PagoReserva.MetodoPago == "Tarjeta")
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

                                                            Console.WriteLine("--- Comprobante de Pago de la Modificación de la Reserva ---");
                                                            Console.WriteLine("Cliente:  " + user.Nombre + " " + user.Huesped.Apellidos);
                                                            Console.WriteLine("Fecha de Emisión:  " + DateTime.Now);
                                                            Console.WriteLine("Monto del Pago:  $" + ((reserva.PagoReserva.Monto) - montoAnterior));
                                                            Console.WriteLine("Código de transacción:  1111");
                                                            Console.ReadKey();

                                                            Console.WriteLine("\nPago realizado.");
                                                            Console.WriteLine("Presione una tecla para continuar.");
                                                            Console.ReadKey();
                                                        }
                                                        else if (response.ToLower() == "no" && reserva.PagoReserva.MetodoPago == "Tarjeta")
                                                        {
                                                            reserva.PagoReserva.MetodoPago = "Diferencia Durante Check-In";
                                                            Console.WriteLine("El pago por la diferencia se realizará en la llegada al hotel.");
                                                            Console.WriteLine("Presione una tecla para continuar.");
                                                            Console.ReadKey();
                                                        }
                                                        else if (reserva.PagoReserva.MetodoPago == "Durante Check-In")
                                                        {
                                                            Console.WriteLine("El pago de su reserva fue registrado para finalizarse en el Check-In");
                                                            Console.WriteLine("El pago completo, con el aumento de la modificación, se realizará en la llegada al hotel.");
                                                            Console.WriteLine("Presione una tecla para continuar.");
                                                            Console.ReadKey();
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Algo salió mal durante el proceso. Presione una tecla e intente nuevamente.");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                    }
                                                }

                                                reserva.HabitacionElegida = hab;

                                                Console.WriteLine(reserva);
                                                Console.WriteLine("Modificacion completada. Presione una tecla para volver.");
                                                Console.ReadKey();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("La habitación ya esta ocupada para la fecha ingresada. Presione una tecla para volver.");
                                                Console.ReadKey();
                                            }
                                        }
                                    }
                                    if (!habitaciones.Any(h => h.NumHabitacion == numHab))
                                    {
                                        Console.WriteLine("El número de habitación ingresado no existe en el sistema.");
                                        Console.WriteLine("Presione una tecla para continuar");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        if (!user.Reservas.Any(r => r.IdReserva == numRes))
                        {
                            Console.WriteLine("El número de reserva ingresado no existe en el sistema.");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Los datos ingresados para las nuevas fechas no son válidos. Ingrese fechas válidas.");
                        Console.WriteLine("Presione una tecla para intentar nuevamente.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("El dato ingresado para el número de habitación es inválido. Por favor, ingrese un número.");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } else
            {
                Console.WriteLine("El dato ingresado para el número de reserva es inválido. Por favor, ingrese un número.");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void CancelarReserva(Usuario user)
        {
            Console.WriteLine("--- Cancelación de reservas ---");
            Console.WriteLine("Ingrese el numero de la reserva que quiere cancelar:");
            string? numResString = Console.ReadLine();

            //Obteniendo la reserva elegida
            if (int.TryParse(numResString, out int numRes))
            {
                for (int i = 0; i < user.Reservas.Count; i++)
                {
                    if (user.Reservas[i].IdReserva == numRes)
                    {
                        Console.WriteLine("Reserva obtenida");
                        Console.ReadKey();
                        if (user.Reservas[i].FechaInicio < DateTime.Now)
                        {
                            Console.WriteLine("Lo sentimos. No puede cancelar la reserva debido a que ya transcurrio la fecha limite.");
                        }
                        else
                        {
                            string? response;
                            //Cancelando la reserva
                            Console.WriteLine("¿Esta seguro de cancelar esta reserva? Responda 'si' o 'no':");
                            response = Console.ReadLine();

                            if (response.ToLower() == "si")
                            {
                                user.Reservas.Remove(user.Reservas[i]);
                                Console.WriteLine("Reserva cancelada y eliminada de la lista. Presione una tecla para volver.");
                                Console.ReadKey();
                            }
                            else if (response.ToLower() != "no" || response.ToLower() != "si")
                            {
                                Console.WriteLine("Algo salió mal durante la cancelacion de la reserva. Asegurese de responder 'si' o 'no'.\nPresione una tecla para intentar nuevamente.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                if (!user.Reservas.Any(r => r.IdReserva == numRes))
                {
                    Console.WriteLine("El número de reserva ingresado no existe en el sistema.");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } else
            {
                Console.WriteLine("El dato ingresado para la reserva es inválido. Ingrese un número para identificar la reserva.");
                Console.WriteLine("Presione una tecla para intentar nuevamente.");
                Console.ReadKey();
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
                Console.WriteLine("\nIngrese la opción deseada.");
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
