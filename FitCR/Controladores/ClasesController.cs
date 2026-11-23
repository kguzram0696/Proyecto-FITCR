using System.Collections.Generic;
using FitCR.Datos;
using FitCR.Modelos;

namespace FitCR.Controladores
{
    internal class ClasesController
    {
        public static List<ClaseGimnasio> ConsultarClases()
        {
            var repositorio = new RepositorioClasesJson();
            return repositorio.Cargar();
        }
        public static List<(string NombreClase, DateOnly Fecha)> ConsultarHistorial(string nombreUsuario)
        {
            var repositorioUsuarios = new RepositorioUsuariosJson();
            var usuario = repositorioUsuarios.Cargar().FirstOrDefault(registrado =>
                string.Equals(registrado.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null || usuario.ParticipacionesClases.Count == 0)
            {
                return new();
            }

            var clases = ConsultarClases();

            return usuario.ParticipacionesClases
                .OrderByDescending(participacion => participacion.Fecha)
                .Select(participacion =>
                {
                    var clase = clases.FirstOrDefault(item => item.Id == participacion.IdClase);
                    return (NombreClase: clase?.Nombre ?? participacion.IdClase,
                            Fecha: participacion.Fecha);
                })
                .ToList();
        }
        public bool IntentarRegistrarParticipacion(string nombreUsuario, string idClase)
        {
            var repositorioUsuarios = new RepositorioUsuariosJson();
            var usuarios = repositorioUsuarios.Cargar();

            var usuario = usuarios.FirstOrDefault(registrado =>
                string.Equals(registrado.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null ||
                !ConsultarClases().Any(clase => clase.Id == idClase))
            {
                return false;
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            bool yaRegistrada = usuario.ParticipacionesClases.Any(participacion =>
                participacion.IdClase == idClase && participacion.Fecha == hoy);

            if (yaRegistrada)
            {
                return false;
            }

            usuario.ParticipacionesClases.Add(new ParticipacionClase
            {
                IdClase = idClase,
                Fecha = hoy
            });

            repositorioUsuarios.Guardar(usuarios);
            return true;
        }
    }
}
