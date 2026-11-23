using System;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;
using System.Collections.Generic;

namespace FitCR.Controladores
{
    internal static class ObjetivosController
    {
        public static void RegistrarObjetivo(string nombreUsuario, Objetivo objetivo)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            if (objetivo.FechaLimite < hoy)
            {
                throw new ArgumentException("La fecha límite debe ser hoy o una fecha posterior.");
            }

            if (!Enum.IsDefined(objetivo.Direccion))
            {
                throw new ArgumentException("Selecciona cómo se comparará el objetivo.");
            }

            decimal valor = objetivo.ValorObjetivo;
            bool valorValido = objetivo.Tipo switch
            {
                TipoObjetivo.Peso => valor > 0,
                TipoObjetivo.Grasa or TipoObjetivo.Musculo => valor is >= 0 and <= 100,
                TipoObjetivo.Visitas => valor >= 0 && valor == decimal.Truncate(valor),
                _ => false
            };

            if (!valorValido)
            {
                throw new ArgumentException(
                    "Usa un peso mayor que cero, un porcentaje de 0 a 100 o una cantidad entera de visitas.");
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

            objetivo.Id = Guid.NewGuid();
            objetivo.FechaInicio = hoy;

            usuario.Objetivos.Add(objetivo);
            repositorio.Guardar(usuarios);
        }
        internal static EstadoObjetivo EvaluarEstado(
        UsuarioBasico usuario, Objetivo objetivo, DateOnly hoy)
        {
            // Evaluaremos las metas de visitas cuando exista su registro.
            if (objetivo.Tipo == TipoObjetivo.Visitas)
            {
                int visitas = usuario.Visitas
                    .Where(fecha => fecha >= objetivo.FechaInicio &&
                                    fecha <= objetivo.FechaLimite &&
                                    fecha <= hoy)
                    .Distinct()
                    .Count();

                if (objetivo.Direccion == DireccionObjetivo.AlMenos &&
                    visitas >= objetivo.ValorObjetivo)
                {
                    return EstadoObjetivo.Cumplido;
                }

                if (hoy <= objetivo.FechaLimite)
                {
                    return EstadoObjetivo.Pendiente;
                }

                return objetivo.Direccion == DireccionObjetivo.ComoMaximo &&
                       visitas <= objetivo.ValorObjetivo
                    ? EstadoObjetivo.Cumplido
                    : EstadoObjetivo.Vencido;
            }

            bool cumplido = usuario.Mediciones.Any(medicion =>
            {
                if (medicion.Fecha < objetivo.FechaInicio ||
                    medicion.Fecha > objetivo.FechaLimite ||
                    medicion.Fecha > hoy)
                {
                    return false;
                }

                decimal? valorMedido = objetivo.Tipo switch
                {
                    TipoObjetivo.Peso => medicion.PesoKg,
                    TipoObjetivo.Grasa => medicion.PorcentajeGrasa,
                    TipoObjetivo.Musculo => medicion.PorcentajeMusculo,
                    _ => null
                };

                if (valorMedido is not decimal valor)
                {
                    return false;
                }

                return objetivo.Direccion == DireccionObjetivo.AlMenos
                    ? valor >= objetivo.ValorObjetivo
                    : valor <= objetivo.ValorObjetivo;
            });

            if (cumplido)
            {
                return EstadoObjetivo.Cumplido;
            }

            return hoy > objetivo.FechaLimite
                ? EstadoObjetivo.Vencido
                : EstadoObjetivo.Pendiente;
        }
        public static List<(Objetivo Meta, EstadoObjetivo Estado)> ConsultarObjetivos(string nombreUsuario)
        {
            var repositorio = new RepositorioUsuariosJson();
            var usuario = repositorio.Cargar().FirstOrDefault(item =>
                string.Equals(item.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null)
            {
                return new();
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            return usuario.Objetivos
                .OrderBy(objetivo => objetivo.FechaLimite)
                .Select(objetivo => (Meta: objetivo, Estado: EvaluarEstado(usuario, objetivo, hoy)))
                .ToList();
        }
    }
}
