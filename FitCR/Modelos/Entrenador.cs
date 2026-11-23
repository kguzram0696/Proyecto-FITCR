using System;
using System.Collections.Generic;
using System.Text;

namespace FitCR.Modelos
{
    internal enum TipoEntrenador
    {
        Gimnasio,
        Personal
    }

    internal class Entrenador : Cuenta
    {
        public TipoEntrenador Tipo { get; set; }
        public List<Notificacion> Notificaciones { get; set; } = new();
    }
}
