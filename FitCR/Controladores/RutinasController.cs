using System;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;
using System.Collections.Generic;

namespace FitCR.Controladores
{
    internal class RutinasController
    {
        public static void AsignarRutina(Entrenador entrenador, Rutina rutina)
        {
            if (string.IsNullOrWhiteSpace(rutina.Nombre) ||
                string.IsNullOrWhiteSpace(rutina.NombreUsuarioCliente))
            {
                throw new ArgumentException("Escribe el nombre de la rutina y el usuario del cliente.");
            }

            if (rutina.FechaInicio == default || rutina.FechaFin < rutina.FechaInicio)
            {
                throw new ArgumentException("Indica una fecha de inicio y una fecha de fin igual o posterior.");
            }

            if (rutina.Ejercicios.Count == 0 || rutina.Ejercicios.Any(ejercicio =>
                string.IsNullOrWhiteSpace(ejercicio.Nombre) ||
                ejercicio.Series <= 0 ||
                ejercicio.Repeticiones <= 0 ||
                ejercicio.CargaKg < 0))
            {
                throw new ArgumentException(
                    "Agrega ejercicios con nombre, series y repeticiones positivas, y carga de cero o más.");
            }

            var repositorioUsuarios = new RepositorioUsuariosJson();
            var cliente = repositorioUsuarios.Cargar().FirstOrDefault(usuario =>
                string.Equals(usuario.NombreUsuario, rutina.NombreUsuarioCliente.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (cliente is null ||
                !string.Equals(cliente.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("El cliente no está asignado a este entrenador.");
            }

            rutina.Id = Guid.NewGuid();
            rutina.FechaAsignacion = DateOnly.FromDateTime(DateTime.Today);
            rutina.Nombre = rutina.Nombre.Trim();
            rutina.NombreUsuarioCliente = cliente.NombreUsuario;
            rutina.NombreUsuarioEntrenador = entrenador.NombreUsuario;

            var repositorioRutinas = new RepositorioRutinasJson();
            var rutinas = repositorioRutinas.Cargar();
            rutinas.Add(rutina);
            repositorioRutinas.Guardar(rutinas);
        }
        public static List<Rutina> ConsultarUltimasRutinas(string nombreUsuario)
        {
            var repositorio = new RepositorioRutinasJson();

            return repositorio.Cargar()
                .Where(rutina => string.Equals(rutina.NombreUsuarioCliente, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase))
                .Reverse()
                .Take(5)
                .ToList();
        }
        public static List<Rutina> ConsultarRutinasEntrenador(Entrenador entrenador)
        {
            var repositorio = new RepositorioRutinasJson();

            return repositorio.Cargar()
                .Where(rutina => !rutina.Retirada &&
                    string.Equals(rutina.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                        StringComparison.OrdinalIgnoreCase))
                .Reverse()
                .ToList();
        }
        public static void EditarRutina(
        Entrenador entrenador,
        Guid idRutina,
        string nombre,
        DateOnly fechaInicio,
        DateOnly fechaFin)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Escribe el nombre de la rutina.");
            }

            if (fechaInicio == default || fechaFin < fechaInicio)
            {
                throw new ArgumentException(
                    "Indica una fecha de inicio y una fecha de fin igual o posterior.");
            }

            var repositorio = new RepositorioRutinasJson();
            var rutinas = repositorio.Cargar();

            var rutina = rutinas.FirstOrDefault(item =>
                item.Id == idRutina &&
                string.Equals(item.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (rutina is null)
            {
                throw new InvalidOperationException(
                    "La rutina no está disponible para este entrenador.");
            }

            rutina.Nombre = nombre.Trim();
            rutina.FechaInicio = fechaInicio;
            rutina.FechaFin = fechaFin;

            repositorio.Guardar(rutinas);
        }
        public static void RetirarRutina(Entrenador entrenador, Guid idRutina)
        {
            var repositorio = new RepositorioRutinasJson();
            var rutinas = repositorio.Cargar();

            var rutina = rutinas.FirstOrDefault(item =>
                item.Id == idRutina &&
                !item.Retirada &&
                string.Equals(item.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (rutina is null)
            {
                throw new InvalidOperationException(
                    "La rutina ya fue retirada o no está disponible para este entrenador.");
            }

            rutina.Retirada = true;
            repositorio.Guardar(rutinas);
        }
        public bool CambiarCarga(
    Entrenador entrenador,
    Guid idRutina,
    int indiceEjercicio,
    decimal cargaNuevaKg)
        {
            if (cargaNuevaKg < 0)
            {
                throw new ArgumentException("La carga debe ser de cero kilos o más.");
            }

            var repositorio = new RepositorioRutinasJson();
            var rutinas = repositorio.Cargar();

            var rutina = rutinas.FirstOrDefault(item =>
                item.Id == idRutina &&
                !item.Retirada &&
                string.Equals(item.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (rutina is null)
            {
                throw new InvalidOperationException(
                    "La rutina no está disponible para este entrenador.");
            }

            if (indiceEjercicio < 0 || indiceEjercicio >= rutina.Ejercicios.Count)
            {
                throw new ArgumentException("Selecciona un ejercicio de la rutina.");
            }

            var ejercicio = rutina.Ejercicios[indiceEjercicio];

            if (ejercicio.CargaKg == cargaNuevaKg)
            {
                return false;
            }

            ejercicio.HistorialCargas.Add(new CambioCarga
            {
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                CargaAnteriorKg = ejercicio.CargaKg,
                CargaNuevaKg = cargaNuevaKg
            });

            ejercicio.CargaKg = cargaNuevaKg;
            repositorio.Guardar(rutinas);
            return true;
        }
    }
}
