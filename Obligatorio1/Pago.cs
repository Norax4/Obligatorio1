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
        public Reserva Reserva {  get; set; }
        public int IdPago {  get; private set; }
        public DateTime FechaPago { get; set; }
        public int Monto { get; set; }
        public string? MetodoPago { get; set; }
        public bool RealizacionPago { get; set; }

        public Pago(Reserva reserva, DateTime fechaPago, int monto, string metodoPago)
        {
            IdPago = AutoID++;
            Reserva = reserva;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
            RealizacionPago = false;
        }

        public override string ToString()
        {
            return $"{IdPago}, Fecha del Pago: {FechaPago}, Monto: {Monto}, Metodo de Pago: {MetodoPago}";
        }
    }
}
