using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FitCR.Modelos;

namespace FitCR.Datos
{
    internal class RepositorioRutinasJson
    {
        private readonly string ruta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "FitCR",
            "rutinas.json");

        public List<Rutina> Cargar()
        {

            if (!File.Exists(ruta))
            {
                return new List<Rutina>();
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Rutina>>(json)
                ?? throw new JsonException("El archivo debe contener una lista de rutinas.");
        }

        public void Guardar(List<Rutina> rutinas)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ruta)!);

            string json = JsonSerializer.Serialize(rutinas, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }
    }
}
