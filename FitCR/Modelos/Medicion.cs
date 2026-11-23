using System;

namespace FitCR.Modelos
{
    internal class Medicion
    {
        public DateOnly Fecha { get; set; }
        public decimal PesoKg { get; set; }
        public decimal EstaturaMetros { get; set; }
        public decimal? PorcentajeGrasa { get; set; }
        public decimal? PorcentajeMusculo { get; set; }
    }
}
