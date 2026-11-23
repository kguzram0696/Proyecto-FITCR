using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FitCR.Modelos;

namespace FitCR.Datos
{
    internal class RepositorioEntrenadoresJson
    {
        private readonly string ruta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "FitCR",
            "entrenadores.json");
        public List<Entrenador> Cargar()
        {

            if (!File.Exists(ruta))
            {
                return new List<Entrenador>();
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Entrenador>>(json)
                ?? throw new JsonException("El archivo debe contener una lista de entrenadores.");
        }
        public void Guardar(List<Entrenador> entrenadores)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ruta)!);

            string json = JsonSerializer.Serialize(entrenadores, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }
    }
}
