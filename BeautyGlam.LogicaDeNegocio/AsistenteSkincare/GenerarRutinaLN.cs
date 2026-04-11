using BeautyGlam.Abstracciones.LogicaDeNegocio.AsistenteSkincare;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.AsistenteSkincare
{
    public class GenerarRutinaLN : IGenerarRutinaLN
    {
        private readonly ObtenerLaListaDeProductosLN _productosLN;

        public GenerarRutinaLN()
        {
            _productosLN = new ObtenerLaListaDeProductosLN();
        }

        private int CalcularScore(ProductosDTO p, RespuestasSkincareDTO respuestas,
            Dictionary<string, List<string>> keywordsProblemas,
            Dictionary<string, List<string>> keywordsObjetivos,
            Dictionary<string, List<string>> keywordsSensibilidad)
        {
            int score = 0;

            var nombre = p.nombre?.ToLower() ?? "";
            var descripcion = p.descripcion?.ToLower() ?? "";

            if (respuestas.problema != null && respuestas.problema.Any())
            {
                foreach (var prob in respuestas.problema)
                {
                    if (keywordsProblemas.ContainsKey(prob))
                    {
                        if (keywordsProblemas[prob]
                            .Any(k => nombre.Contains(k) || descripcion.Contains(k)))
                        {
                            score += 3;
                        }
                    }
                }
            }

            if (respuestas.objetivo != null && respuestas.objetivo.Any())
            {
                foreach (var obj in respuestas.objetivo)
                {
                    if (keywordsObjetivos.ContainsKey(obj))
                    {
                        if (keywordsObjetivos[obj]
                            .Any(k => nombre.Contains(k) || descripcion.Contains(k)))
                        {
                            score += 2;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(respuestas.sensibilidad) &&
                    keywordsSensibilidad.ContainsKey(respuestas.sensibilidad))
            {
                if (keywordsSensibilidad[respuestas.sensibilidad]
                    .Any(k => nombre.Contains(k) || descripcion.Contains(k)))
                {
                    score += 1;
                }
            }

            return score;
        }

        private ProductosDTO ElegirMejorProducto(
            List<ProductosDTO> disponibles,
            Func<ProductosDTO, bool> filtroCategoria,
            RespuestasSkincareDTO respuestas,
            Dictionary<string, List<string>> keywordsProblemas,
            Dictionary<string, List<string>> keywordsObjetivos,
            Dictionary<string, List<string>> keywordsSensibilidad)
        {
            var candidatos = disponibles
                .Where(filtroCategoria)
                .Select(p => new
                {
                    Producto = p,
                    Score = CalcularScore(p, respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad)
                })
                .OrderByDescending(x => x.Score)
                .ToList();

            var mejor = candidatos.FirstOrDefault()?.Producto;

            if (mejor != null)
                disponibles.Remove(mejor);

            return mejor;
        }

        public RutinaDTO Generar(RespuestasSkincareDTO respuestas)
        {
            var productos = _productosLN.Obtener();

            var filtrados = productos
            .Where(p => p.tipoPiel.ToLower() == respuestas.tipoPiel.ToLower())
            .ToList();

            if (!filtrados.Any())
            {
                filtrados = productos.ToList();
            }


            filtrados = filtrados
            .Where(p => !string.IsNullOrWhiteSpace(p.nombre) &&
            !string.IsNullOrWhiteSpace(p.descripcion))
            .ToList();

            var keywordsProblemas = new Dictionary<string, List<string>>
            {
                { "acne", new List<string> { "acne","acné","antiacne", "anti-acne", "granitos","espinillas","puntos negros","sebo","grasa", "piel grasa", "oil","poros", "poros obstruidos", "poros dilatados", "acido salicilico",
                        "niacinamida", "tea tree", "control grasa","imperfecciones" } },
                { "manchas", new List<string> {"manchas","hiperpigmentacion",
                     "hiperpigmentación",
                     "tono desigual",
                     "aclarante",
                     "iluminador",
                     "vitamina c",
                     "antimanchas",
                     "despigmentante",
                     "melasma",
                     "luminosidad",
                     "radiancia",
                     "acido glicolico",
                     "niacinamida"
                    }
                },
                { "arrugas", new List<string>
                    {
                        "arrugas",
                        "lineas",
                        "lineas de expresion",
                        "lineas finas",
                        "anti edad",
                        "antiedad",
                        "reafirmante",
                        "lifting",
                        "colageno",
                        "colágeno",
                        "retinol",
                        "retinoide",
                        "acido hialuronico",
                        "elasticidad",
                        "rejuvenecedor"
                    }
                },
                { "resequedad", new List<string>
                    {
                        "piel seca",
                        "resequedad",
                        "seco",
                        "hidratante",
                        "hidratacion",
                        "hidratación",
                        "humectante",
                        "nutritivo",
                        "nutricion",
                        "nutrición",
                        "suavizante",
                        "reparador",
                        "acido hialuronico",
                        "ceramidas",
                        "glicerina",
                        "aloe",
                        "manteca de karite"
                    }
                }
            };

            var keywordsObjetivos = new Dictionary<string, List<string>>
            {
                { "grasa", new List<string>
                    {
                        "control grasa",
                        "matificante",
                        "anti brillo",
                        "sin brillo",
                        "piel grasa",
                        "sebo",
                        "poros",
                        "niacinamida",
                        "libre de aceite"
                    }
                },

                { "hidratar", new List<string>
                    {
                        "hidratante",
                        "hidratacion",
                        "humectante",
                        "acido hialuronico",
                        "hialuronico",
                        "nutricion",
                        "suavidad",
                        "suave",
                        "luminosidad",
                        "frescura"
                    }
                },

                { "imperfecciones", new List<string>
                    {
                        "imperfecciones",
                        "acne",
                        "acné",
                        "granitos",
                        "espinillas",
                        "puntos negros",
                        "poros",
                        "antiacne",
                        "salicilico",
                        "niacinamida"
                    }
                },

                { "antiedad", new List<string>
                    {
                        "anti edad",
                        "antiedad",
                        "rejuvenecedor",
                        "rejuvenecimiento",
                        "arrugas",
                        "lineas finas",
                        "lifting",
                        "reafirmante",
                        "colageno",
                        "retinol",
                        "elasticidad"
                    }
                }
            };

            var keywordsSensibilidad = new Dictionary<string, List<string>>
            {
                { "Alta", new List<string>
                    {
                        "piel sensible",
                        "hipoalergenico",
                        "hipoalergénico",
                        "sin fragancia",
                        "sin alcohol",
                        "suave",
                        "calmante",
                        "aloe",
                        "avena",
                        "centella asiatica"
                    }
                },

                { "Media", new List<string>
                    {
                        "suave",
                        "equilibrado",
                        "piel normal",
                        "sin irritacion"
                    }
                },

                { "Baja", new List<string>
                    {
                        "tratamiento",
                        "activo",
                        "activos",
                        "exfoliante",
                        "peeling",
                        "acido glicolico",
                        "acido salicilico",
                        "retinol"
                    }
                }
            };

            var keywordsFrecuencia = new Dictionary<string, List<string>>
            {
                { "Semanal", new List<string>
                    {
                        "mascarilla",
                        "tratamiento",
                        "exfoliante",
                        "peeling",
                        "intensivo"
                    }
                },

                { "Diario", new List<string>
                    {
                        "uso diario",
                        "suave",
                        "hidratante",
                        "protector",
                        "protector solar",
                        "limpiador",
                        "tonico"
                    }
                }
            };

            if (!string.IsNullOrEmpty(respuestas.frecuencia))
            {
                var frecuencia = respuestas.frecuencia;

                switch (frecuencia)
                {
                    case "Nunca":
                        filtrados = filtrados
                            .Where(p =>
                                !p.descripcion.ToLower().Contains("exfoliante") &&
                                !p.descripcion.ToLower().Contains("peeling") &&
                                !p.descripcion.ToLower().Contains("acido") &&
                                !p.descripcion.ToLower().Contains("retinol")
                            )
                            .Take(5)
                            .ToList();
                        break;

                    default:
                        if (keywordsFrecuencia.ContainsKey(frecuencia))
                        {
                            filtrados = filtrados.Where(p =>
                                keywordsFrecuencia[frecuencia].Any(k =>
                                    p.descripcion.ToLower().Contains(k) ||
                                    p.nombre.ToLower().Contains(k)
                                )
                            ).ToList();
                        }
                        break;
                }
            }
            ;

            var disponibles = filtrados.ToList();

            var limpieza = ElegirMejorProducto(
                disponibles,
                p => (p.nombre?.ToLower().Contains("limpiador") ?? false) ||
                     (p.descripcion?.ToLower().Contains("limpiador") ?? false),
                respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad);

            var tonico = ElegirMejorProducto(
                disponibles,
                p => (p.nombre?.ToLower().Contains("tonico") ?? false) ||
                     (p.descripcion?.ToLower().Contains("tonico") ?? false),
                respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad);

            var serum = ElegirMejorProducto(
                disponibles,
                p => (p.nombre?.ToLower().Contains("serum") ?? false) ||
                     (p.descripcion?.ToLower().Contains("serum") ?? false),
                respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad);

            var hidratante = ElegirMejorProducto(
                disponibles,
                p => (p.nombre?.ToLower().Contains("crema") ?? false) ||
                     (p.descripcion?.ToLower().Contains("hidratante") ?? false),
                respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad);

            var protector = ElegirMejorProducto(
                disponibles,
                p => (p.nombre?.ToLower().Contains("protector") ?? false) ||
                     (p.descripcion?.ToLower().Contains("protector") ?? false),
                respuestas, keywordsProblemas, keywordsObjetivos, keywordsSensibilidad);

            return new RutinaDTO
            {
                Limpieza = limpieza,
                Tonico = tonico,
                Serum = serum,
                Hidratante = hidratante,
                ProtectorSolar = protector
            };
        }
    }
}