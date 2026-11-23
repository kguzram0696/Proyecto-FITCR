using System;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;
using System.Collections.Generic;

namespace FitCR.Controladores
{
    internal class MedicionesController
    {
        public void RegistrarMedicion(
            string nombreUsuario,
            decimal pesoKg,
            decimal? porcentajeGrasa,
            decimal? porcentajeMusculo)
        {
            if (pesoKg <= 0)
            {
                throw new ArgumentException("El peso debe ser mayor que cero.");
            }

            if (porcentajeGrasa is < 0 or > 100 ||
                porcentajeMusculo is < 0 or > 100)
            {
                throw new ArgumentException("Los porcentajes deben estar entre 0 y 100.");
            }

            var repositorio = new RepositorioUsuariosJson();
            var usuarios = repositorio.Cargar();

            var usuario = usuarios.FirstOrDefault(item =>
                string.Equals(item.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null)
            {
                throw new InvalidOperationException("No se encontró la cuenta del usuario.");
            }

            if (usuario.EstaturaMetros <= 0)
            {
                throw new InvalidOperationException("La cuenta debe tener una estatura válida.");
            }

            usuario.Mediciones.Add(new Medicion
            {
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                PesoKg = pesoKg,
                EstaturaMetros = usuario.EstaturaMetros,
                PorcentajeGrasa = porcentajeGrasa,
                PorcentajeMusculo = porcentajeMusculo
            });

            usuario.PesoKg = pesoKg;
            repositorio.Guardar(usuarios);
        }
        public static List<Medicion> ConsultarHistorial(string nombreUsuario)
        {
            var repositorio = new RepositorioUsuariosJson();

            var usuario = repositorio.Cargar().FirstOrDefault(item =>
                string.Equals(item.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            return usuario?.Mediciones
                .OrderByDescending(medicion => medicion.Fecha)
                .ToList() ?? new List<Medicion>();
        }
        public static void ProgramarMedicion(
            Entrenador entrenador, string nombreUsuario, DateOnly fecha)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("Escribe el nombre de usuario del cliente.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            if (fecha < hoy)
            {
                throw new ArgumentException("La fecha de la medición debe ser hoy o posterior.");
            }

            var repositorio = new RepositorioUsuariosJson();
            var usuarios = repositorio.Cargar();

            var cliente = usuarios.FirstOrDefault(usuario =>
                string.Equals(usuario.NombreUsuario, nombreUsuario.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (cliente is null ||
                !string.Equals(cliente.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("El cliente no está asignado a este entrenador.");
            }

            cliente.FechaProximaMedicion = fecha;
            repositorio.Guardar(usuarios);
        }
    }
}
