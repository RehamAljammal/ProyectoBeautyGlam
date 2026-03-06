using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ComentarioBlogDto
    {
        public int id_Comentario { get; set; }
        public int id_Blog { get; set; }
        public int id_Usuario { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; } = true;
        public string nombreUsuario { get; set; }
    }
}