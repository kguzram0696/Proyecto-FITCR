using System;
using System.Collections.Generic;

namespace FitCR.Modelos
{
    internal class Rutina
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string NombreUsuarioCliente { get; set; } = string.Empty;
        public string NombreUsuarioEntrenador { get; set; } = string.Empty;
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public DateOnly? FechaAsignacion { get; set; }
        public bool Retirada { get; set; }
        public List<EjercicioRutina> Ejercicios { get; set; } = new();
    }
}
