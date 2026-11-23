using System;

namespace FitCR.Modelos
{
    internal class Notificacion
    {
        public string Clave { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
    }
}
