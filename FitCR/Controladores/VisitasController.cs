using System;
using System.Linq;
using FitCR.Datos;
using System.Collections.Generic;

namespace FitCR.Controladores
{
    internal static class VisitasController
    {
        public static bool IntentarRegistrarVisita(string nombreUsuario)
        {
            var repositorio = new RepositorioUsuariosJson();
            var usuarios = repositorio.Cargar();

            var usuario = usuarios.FirstOrDefault(item =>
                string.Equals(item.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null)
            {
                throw new InvalidOperationException("No se encontró la cuenta del usuario.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            if (usuario.Visitas.Contains(hoy))
            {
                return false;
            }

            usuario.Visitas.Add(hoy);
            repositorio.Guardar(usuarios);
            return true;
        }
        public static List<DateOnly> ConsultarVisitas(string nombreUsuario)
        {
            var repositorio = new RepositorioUsuariosJson();

            var usuario = repositorio.Cargar().FirstOrDefault(item =>
                string.Equals(item.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            return usuario?.Visitas
                .Distinct()
                .OrderByDescending(fecha => fecha)
                .ToList() ?? new List<DateOnly>();
        }
    }
}
