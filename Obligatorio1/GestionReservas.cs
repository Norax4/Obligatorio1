using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class GestionReservas
    {
        public static List<Reserva> CargaReservas()
        {
            List<Reserva> reservas = new List<Reserva>();

            return reservas;
        }

        public static void ReservarHabitacion(Usuario user)
        {

        }

        public static void ReservasPerfil(Usuario user)
        {
            Console.WriteLine("--- Lista de reservas hechas en este Perfil ---");

            foreach (var res in user.Reservas)
            {
                Console.WriteLine(res);
            }
        }

    }
}
