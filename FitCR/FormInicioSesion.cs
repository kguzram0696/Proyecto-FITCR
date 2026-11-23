using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FitCR.Controladores;
using System.IO;
using System.Text.Json;

namespace FitCR
{
    public partial class FormInicioSesion : Form
    {
        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Escribe tu nombre de usuario y tu contraseña.");
                return;
            }

            try
            {
                var registro = new RegistroController();
                string nombreUsuario = txtNombreUsuario.Text;
                string contrasena = txtContrasena.Text;

                var usuario = registro.VerificarCredenciales(nombreUsuario, contrasena);
                if (usuario is not null)
                {
                    txtContrasena.Clear();

                    using var menuUsuario = new FormMenuUsuario();
                    menuUsuario.Text = $"FitCR - Bienvenido, {usuario.Nombre}";
                    var entrenadorAsignado = RegistroController.BuscarEntrenadorAsignado(usuario);
                    menuUsuario.MostrarUsuario(usuario, entrenadorAsignado?.Nombre);
                    menuUsuario.ShowDialog(this);
                    return;
                }

                var entrenador = RegistroController.VerificarCredencialesEntrenador(nombreUsuario, contrasena);
                if (entrenador is not null)
                {
                    txtContrasena.Clear();

                    using var menuEntrenador = new FormMenuEntrenador();
                    menuEntrenador.MostrarEntrenador(entrenador);
                    menuEntrenador.ShowDialog(this);
                    return;
                }

                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                MessageBox.Show("No se pudieron cargar las cuentas. Revisa los archivos JSON de FitCR.");
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            using var formularioRegistro = new Form1();
            formularioRegistro.ShowDialog(this);
        }
    }
}
