using System;
using System.Collections.Generic;
using System.Text;

namespace FitCR.Modelos
{
    internal class UsuarioBasico : Cuenta
    {
        public int Edad { get; set; }
        public DateOnly? FechaRegistro { get; set; }
        public decimal PesoKg { get; set; }
        public decimal EstaturaMetros { get; set; }
        public string? NombreUsuarioEntrenador { get; set; }
        public List<ParticipacionClase> ParticipacionesClases { get; set; } = new();
        public List<Medicion> Mediciones { get; set; } = new();
        public DateOnly? FechaProximaMedicion { get; set; }
        public List<Objetivo> Objetivos { get; set; } = new();
        public List<DateOnly> Visitas { get; set; } = new();
        public List<Insignia> Insignias { get; set; } = new();
        public List<Notificacion> Notificaciones { get; set; } = new();
        public decimal? CalcularImc()
        {
            return CalcularImc(PesoKg, EstaturaMetros);
        }

        internal static decimal? CalcularImc(decimal pesoKg, decimal estaturaMetros)
        {
            if (pesoKg <= 0 || estaturaMetros <= 0)
            {
                return null;
            }

            return pesoKg / (estaturaMetros * estaturaMetros);
        }
    }
}
