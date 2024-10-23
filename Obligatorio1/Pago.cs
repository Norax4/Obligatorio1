using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Pago
    {
        private int AutoID = 1001;
        public int IdReserva {  get; set; }
        public int IdPago {  get; private set; }
        public string? FechaPago { get; set; }
        public int Monto { get; set; }
        public string? MetodoPago { get; set; }
        public string? RealizacionPago { get; set; }

        public Pago(int idReserva, string fechaPago, int monto, string metodoPago, string realizacionPago)
        {
            IdPago = AutoID++;
            IdReserva = idReserva;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
            RealizacionPago = realizacionPago;
        }
    }
}
