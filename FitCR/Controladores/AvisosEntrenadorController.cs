using System;
using System.Collections.Generic;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;

namespace FitCR.Controladores
{
    internal class AvisosEntrenadorController
    {
        public List<Notificacion> ActualizarYConsultar(string nombreUsuario)
        {
            var repositorio = new RepositorioEntrenadoresJson();
            var entrenadores = repositorio.Cargar();

            var entrenador = entrenadores.FirstOrDefault(cuenta =>
                string.Equals(cuenta.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (entrenador is null)
            {
                throw new InvalidOperationException("No se encontró la cuenta del entrenador.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            DateOnly hasta = hoy.AddDays(7);
            bool hayCambios = false;

            var rutinas = RutinasController.ConsultarRutinasEntrenador(entrenador);

            foreach (var rutina in rutinas)
            {
                if (rutina.FechaFin < hoy || rutina.FechaFin > hasta)
                {
                    continue;
                }

                string clave = $"rutina-por-vencer:{rutina.Id}:{rutina.FechaFin:yyyy-MM-dd}";

                if (entrenador.Notificaciones.Any(aviso => aviso.Clave == clave))
                {
                    continue;
                }

                entrenador.Notificaciones.Add(new Notificacion
                {
                    Clave = clave,
                    Mensaje = $"La rutina «{rutina.Nombre}» de {rutina.NombreUsuarioCliente} " +
                              $"vence el {rutina.FechaFin:dd/MM/yyyy}.",
                    Fecha = hoy
                });

                hayCambios = true;
            }
            var repositorioUsuarios = new RepositorioUsuariosJson();

            foreach (var cliente in repositorioUsuarios.Cargar())
            {
                if (!string.Equals(cliente.NombreUsuarioEntrenador, entrenador.NombreUsuario,
                        StringComparison.OrdinalIgnoreCase) ||
                    cliente.FechaProximaMedicion is not DateOnly fechaMedicion ||
                    fechaMedicion < hoy || fechaMedicion > hasta)
                {
                    continue;
                }

                string clave = $"medicion-programada:{cliente.NombreUsuario}:{fechaMedicion:yyyy-MM-dd}";

                if (entrenador.Notificaciones.Any(aviso => aviso.Clave == clave))
                {
                    continue;
                }

                entrenador.Notificaciones.Add(new Notificacion
                {
                    Clave = clave,
                    Mensaje = $"Próxima medición de {cliente.Nombre} ({cliente.NombreUsuario}) " +
                              $"el {fechaMedicion:dd/MM/yyyy}.",
                    Fecha = hoy
                });

                hayCambios = true;
            }
            if (hayCambios)
            {
                repositorio.Guardar(entrenadores);
            }

            return entrenador.Notificaciones
                .OrderByDescending(aviso => aviso.Fecha)
                .ToList();
        }
    }
}
