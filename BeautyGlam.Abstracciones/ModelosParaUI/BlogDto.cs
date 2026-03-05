using System;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class BlogDto
    {
        public int id_Blog { get; set; }
        public string titulo { get; set; }
        public string resumen { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public DateTime fecha_Publicacion { get; set; }
        public DateTime? fecha_Actualizacion { get; set; }
        public bool estado { get; set; } = true;
        public List<ComentarioBlogDto> Comentarios { get; set; } = new List<ComentarioBlogDto>();

    }
}