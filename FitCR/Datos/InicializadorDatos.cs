using System;
using System.IO;

namespace FitCR.Datos
{
    internal static class InicializadorDatos
    {
        public static void Preparar()
        {
            string origen = Path.Combine(AppContext.BaseDirectory, "DatosIniciales");

            if (!Directory.Exists(origen))
            {
                return;
            }

            string destino = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FitCR");

            Directory.CreateDirectory(destino);

            string[] archivos =
            {
                "usuarios.json",
                "entrenadores.json",
                "clases.json",
                "rutinas.json"
            };

            foreach (string archivo in archivos)
            {
                string archivoInicial = Path.Combine(origen, archivo);
                string archivoLocal = Path.Combine(destino, archivo);

                if (File.Exists(archivoInicial) && !File.Exists(archivoLocal))
                {
                    File.Copy(archivoInicial, archivoLocal);
                }
            }
        }
    }
}
