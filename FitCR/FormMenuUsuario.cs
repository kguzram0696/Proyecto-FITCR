using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using FitCR.Controladores;
using FitCR.Modelos;

namespace FitCR
{
    public partial class FormMenuUsuario : Form
    {
        private string? nombreUsuarioActual;
        public FormMenuUsuario()
        {
            InitializeComponent();
            cboTipoObjetivo.DataSource = Enum.GetValues<TipoObjetivo>();
            cboDireccionObjetivo.DataSource = Enum.GetValues<DireccionObjetivo>();
        }
        internal void MostrarUsuario(UsuarioBasico usuario, string? nombreEntrenador)
        {
            nombreUsuarioActual = usuario.NombreUsuario;
            lblEntrenadorAsignado.Text = nombreEntrenador is null
                ? "Sin entrenador asignado"
                : $"Entrenador asignado: {nombreEntrenador}";
        }

        private void btnVerClases_Click(object sender, EventArgs e)
        {
            try
            {

                lstClases.DisplayMember = nameof(ClaseGimnasio.Nombre);
                lstClases.DataSource = ClasesController.ConsultarClases();
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar el catálogo. Revisa el archivo clases.json.");
            }
        }

        private void btnRegistrarParticipacion_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null || lstClases.SelectedItem is not ClaseGimnasio clase)
            {
                MessageBox.Show("Selecciona una clase.");
                return;
            }

            try
            {
                var controlador = new ClasesController();

                if (controlador.IntentarRegistrarParticipacion(nombreUsuarioActual, clase.Id))
                {
                    MessageBox.Show($"Participación registrada en {clase.Nombre}.");
                }
                else
                {
                    MessageBox.Show("La participación ya existe para hoy o la clase o cuenta ya no está disponible.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo registrar la participación. Revisa los archivos de FitCR.");
            }
        }

        private void btnVerHistorialClases_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var historial = ClasesController.ConsultarHistorial(nombreUsuarioActual);

                lstHistorialClases.Items.Clear();

                foreach (var entrada in historial)
                {
                    lstHistorialClases.Items.Add($"{entrada.Fecha:dd/MM/yyyy} - {entrada.NombreClase}");
                }

                if (historial.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes participaciones registradas.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar el historial de clases.");
            }
        }

        private void btnVerRutinas_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var rutinas = RutinasController.ConsultarUltimasRutinas(nombreUsuarioActual);

                lstRutinas.DisplayMember = nameof(Rutina.Nombre);
                lstRutinas.DataSource = rutinas;

                if (rutinas.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes rutinas asignadas.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar las rutinas.");
            }
        }

        private void lstRutinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDetalleEjercicios.Items.Clear();
            lstHistorialCargas.Items.Clear();
            lblVigenciaRutina.Text = "Selecciona una rutina";

            if (lstRutinas.SelectedItem is not Rutina rutina)
            {
                return;
            }

            lblVigenciaRutina.Text = rutina.Retirada
            ? "Estado: retirada"
            : $"Vigencia: {rutina.FechaInicio:dd/MM/yyyy} a {rutina.FechaFin:dd/MM/yyyy}";

            foreach (var ejercicio in rutina.Ejercicios)
            {
                lstDetalleEjercicios.Items.Add(
                    $"{ejercicio.Nombre} | {ejercicio.Series} series × " +
                    $"{ejercicio.Repeticiones} repeticiones | {ejercicio.CargaKg:F2} kg");

                foreach (var cambio in ejercicio.HistorialCargas)
                {
                    lstHistorialCargas.Items.Add(
                        $"{cambio.Fecha:dd/MM/yyyy} | {ejercicio.Nombre} | " +
                        $"{cambio.CargaAnteriorKg:F2} a {cambio.CargaNuevaKg:F2} kg");
                }
            }
        }

        private void btnRegistrarMedicion_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            decimal? grasa = chkIncluirGrasa.Checked ? nudGrasa.Value : null;
            decimal? musculo = chkIncluirMusculo.Checked ? nudMusculo.Value : null;

            try
            {
                var controlador = new MedicionesController();
                controlador.RegistrarMedicion(
                    nombreUsuarioActual, nudPesoMedicion.Value, grasa, musculo);
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo guardar la medición.");
                return;
            }

            MessageBox.Show("Medición guardada correctamente.");
        }

        private void btnVerMediciones_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var historial = MedicionesController.ConsultarHistorial(nombreUsuarioActual);

                lstHistorialMediciones.Items.Clear();

                foreach (var medicion in historial)
                {
                    decimal? imc = UsuarioBasico.CalcularImc(
                        medicion.PesoKg, medicion.EstaturaMetros);

                    string textoImc = imc?.ToString("F2") ?? "Sin dato";
                    string grasa = medicion.PorcentajeGrasa?.ToString("F2") ?? "Sin dato";
                    string musculo = medicion.PorcentajeMusculo?.ToString("F2") ?? "Sin dato";

                    lstHistorialMediciones.Items.Add(
                        $"{medicion.Fecha:dd/MM/yyyy} | {medicion.PesoKg:F2} kg | IMC {textoImc} | " +
                        $"Grasa (%): {grasa} | Músculo (%): {musculo}");
                }

                if (historial.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes mediciones registradas.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar el historial de mediciones.");
            }
        }
        private void btnRegistrarObjetivo_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            if (cboTipoObjetivo.SelectedItem is not TipoObjetivo tipo ||
                cboDireccionObjetivo.SelectedItem is not DireccionObjetivo direccion)
            {
                MessageBox.Show("Selecciona el tipo de objetivo y la comparación.");
                return;
            }

            var objetivo = new Objetivo
            {
                Tipo = tipo,
                Direccion = direccion,
                ValorObjetivo = nudValorObjetivo.Value,
                FechaLimite = DateOnly.FromDateTime(dtpFechaLimiteObjetivo.Value)
            };

            try
            {
                ObjetivosController.RegistrarObjetivo(nombreUsuarioActual, objetivo);
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo guardar el objetivo.");
                return;
            }

            MessageBox.Show("Objetivo guardado correctamente.");
        }

        private void btnVerObjetivos_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var objetivos = ObjetivosController.ConsultarObjetivos(nombreUsuarioActual);

                lstObjetivos.Items.Clear();

                foreach (var entrada in objetivos)
                {
                    var meta = entrada.Meta;
                    string comparacion = meta.Direccion == DireccionObjetivo.AlMenos
                        ? "al menos"
                        : "como máximo";

                    string unidad = meta.Tipo switch
                    {
                        TipoObjetivo.Peso => "kg",
                        TipoObjetivo.Visitas => "visitas",
                        _ => "%"
                    };

                    lstObjetivos.Items.Add(
                        $"{meta.Tipo} | {comparacion} {meta.ValorObjetivo:0.##} {unidad} | " +
                        $"Hasta {meta.FechaLimite:dd/MM/yyyy} | {entrada.Estado}");
                }

                if (objetivos.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes objetivos registrados.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar los objetivos.");
            }
        }

        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                bool registrada = VisitasController.IntentarRegistrarVisita(nombreUsuarioActual);

                MessageBox.Show(registrada
                    ? "Visita registrada correctamente."
                    : "Ya registraste una visita hoy.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo guardar la visita.");
            }
        }

        private void btnVerVisitas_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var visitas = VisitasController.ConsultarVisitas(nombreUsuarioActual);

                lstHistorialVisitas.Items.Clear();

                foreach (var fecha in visitas)
                {
                    lstHistorialVisitas.Items.Add(fecha.ToString("dd/MM/yyyy"));
                }

                if (visitas.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes visitas registradas.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar el historial de visitas.");
            }
        }
        private void btnVerInsignias_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var controlador = new InsigniasController();
                var insignias = controlador.ActualizarYConsultar(nombreUsuarioActual);

                lstInsignias.Items.Clear();

                foreach (var insignia in insignias)
                {
                    lstInsignias.Items.Add(
                        $"{insignia.FechaOtorgada:dd/MM/yyyy} | {insignia.Nombre}");
                }

                if (insignias.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes insignias.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar las insignias.");
            }
        }

        private void btnVerNotificaciones_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            try
            {
                var controlador = new InsigniasController();
                var avisos = controlador.ConsultarNotificaciones(nombreUsuarioActual);

                lstNotificaciones.Items.Clear();

                foreach (var aviso in avisos)
                {
                    lstNotificaciones.Items.Add($"{aviso.Fecha:dd/MM/yyyy} | {aviso.Mensaje}");
                }

                if (avisos.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes notificaciones.");
                }
            }
            catch (Exception ex) when (
                ex is InvalidOperationException or IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar las notificaciones.");
            }
        }

        private void btnVerAumentosCarga_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            DateOnly desde = DateOnly.FromDateTime(dtpEstadisticasDesde.Value);
            DateOnly hasta = DateOnly.FromDateTime(dtpEstadisticasHasta.Value);

            lstAumentosCarga.Items.Clear();

            try
            {
                var aumentos = EstadisticasController.ConsultarAumentosCarga(nombreUsuarioActual, desde, hasta);

                foreach (var aumento in aumentos)
                {
                    lstAumentosCarga.Items.Add(
                        $"{aumento.Fecha:dd/MM/yyyy} | {aumento.Rutina} | {aumento.Ejercicio} | " +
                        $"{aumento.CargaAnteriorKg:F2} a {aumento.CargaNuevaKg:F2} kg");
                }

                if (aumentos.Count == 0)
                {
                    lstAumentosCarga.Items.Add("No hay aumentos de carga en este período.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar los aumentos de carga.");
            }
        }

        private void btnVerProgresoObjetivos_Click(object sender, EventArgs e)
        {
            if (nombreUsuarioActual is null)
            {
                return;
            }

            DateOnly desde = DateOnly.FromDateTime(dtpEstadisticasDesde.Value);
            DateOnly hasta = DateOnly.FromDateTime(dtpEstadisticasHasta.Value);

            lstProgresoObjetivos.Items.Clear();

            try
            {
                var resultados = EstadisticasController.ConsultarProgresoObjetivos(
                    nombreUsuarioActual, desde, hasta);

                foreach (var resultado in resultados)
                {
                    var meta = resultado.Meta;
                    string comparacion = meta.Direccion == DireccionObjetivo.AlMenos
                        ? "≥"
                        : "≤";

                    string unidad = meta.Tipo switch
                    {
                        TipoObjetivo.Peso => "kg",
                        TipoObjetivo.Visitas => "visitas",
                        _ => "%"
                    };

                    string progreso = "Sin mediciones en el rango";
                    if (meta.Tipo == TipoObjetivo.Visitas)
                    {
                        progreso = $"{resultado.UltimoValor:0} visitas en el rango";
                    }
                    else if (resultado.PrimerValor.HasValue)
                    {
                        progreso = $"{resultado.PrimerValor:0.##} a {resultado.UltimoValor:0.##} {unidad}";
                    }

                    lstProgresoObjetivos.Items.Add(
                        $"{meta.Tipo} {comparacion} {meta.ValorObjetivo:0.##} {unidad} | " +
                        $"{progreso} | {resultado.Estado}");
                }

                if (resultados.Count == 0)
                {
                    lstProgresoObjetivos.Items.Add("No hay objetivos que coincidan con este período.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar el progreso de los objetivos.");
            }
        }

        private void btnVerTopVisitas_Click(object sender, EventArgs e)
        {
            DateOnly desde = DateOnly.FromDateTime(dtpEstadisticasDesde.Value);
            DateOnly hasta = DateOnly.FromDateTime(dtpEstadisticasHasta.Value);

            lstMasVisitantes.Items.Clear();
            lstMenosVisitantes.Items.Clear();

            try
            {
                var resultado = EstadisticasController.ConsultarTopVisitas(desde, hasta);

                foreach (var fila in resultado.MasVisitantes)
                {
                    lstMasVisitantes.Items.Add($"{fila.Usuario} | {fila.Visitas}");
                }

                foreach (var fila in resultado.MenosVisitantes)
                {
                    lstMenosVisitantes.Items.Add($"{fila.Usuario} | {fila.Visitas}");
                }

                if (resultado.MasVisitantes.Count == 0)
                {
                    lstMasVisitantes.Items.Add("No hay visitas en este período.");
                }

                if (resultado.MenosVisitantes.Count == 0)
                {
                    lstMenosVisitantes.Items.Add("No hay cuentas para este período.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo cargar la clasificación de visitas.");
            }
        }
    }
}
