﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    internal class Huesped : Persona
    {
        private int ID = 1;

        public int IdHuesped {  get; private set; }
        public string? TipoDocumento {  get; set; }
        public int NumDocumento { get; set; }
        public int Telefono {  get; set; }
        public string? CorreoElec { get; set; }

        public Huesped(string nombre, string apellidos, string fechaNacimiento, string paisOrigen, string tipoDocumento, int numDocumento, int telefono, string correoElec) : base(nombre, apellidos, fechaNacimiento, paisOrigen)
        {
            IdHuesped = ID++;
            TipoDocumento = tipoDocumento;
            NumDocumento = numDocumento;
            Telefono = telefono;
            CorreoElec = correoElec;
        }
    }
}
