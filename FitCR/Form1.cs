using FitCR.Modelos;
using FitCR.Controladores;
using System.IO;
using System.Text.Json;

namespace FitCR
{
    public partial class Form1 : Form
    {
        private readonly RegistroController? registro;

        public Form1()
        {
            InitializeComponent();

            try
            {
                registro = new RegistroController();
            }
            catch (JsonException)
            {
                btnRegistrar.Enabled = false;
                MessageBox.Show("El archivo usuarios.json tiene un formato inválido. El registro está deshabilitado.");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                btnRegistrar.Enabled = false;
                MessageBox.Show("No se pudo leer usuarios.json. El registro está deshabilitado.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (registro is null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Escribe el nombre y el nombre de usuario.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Escribe una contraseña.");
                return;
            }
            var usuario = new UsuarioBasico
            {
                Nombre = txtNombre.Text,
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Edad = (int)nudEdad.Value,
                PesoKg = nudPeso.Value,
                EstaturaMetros = nudEstatura.Value
            };

            if (usuario.Edad <= 0)
            {
                MessageBox.Show("La edad debe ser mayor que cero.");
                return;
            }

            decimal? imc = usuario.CalcularImc();

            if (imc is null)
            {
                MessageBox.Show("El peso y la estatura deben ser mayores que cero.");
                return;
            }

            try
            {
                if (!registro.IntentarRegistrar(usuario, txtContrasena.Text))
                {
                    MessageBox.Show("Ese nombre de usuario ya está registrado.");
                    return;
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("No se pudo comprobar el nombre de usuario. Revisa entrenadores.json.");
                return;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show("No se pudo guardar el usuario. Revisa el acceso al archivo e inténtalo de nuevo.");
                return;
            }

            MessageBox.Show(
                $"Usuario: {usuario.NombreUsuario}\n" +
                $"Edad: {usuario.Edad} años\n" +
                $"Peso: {usuario.PesoKg:F2} kg\n" +
                $"Estatura: {usuario.EstaturaMetros:F2} m\n" +
                $"IMC: {imc.Value:F2}");
        }
    }
}
