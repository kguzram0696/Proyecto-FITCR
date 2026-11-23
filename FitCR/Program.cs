using FitCR.Datos;

namespace FitCR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InicializadorDatos.Preparar();
            Application.Run(new FormInicioSesion());
        }
    }
}