using System;

namespace FitCR.Modelos
{
    internal class CambioCarga
    {
        public DateOnly Fecha { get; set; }
        public decimal CargaAnteriorKg { get; set; }
        public decimal CargaNuevaKg { get; set; }
    }
}
