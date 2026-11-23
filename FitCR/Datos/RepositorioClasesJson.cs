using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FitCR.Modelos;

namespace FitCR.Datos
{
    internal class RepositorioClasesJson
    {
        private readonly string ruta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FitCR",
                "clases.json");
        public List<ClaseGimnasio> Cargar()
        {
            string json = File.ReadAllText(ruta);

            return JsonSerializer.Deserialize<List<ClaseGimnasio>>(json)
                ?? throw new JsonException("El archivo debe contener una lista de clases.");
        }
    }
}
