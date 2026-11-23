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
    public partial class FormMenuEntrenador : Form
    {
        private Entrenador? entrenadorActual;
        public FormMenuEntrenador()
        {
            InitializeComponent();
        }
        internal void MostrarEntrenador(Entrenador entrenador)
        {
            entrenadorActual = entrenador;
            Text = $"FitCR - Menú de entrenador - {entrenador.Nombre}";

            string tipo = entrenador.Tipo == TipoEntrenador.Personal
                ? "Personal"
                : "Del gimnasio";

            lblTipoEntrenador.Text = $"Tipo de entrenador: {tipo}";
        }

        private void btnAsignarUsuario_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            string nombreUsuario = txtUsuarioAsignar.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MessageBox.Show("Escribe el nombre de usuario que quieres asignar.");
                return;
            }

            try
            {
                var registro = new RegistroController();

                if (!registro.IntentarAsignarEntrenador(entrenadorActual, nombreUsuario))
                {
                    MessageBox.Show("El usuario no existe o ya tiene un entrenador asignado.");
                    return;
                }

                MessageBox.Show("Usuario asignado correctamente.");
                txtUsuarioAsignar.Clear();
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo completar la asignación. Revisa el archivo de usuarios.");
            }
        }

        private void btnAbrirAsignarRutina_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            using var formularioRutina = new FormAsignarRutina(entrenadorActual);
            formularioRutina.ShowDialog(this);
        }

        private void btnVerRutinasAsignadas_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            try
            {
                var rutinas = RutinasController.ConsultarRutinasEntrenador(entrenadorActual);

                lstRutinasEntrenador.DisplayMember = nameof(Rutina.Nombre);
                lstRutinasEntrenador.DataSource = rutinas;

                if (rutinas.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes rutinas asignadas.");
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar las rutinas asignadas.");
            }
        }

        private void btnEditarRutina_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null || lstRutinasEntrenador.SelectedItem is not Rutina rutina)
            {
                MessageBox.Show("Selecciona la rutina que quieres editar.");
                return;
            }

            using var formularioRutina = new FormAsignarRutina(entrenadorActual, rutina);

            if (formularioRutina.ShowDialog(this) == DialogResult.OK)
            {
                btnVerRutinasAsignadas.PerformClick();
            }
        }

        private void btnRetirarRutina_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null || lstRutinasEntrenador.SelectedItem is not Rutina rutina)
            {
                MessageBox.Show("Selecciona la rutina que quieres retirar.");
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Quieres retirar «{rutina.Nombre}»?",
                "Retirar rutina",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                RutinasController.RetirarRutina(entrenadorActual, rutina.Id);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo retirar la rutina. Revisa los archivos de Fit.CR.");
                return;
            }

            MessageBox.Show("Rutina retirada correctamente.");
            btnVerRutinasAsignadas.PerformClick();
        }

        private void btnVerAvisosEntrenador_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            try
            {
                var controlador = new AvisosEntrenadorController();
                var avisos = controlador.ActualizarYConsultar(entrenadorActual.NombreUsuario);

                lstAvisosEntrenador.Items.Clear();

                foreach (var aviso in avisos)
                {
                    lstAvisosEntrenador.Items.Add($"{aviso.Fecha:dd/MM/yyyy} | {aviso.Mensaje}");
                }

                if (avisos.Count == 0)
                {
                    MessageBox.Show("Todavía no tienes avisos.");
                }
            }
            catch (Exception ex) when (
                ex is InvalidOperationException or IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar los avisos del entrenador.");
            }
        }

        private void btnProgramarMedicion_Click(object sender, EventArgs e)
        {
            if (entrenadorActual is null)
            {
                return;
            }

            DateOnly fecha = DateOnly.FromDateTime(dtpProximaMedicion.Value);

            try
            {
                MedicionesController.ProgramarMedicion(entrenadorActual, txtClienteMedicion.Text, fecha);
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudo guardar la fecha de la medición.");
                return;
            }

            MessageBox.Show($"Medición programada para el {fecha:dd/MM/yyyy}.");
        }

        private void lstRutinasEntrenador_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Rutina rutina)
            {
                e.Value = $"{rutina.Nombre} | {rutina.NombreUsuarioCliente}";
            }
        }
    }
}
