using System;
using System.Collections.Generic;
using System.Linq;
using FitCR.Modelos;
using FitCR.Datos;
using System.Security.Cryptography;

namespace FitCR.Controladores
{
    internal class RegistroController
    {
        private readonly RepositorioUsuariosJson repositorio = new();
        private List<UsuarioBasico> usuarios;

        public RegistroController()
        {
            usuarios = repositorio.Cargar();
        }

        public bool IntentarRegistrar(UsuarioBasico usuario, string contrasena)
        {
            bool existe = usuarios.Any(registrado =>
                string.Equals(registrado.NombreUsuario, usuario.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (existe)
            {
                return false;
            }
            var repositorioEntrenadores = new RepositorioEntrenadoresJson();

            bool existeEntrenador = repositorioEntrenadores.Cargar().Any(entrenador =>
                string.Equals(entrenador.NombreUsuario, usuario.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase));

            if (existeEntrenador)
            {
                return false;
            }
            usuario.Credencial = CrearCredencial(contrasena);
            usuario.FechaRegistro = DateOnly.FromDateTime(DateTime.Today);
            var usuariosActualizados = new List<UsuarioBasico>(usuarios);
            usuariosActualizados.Add(usuario);

            repositorio.Guardar(usuariosActualizados);
            usuarios = usuariosActualizados;

            return true;
        }
        internal static string CrearCredencial(string contrasena)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                contrasena, sal, 600_000, HashAlgorithmName.SHA256, 32);

            return $"{Convert.ToBase64String(sal)}:{Convert.ToBase64String(hash)}";
        }
        public UsuarioBasico? VerificarCredenciales(string nombreUsuario, string contrasena)
        {
            UsuarioBasico? usuario = usuarios.FirstOrDefault(registrado =>
                string.Equals(registrado.NombreUsuario, nombreUsuario.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            return CoincideContrasena(usuario, contrasena) ? usuario : null;
        }

        public bool IntentarAsignarEntrenador(Entrenador entrenador, string nombreUsuario)
        {
            var usuario = usuarios.FirstOrDefault(registrado =>
                string.Equals(registrado.NombreUsuario, nombreUsuario.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (usuario is null ||
                !string.IsNullOrWhiteSpace(usuario.NombreUsuarioEntrenador))
            {
                return false;
            }

            string? asignacionAnterior = usuario.NombreUsuarioEntrenador;
            usuario.NombreUsuarioEntrenador = entrenador.NombreUsuario;

            try
            {
                repositorio.Guardar(usuarios);
            }
            catch
            {
                usuario.NombreUsuarioEntrenador = asignacionAnterior;
                throw;
            }

            return true;
        }
        public static Entrenador? BuscarEntrenadorAsignado(UsuarioBasico usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuarioEntrenador))
            {
                return null;
            }

            var repositorioEntrenadores = new RepositorioEntrenadoresJson();

            return repositorioEntrenadores.Cargar().FirstOrDefault(entrenador =>
                string.Equals(entrenador.NombreUsuario, usuario.NombreUsuarioEntrenador,
                    StringComparison.OrdinalIgnoreCase));
        }
        public static Entrenador? VerificarCredencialesEntrenador(string nombreUsuario, string contrasena)
        {
            var repositorioEntrenadores = new RepositorioEntrenadoresJson();

            Entrenador? entrenador = repositorioEntrenadores.Cargar().FirstOrDefault(registrado =>
                string.Equals(registrado.NombreUsuario, nombreUsuario.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            return CoincideContrasena(entrenador, contrasena) ? entrenador : null;
        }

        private static bool CoincideContrasena(Cuenta? cuenta, string contrasena)
        {
            if (cuenta?.Credencial is not string credencial)
            {
                return false;
            }

            string[] partes = credencial.Split(':');
            if (partes.Length != 2)
            {
                return false;
            }

            try
            {
                byte[] sal = Convert.FromBase64String(partes[0]);
                byte[] hashGuardado = Convert.FromBase64String(partes[1]);

                byte[] hashIngresado = Rfc2898DeriveBytes.Pbkdf2(
                    contrasena, sal, 600_000, HashAlgorithmName.SHA256, 32);

                return CryptographicOperations.FixedTimeEquals(hashIngresado, hashGuardado);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
