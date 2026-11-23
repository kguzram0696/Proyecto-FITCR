using System;

namespace FitCR.Modelos
{
    internal enum TipoObjetivo
    {
        Peso,
        Grasa,
        Musculo,
        Visitas
    }

    internal enum DireccionObjetivo
    {
        AlMenos,
        ComoMaximo
    }
    internal enum EstadoObjetivo
    {
        Pendiente,
        Cumplido,
        Vencido
    }
    internal class Objetivo
    {
        public Guid Id { get; set; }
        public TipoObjetivo Tipo { get; set; }
        public DireccionObjetivo Direccion { get; set; }
        public decimal ValorObjetivo { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaLimite { get; set; }
    }
}
