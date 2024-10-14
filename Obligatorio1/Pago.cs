using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Pago : Reserva
    {
        private int AutoID = 1001;

        public int IdPago {  get; private set; }
        public int IdReserva { get; set; }
        public string? FechaPago { get; set; }
        public int Monto { get; set; }
        public string? MetodoPago { get; set; }
    }
}
