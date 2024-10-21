//Menú Inicial

using Obligatorio1;

Huesped huesped1 = new Huesped("Jose", "Garcia", "24/10/1998", "Uruguay", "Cédula", 55555555, 098111111, "garciajose@gmail.com");
Huesped huesped2 = new Huesped("Jose", "Martinez", "27/04/1987", "Mexico", "Pasaporte", 333333, 987333222, "josemartinez@gmail.com");
Huesped huesped3 = new Huesped("Maria", "Jimenez Arboleda", "03/11/2001", "Uruguay", "Cédula", 66666666, 093222222, "mariajiar@gmail.com");
List<Huesped> huespedes = new List<Huesped> { huesped1, huesped2, huesped3 };

Usuario usuario1 = new Usuario("Jose", "garciajose@gmail.com", "19982410");
Usuario usuario2 = new Usuario("Jose", "josemartinez@gmail.com", "Martinez2704");
Usuario usuario3 = new Usuario("Maria", "mariajiar@gmail.com", "3434greys");
Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>
{
    {huesped1.CorreoElec, usuario1 },
    {huesped2.CorreoElec, usuario2 },
    {huesped3.CorreoElec, usuario3 }
};

List<Reserva> reservas = new List<Reserva>();

#region habitaciones
Habitacion habitacion1 = new Habitacion(101, "Simple", 2);
Habitacion habitacion2 = new Habitacion(102, "Simple", 2);
Habitacion habitacion3 = new Habitacion(103, "Simple", 2);
Habitacion habitacion4 = new Habitacion(104, "Simple", 2);
Habitacion habitacion5 = new Habitacion(105, "Simple", 2);
Habitacion habitacion6 = new Habitacion(106, "Simple", 2);
Habitacion habitacion7 = new Habitacion(107, "Simple", 2);
Habitacion habitacion8 = new Habitacion(108, "Simple", 2);
Habitacion habitacion9 = new Habitacion(109, "Simple", 2);
Habitacion habitacion10 = new Habitacion(110, "Simple", 2);
Habitacion habitacion11 = new Habitacion(201, "Doble", 4);
Habitacion habitacion12 = new Habitacion(202, "Doble", 4);
Habitacion habitacion13 = new Habitacion(203, "Doble", 4);
Habitacion habitacion14 = new Habitacion(204, "Doble", 4);
Habitacion habitacion15 = new Habitacion(205, "Doble", 4);
Habitacion habitacion16 = new Habitacion(206, "Doble", 4);
Habitacion habitacion17 = new Habitacion(301, "Suite", 3);
Habitacion habitacion18 = new Habitacion(302, "Suite", 3);
Habitacion habitacion19 = new Habitacion(303, "Suite", 3);
Habitacion habitacion20 = new Habitacion(304, "Suite", 3);
List<Habitacion> habitaciones = new List<Habitacion> { habitacion1, habitacion2, habitacion3, habitacion4, habitacion5, habitacion6, habitacion7, habitacion8, habitacion9, habitacion10, habitacion11,
habitacion12, habitacion13, habitacion14, habitacion15, habitacion16, habitacion17, habitacion18, habitacion19, habitacion20};
#endregion


bool salir = false;

while (!salir)
{
    Console.WriteLine("Inicio:");
    Console.WriteLine("");
    Console.WriteLine("1. Iniciar Sesion");
    Console.WriteLine("2. Registrarse");
    Console.WriteLine("3. Salir");
    Console.WriteLine("");
    Console.WriteLine("Ingrese la opción deseada:");
    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Menu.InicioSesion(usuarios);
            break;
        case "2":
            Menu.Registro(huespedes, usuarios);
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