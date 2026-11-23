using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FitCR.Modelos;
using System.IO;
using System.Text.Json;
using FitCR.Controladores;

namespace FitCR
{
    public partial class FormAsignarRutina : Form
    {
        private readonly List<EjercicioRutina> ejercicios = new();
        private readonly Entrenador? entrenadorActual;
        private readonly Guid? idRutinaEditar;
        public FormAsignarRutina()
        {
            InitializeComponent();
        }
        internal FormAsignarRutina(Entrenador entrenador) : this()
        {
            entrenadorActual = entrenador;
        }
        internal FormAsignarRutina(Entrenador entrenador, Rutina rutina) : this(entrenador)
        {
            idRutinaEditar = rutina.Id;

            Text = "FitCR - Editar rutina";
            txtNombreRutina.Text = rutina.Nombre;
            txtUsuarioCliente.Text = rutina.NombreUsuarioCliente;
            txtUsuarioCliente.ReadOnly = true;
            dtpFechaInicio.Value = rutina.FechaInicio.ToDateTime(TimeOnly.MinValue);
            dtpFechaFin.Value = rutina.FechaFin.ToDateTime(TimeOnly.MinValue);

            txtEjercicio.Enabled = false;
            nudSeries.Enabled = false;
            nudRepeticiones.Enabled = false;
            nudCarga.Enabled = true;
            btnCambiarCarga.Visible = true;
            btnAgregarEjercicio.Enabled = false;
            btnAsignarRutina.Text = "Guardar cambios";

            foreach (var ejercicio in rutina.Ejercicios)
            {
                lstEjercicios.Items.Add(
                    $"{ejercicio.Nombre} | {ejercicio.Series} series × " +
                    $"{ejercicio.Repeticiones} repeticiones | {ejercicio.CargaKg:F2} kg");
            }
        }

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            string nombre = txtEjercicio.Text.Trim();

            if (nombre.Length == 0 || nudSeries.Value <= 0 || nudRepeticiones.Value <= 0)
            {
                MessageBox.Show("Escribe el nombre del ejercicio y coloca series y repeticiones mayores que cero.");
                return;
            }

            var ejercicio = new EjercicioRutina
            {
                Nombre = nombre,
                Series = (int)nudSeries.Value,
                Repeticiones = (int)nudRepeticiones.Value,
                CargaKg = nudCarga.Value
            };

            ejercicios.Add(ejercicio);
            lstEjercicios.Items.Add(
                $"{ejercicio.Nombre} | {ejercicio.Series} series × " +
                $"{ejercicio.Repeticiones} repeticiones | {ejercicio.CargaKg:F2} kg");

            txtEjercicio.Clear();
            txtEjercicio.Focus();
        }

        private void btnAsignarRutina_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            var rutina = new Rutina
            {
                Nombre = txtNombreRutina.Text,
                NombreUsuarioCliente = txtUsuarioCliente.Text,
                FechaInicio = DateOnly.FromDateTime(dtpFechaInicio.Value),
                FechaFin = DateOnly.FromDateTime(dtpFechaFin.Value),
                Ejercicios = new List<EjercicioRutina>(ejercicios)
            };

            try
            {
                if (idRutinaEditar is Guid id)
                {
                    RutinasController.EditarRutina(
                        entrenadorActual, id, rutina.Nombre, rutina.FechaInicio, rutina.FechaFin);
                }
                else
                {
                    RutinasController.AsignarRutina(entrenadorActual, rutina);
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo completar la asignación. Revisa los archivos de Fit.CR.");
                return;
            }

            MessageBox.Show(idRutinaEditar.HasValue
            ? "Cambios guardados correctamente."
            : "Rutina asignada correctamente.");

            DialogResult = DialogResult.OK;
        }

        private void btnCambiarCarga_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null || idRutinaEditar is not Guid id)
            {
                return;
            }

            int indiceEjercicio = lstEjercicios.SelectedIndex;

            if (indiceEjercicio < 0)
            {
                MessageBox.Show("Selecciona el ejercicio cuya carga quieres cambiar.");
                return;
            }

            try
            {
                var controlador = new RutinasController();

                if (!controlador.CambiarCarga(entrenadorActual, id, indiceEjercicio, nudCarga.Value))
                {
                    MessageBox.Show("El ejercicio ya tiene esa carga.");
                    return;
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo guardar el cambio de carga.");
                return;
            }

            MessageBox.Show("Carga actualizada y guardada en el historial.");
            DialogResult = DialogResult.OK;
        }
    }
}
