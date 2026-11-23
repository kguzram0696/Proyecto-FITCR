using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FitCR.Controladores;
using FitCR.Modelos;
using System;

namespace FitCR.Datos
{
    internal static class GeneradorDatosDemo
    {
        public static void GenerarEntrenadores(string carpeta)
        {
            Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, "entrenadores.json");

            if (File.Exists(ruta))
            {
                return;
            }

            var entrenadores = new List<Entrenador>();

            for (int numero = 1; numero <= 10; numero++)
            {
                entrenadores.Add(new Entrenador
                {
                    Nombre = $"Entrenador demo {numero:00}",
                    NombreUsuario = numero == 1
                        ? "entrenador.prueba"
                        : $"entrenador.demo{numero:00}",
                    Tipo = numero % 2 == 0
                        ? TipoEntrenador.Personal
                        : TipoEntrenador.Gimnasio,
                    Credencial = RegistroController.CrearCredencial("DemoFitCR!2026")
                });
            }

            string json = JsonSerializer.Serialize(
                entrenadores, new JsonSerializerOptions { WriteIndented = true });

            using var archivo = new FileStream(ruta, FileMode.CreateNew);
            using var escritor = new StreamWriter(archivo);
            escritor.Write(json);
        }
        public static void GenerarUsuarios(string carpeta)
        {
            Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, "usuarios.json");

            if (File.Exists(ruta))
            {
                return;
            }

            var usuarios = new List<UsuarioBasico>();
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            for (int numero = 1; numero <= 40; numero++)
            {
                int numeroEntrenador = (numero - 1) % 10 + 1;
                decimal pesoInicial = 60m + numero;
                decimal pesoActual = pesoInicial - (numero % 2 == 0 ? 1.5m : 0.5m);
                decimal estatura = 1.55m + (numero % 25) * 0.01m;

                var usuario = new UsuarioBasico
                {
                    Nombre = $"Cliente demo {numero:00}",
                    NombreUsuario = $"cliente.demo{numero:00}",
                    Credencial = RegistroController.CrearCredencial("DemoFitCR!2026"),
                    Edad = 18 + numero % 35,
                    FechaRegistro = hoy.AddDays(-60),
                    PesoKg = pesoActual,
                    EstaturaMetros = estatura,
                    NombreUsuarioEntrenador = numeroEntrenador == 1
                        ? "entrenador.prueba"
                        : $"entrenador.demo{numeroEntrenador:00}"
                };

                for (int dia = 1; dia <= numero % 8; dia++)
                {
                    usuario.Visitas.Add(hoy.AddDays(-dia));
                }

                usuario.Mediciones.Add(new Medicion
                {
                    Fecha = hoy.AddDays(-12),
                    PesoKg = pesoInicial,
                    EstaturaMetros = estatura
                });

                usuario.Mediciones.Add(new Medicion
                {
                    Fecha = hoy.AddDays(-2),
                    PesoKg = pesoActual,
                    EstaturaMetros = estatura
                });

                usuario.Objetivos.Add(new Objetivo
                {
                    Id = Guid.NewGuid(),
                    Tipo = TipoObjetivo.Peso,
                    Direccion = DireccionObjetivo.ComoMaximo,
                    ValorObjetivo = pesoInicial - 1m,
                    FechaInicio = hoy.AddDays(-14),
                    FechaLimite = hoy.AddDays(7)
                });

                usuarios.Add(usuario);
            }

            string json = JsonSerializer.Serialize(
                usuarios, new JsonSerializerOptions { WriteIndented = true });

            using var archivo = new FileStream(ruta, FileMode.CreateNew);
            using var escritor = new StreamWriter(archivo);
            escritor.Write(json);
        }
        public static void GenerarRutinas(string carpeta)
        {
            string ruta = Path.Combine(carpeta, "rutinas.json");

            if (File.Exists(ruta))
            {
                return;
            }

            string jsonUsuarios = File.ReadAllText(Path.Combine(carpeta, "usuarios.json"));
            var usuarios = JsonSerializer.Deserialize<List<UsuarioBasico>>(jsonUsuarios)
                ?? throw new JsonException("No se pudieron leer los usuarios de demostración.");

            string[] catalogo =
            {
        "Sentadilla", "Press de banca", "Remo con mancuerna",
        "Peso muerto rumano", "Plancha", "Press militar",
        "Jalón al pecho", "Zancadas", "Curl de bíceps",
        "Elevación lateral", "Puente de glúteos", "Extensión de tríceps"
    };

            var rutinas = new List<Rutina>();
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            for (int indiceCliente = 0; indiceCliente < usuarios.Count; indiceCliente++)
            {
                var usuario = usuarios[indiceCliente];

                for (int numero = 1; numero <= 5; numero++)
                {
                    DateOnly inicio = hoy.AddDays((numero - 5) * 7);

                    var rutina = new Rutina
                    {
                        Id = Guid.NewGuid(),
                        Nombre = $"Rutina demo {numero:00}",
                        NombreUsuarioCliente = usuario.NombreUsuario,
                        NombreUsuarioEntrenador = usuario.NombreUsuarioEntrenador
                            ?? throw new InvalidOperationException("El cliente demo no tiene entrenador."),
                        FechaAsignacion = inicio,
                        FechaInicio = inicio,
                        FechaFin = inicio.AddDays(6)
                    };

                    for (int posicion = 0; posicion < 3; posicion++)
                    {
                        int indice = (indiceCliente * 7 + numero * 3 + posicion * 5)
                            % catalogo.Length;

                        string nombre = catalogo[indice];
                        decimal carga = nombre == "Plancha"
                            ? 0m
                            : 5m + ((indiceCliente + numero + posicion) % 8) * 2.5m;

                        var ejercicio = new EjercicioRutina
                        {
                            Nombre = nombre,
                            Series = 2 + (numero + posicion) % 3,
                            Repeticiones = nombre == "Plancha" ? 1 : 8 + (indice + numero) % 5,
                            CargaKg = carga
                        };

                        if (numero < 5 && posicion == 0 && carga > 0)
                        {
                            ejercicio.HistorialCargas.Add(new CambioCarga
                            {
                                Fecha = inicio.AddDays(2),
                                CargaAnteriorKg = carga,
                                CargaNuevaKg = carga + 2.5m
                            });

                            ejercicio.CargaKg = carga + 2.5m;
                        }

                        rutina.Ejercicios.Add(ejercicio);
                    }

                    rutinas.Add(rutina);
                }
            }

            string json = JsonSerializer.Serialize(
                rutinas, new JsonSerializerOptions { WriteIndented = true });

            using var archivo = new FileStream(ruta, FileMode.CreateNew);
            using var escritor = new StreamWriter(archivo);
            escritor.Write(json);
        }
    }
}
