using System;
using System.Collections.Generic;
using System.Linq;
using FitCR.Datos;
using FitCR.Modelos;

namespace FitCR.Controladores
{
    internal static class EstadisticasController
    {
        public static List<(DateOnly Fecha, string Rutina, string Ejercicio,
            decimal CargaAnteriorKg, decimal CargaNuevaKg)> ConsultarAumentosCarga(
                string nombreUsuario, DateOnly desde, DateOnly hasta)
        {
            if (desde > hasta)
            {
                throw new ArgumentException(
                    "La fecha inicial debe ser igual o anterior a la fecha final.");
            }

            var repositorio = new RepositorioRutinasJson();
            var aumentos = new List<(DateOnly Fecha, string Rutina, string Ejercicio,
                decimal CargaAnteriorKg, decimal CargaNuevaKg)>();

            var rutinasDelUsuario = repositorio.Cargar().Where(rutina =>
                string.Equals(rutina.NombreUsuarioCliente, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            foreach (var rutina in rutinasDelUsuario)
            {
                foreach (var ejercicio in rutina.Ejercicios)
                {
                    foreach (var cambio in ejercicio.HistorialCargas)
                    {
                        if (cambio.Fecha >= desde && cambio.Fecha <= hasta &&
                            cambio.CargaNuevaKg > cambio.CargaAnteriorKg)
                        {
                            aumentos.Add((cambio.Fecha, rutina.Nombre, ejercicio.Nombre,
                                cambio.CargaAnteriorKg, cambio.CargaNuevaKg));
                        }
                    }
                }
            }

            return aumentos.OrderByDescending(aumento => aumento.Fecha).ToList();
        }
        public static List<(Objetivo Meta, EstadoObjetivo Estado, decimal? PrimerValor, decimal? UltimoValor)>
            ConsultarProgresoObjetivos(string nombreUsuario, DateOnly desde, DateOnly hasta)
        {
            if (desde > hasta)
            {
                throw new ArgumentException(
                    "La fecha inicial debe ser igual o anterior a la fecha final.");
            }

            var repositorio = new RepositorioUsuariosJson();
            var usuario = repositorio.Cargar().FirstOrDefault(cuenta =>
                string.Equals(cuenta.NombreUsuario, nombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            var resultados = new List<(Objetivo Meta, EstadoObjetivo Estado,
                decimal? PrimerValor, decimal? UltimoValor)>();

            if (usuario is null)
            {
                return resultados;
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            DateOnly corte = hasta < hoy ? hasta : hoy;

            foreach (var meta in usuario.Objetivos.OrderBy(meta => meta.FechaLimite))
            {
                DateOnly inicio = desde > meta.FechaInicio ? desde : meta.FechaInicio;
                DateOnly fin = corte < meta.FechaLimite ? corte : meta.FechaLimite;

                if (inicio > fin)
                {
                    continue;
                }

                var estado = ObjetivosController.EvaluarEstado(usuario, meta, corte);

                if (meta.Tipo == TipoObjetivo.Visitas)
                {
                    int visitas = usuario.Visitas
                        .Where(fecha => fecha >= inicio && fecha <= fin)
                        .Distinct()
                        .Count();

                    resultados.Add((meta, estado, null, visitas));
                    continue;
                }

                var valores = usuario.Mediciones
                    .Where(medicion => medicion.Fecha >= inicio && medicion.Fecha <= fin)
                    .OrderBy(medicion => medicion.Fecha)
                    .Select(medicion => meta.Tipo switch
                    {
                        TipoObjetivo.Peso => (decimal?)medicion.PesoKg,
                        TipoObjetivo.Grasa => medicion.PorcentajeGrasa,
                        TipoObjetivo.Musculo => medicion.PorcentajeMusculo,
                        _ => null
                    })
                    .Where(valor => valor.HasValue)
                    .ToList();

                resultados.Add((meta, estado, valores.FirstOrDefault(), valores.LastOrDefault()));
            }

            return resultados;
        }
        public static (List<(string Usuario, int Visitas)> MasVisitantes,
        List<(string Usuario, int Visitas)> MenosVisitantes)
            ConsultarTopVisitas(DateOnly desde, DateOnly hasta)
        {
            if (desde > hasta)
            {
                throw new ArgumentException(
                    "La fecha inicial debe ser igual o anterior a la fecha final.");
            }

            var repositorio = new RepositorioUsuariosJson();

            var conteos = repositorio.Cargar()
                .Where(usuario => usuario.FechaRegistro is null ||
                                  usuario.FechaRegistro <= hasta)
                .Select(usuario => (
                    Usuario: usuario.NombreUsuario,
                    Visitas: usuario.Visitas
                        .Where(fecha => fecha >= desde && fecha <= hasta)
                        .Distinct()
                        .Count()))
                .ToList();

            var masVisitantes = conteos
                .Where(fila => fila.Visitas > 0)
                .OrderByDescending(fila => fila.Visitas)
                .ThenBy(fila => fila.Usuario, StringComparer.OrdinalIgnoreCase)
                .Take(10)
                .ToList();

            var menosVisitantes = conteos
                .OrderBy(fila => fila.Visitas)
                .ThenBy(fila => fila.Usuario, StringComparer.OrdinalIgnoreCase)
                .Take(10)
                .ToList();

            return (masVisitantes, menosVisitantes);
        }
    }
}
