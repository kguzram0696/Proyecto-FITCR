using System;

namespace FitCR.Modelos
{
    internal class Insignia
    {
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public DateOnly FechaOtorgada { get; set; }
        public bool EsIncumplimiento { get; set; }
    }
}
