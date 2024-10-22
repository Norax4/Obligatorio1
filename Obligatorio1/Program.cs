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

List<Habitacion> habitaciones = Precarga.CargaHabitaciones(); //YUJU- recuerda borrar estos comentarios al entregar


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