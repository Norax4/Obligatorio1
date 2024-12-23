﻿//Menú Inicial

using Obligatorio1;

List<Huesped> huespedes = GestionHuespedes.CargaHuespedes();

List<Usuario> usuarios = GestionHuespedes.CargaUsuarios(huespedes);

List<Habitacion> habitaciones = GestionHabitaciones.CargaHabitaciones(); 

List<Reserva> reservas = GestionReservas.CargaReservas(habitaciones, usuarios);

bool salir = false;

while (!salir)
{
    Console.WriteLine("Inicio:");
    Console.WriteLine("");
    Console.WriteLine("1. Iniciar Sesion");
    Console.WriteLine("2. Registrarse");
    Console.WriteLine("3. Estadisticas");
    Console.WriteLine("4. Salir");
    Console.WriteLine("");
    Console.WriteLine("Ingrese la opción deseada:");
    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Menu.InicioSesion(usuarios, habitaciones);
            break;
        case "2":
            Menu.Registro(huespedes, usuarios);
            break;
        case "3":
            Menu.Estadisticas(usuarios, habitaciones);
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