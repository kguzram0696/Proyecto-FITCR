using System;
using System.Collections.Generic;
using System.Text;

namespace FitCR.Modelos
{
    internal abstract class Cuenta
    {
        public string Nombre { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string? Credencial { get; set; }
    }
}
