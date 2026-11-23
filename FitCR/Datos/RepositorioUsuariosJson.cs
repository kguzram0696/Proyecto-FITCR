using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FitCR.Modelos;

namespace FitCR.Datos
{
    internal class RepositorioUsuariosJson
    {
        private readonly string rutaArchivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "FitCR",
            "usuarios.json");
        public void Guardar(List<UsuarioBasico> usuarios)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo)!);

            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }
        public List<UsuarioBasico> Cargar()
        {

            if (!File.Exists(rutaArchivo))
            {
                return new List<UsuarioBasico>();
            }

            string json = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<UsuarioBasico>>(json)
                ?? throw new JsonException("El archivo debe contener una lista de usuarios.");
        }
    }
}
