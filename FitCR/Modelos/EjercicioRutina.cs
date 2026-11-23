using System;
using System.Collections.Generic;
using System.Text;

namespace FitCR.Modelos
{
    internal class EjercicioRutina
    {
        public string Nombre { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public decimal CargaKg { get; set; }
        public List<CambioCarga> HistorialCargas { get; set; } = new();
    }
}
