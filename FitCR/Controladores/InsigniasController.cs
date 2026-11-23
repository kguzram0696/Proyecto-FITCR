using System;
using System.Collections.Generic;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;

namespace FitCR.Controladores
{
    internal class InsigniasController
    {
        private UsuarioBasico ActualizarLogros(string nombreUsuario)
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
            bool hayCambios = false;

            foreach (var objetivo in usuario.Objetivos)
            {
                EstadoObjetivo estado = ObjetivosController.EvaluarEstado(usuario, objetivo, hoy);

                if (estado == EstadoObjetivo.Pendiente)
                {
                    continue;
                }

                bool vencido = estado == EstadoObjetivo.Vencido;
                string clave = vencido
                    ? $"objetivo-vencido:{objetivo.Id}"
                    : $"objetivo:{objetivo.Id}";

                if (usuario.Insignias.Any(insignia => insignia.Clave == clave))
                {
                    continue;
                }

                string tipo = objetivo.Tipo == TipoObjetivo.Musculo
                    ? "músculo"
                    : objetivo.Tipo.ToString().ToLowerInvariant();

                usuario.Insignias.Add(new Insignia
                {
                    Clave = clave,
                    Nombre = vencido ? $"Meta de {tipo} vencida" : $"Meta de {tipo} cumplida",
                    FechaOtorgada = hoy,
                    EsIncumplimiento = vencido
                });

                hayCambios = true;
            }
            DateOnly? ultimaMedicion = usuario.Mediciones
                .Where(medicion => medicion.Fecha <= hoy)
                .Select(medicion => (DateOnly?)medicion.Fecha)
                .Max();

            DateOnly? referenciaProgreso = ultimaMedicion ?? usuario.FechaRegistro;

            if (referenciaProgreso is DateOnly referencia &&
                referencia <= hoy.AddDays(-30))
            {
                string clave = $"sin-progreso:{referencia:yyyy-MM-dd}";

                if (!usuario.Insignias.Any(insignia => insignia.Clave == clave))
                {
                    usuario.Insignias.Add(new Insignia
                    {
                        Clave = clave,
                        Nombre = "30 días sin registrar una medición",
                        FechaOtorgada = hoy,
                        EsIncumplimiento = true
                    });

                    hayCambios = true;
                }
            }
            int diasDesdeLunes = ((int)hoy.DayOfWeek + 6) % 7;
            DateOnly lunesActual = hoy.AddDays(-diasDesdeLunes);
            DateOnly inicioSemanaAnterior = lunesActual.AddDays(-7);
            DateOnly finSemanaAnterior = lunesActual.AddDays(-1);

            string claveBajaAsistencia = $"baja-asistencia:{inicioSemanaAnterior:yyyy-MM-dd}";

            bool apareceEnClasificacion = usuarios
                .Where(cuenta => cuenta.FechaRegistro is DateOnly fechaRegistro &&
                                 fechaRegistro <= inicioSemanaAnterior)
                .Select(cuenta => new
                {
                    cuenta.NombreUsuario,
                    TotalVisitas = cuenta.Visitas
                        .Where(fecha => fecha >= inicioSemanaAnterior && fecha <= finSemanaAnterior)
                        .Distinct()
                        .Count()
                })
                .Where(cuenta => cuenta.TotalVisitas < 2)
                .OrderBy(cuenta => cuenta.TotalVisitas)
                .ThenBy(cuenta => cuenta.NombreUsuario, StringComparer.OrdinalIgnoreCase)
                .Take(10)
                .Any(cuenta => string.Equals(cuenta.NombreUsuario, usuario.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (apareceEnClasificacion &&
                !usuario.Insignias.Any(insignia => insignia.Clave == claveBajaAsistencia))
            {
                usuario.Insignias.Add(new Insignia
                {
                    Clave = claveBajaAsistencia,
                    Nombre = $"Menos de dos visitas del {inicioSemanaAnterior:dd/MM/yyyy} " +
                             $"al {finSemanaAnterior:dd/MM/yyyy}",
                    FechaOtorgada = hoy,
                    EsIncumplimiento = true
                });

                hayCambios = true;
            }
            foreach (var insignia in usuario.Insignias)
            {
                string claveAviso = $"insignia:{insignia.Clave}";

                if (usuario.Notificaciones.Any(aviso => aviso.Clave == claveAviso))
                {
                    continue;
                }

                usuario.Notificaciones.Add(new Notificacion
                {
                    Clave = claveAviso,
                    Mensaje = insignia.EsIncumplimiento
                        ? $"Insignia por incumplimiento: {insignia.Nombre}."
                        : $"Has ganado la insignia: {insignia.Nombre}.",
                    Fecha = insignia.FechaOtorgada
                });

                hayCambios = true;
            }
            var repositorioRutinas = new RepositorioRutinasJson();

            foreach (var rutina in repositorioRutinas.Cargar())
            {
                if (!string.Equals(rutina.NombreUsuarioCliente, usuario.NombreUsuario,
                        StringComparison.OrdinalIgnoreCase) ||
                    rutina.FechaAsignacion is not DateOnly fecha)
                {
                    continue;
                }

                string claveAviso = $"rutina-asignada:{rutina.Id}";

                if (usuario.Notificaciones.Any(aviso => aviso.Clave == claveAviso))
                {
                    continue;
                }

                usuario.Notificaciones.Add(new Notificacion
                {
                    Clave = claveAviso,
                    Mensaje = $"Nueva rutina asignada: {rutina.Nombre}.",
                    Fecha = fecha
                });

                hayCambios = true;
            }
            var semanas = usuario.Visitas
            .Where(fecha => fecha <= hoy)
            .Distinct()
            .GroupBy(fecha => fecha.AddDays(-(((int)fecha.DayOfWeek + 6) % 7)));

            foreach (var semana in semanas)
            {
                var primerasCinco = semana.OrderBy(fecha => fecha).Take(5).ToList();
                string claveAviso = $"descanso-semana:{semana.Key:yyyy-MM-dd}";

                if (primerasCinco.Count < 5 ||
                    usuario.Notificaciones.Any(aviso => aviso.Clave == claveAviso))
                {
                    continue;
                }

                usuario.Notificaciones.Add(new Notificacion
                {
                    Clave = claveAviso,
                    Mensaje = "Descansa esta semana.",
                    Fecha = primerasCinco[4]
                });

                hayCambios = true;
            }
            if (hayCambios)
            {
                repositorio.Guardar(usuarios);
            }

            return usuario;
        }
        public List<Insignia> ActualizarYConsultar(string nombreUsuario)
        {
            return ActualizarLogros(nombreUsuario).Insignias
                .OrderByDescending(insignia => insignia.FechaOtorgada)
                .ToList();
        }

        public List<Notificacion> ConsultarNotificaciones(string nombreUsuario)
        {
            return ActualizarLogros(nombreUsuario).Notificaciones
                .OrderByDescending(aviso => aviso.Fecha)
                .ToList();
        }
    }
}
