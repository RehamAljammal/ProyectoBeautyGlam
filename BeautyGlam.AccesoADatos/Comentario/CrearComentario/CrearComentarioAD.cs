using BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.CrearComentario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class CrearComentarioAD : ICrearComentarioAD
    {
        private Contexto _elContexto;

        public CrearComentarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Crear(ComentarioBlogDto comentarioParaGuardar)
        {
            var entidad = new ComentarioBlogAD
            {
                id_Blog = comentarioParaGuardar.id_Blog,
                id_Usuario = comentarioParaGuardar.id_Usuario,
                comentario = comentarioParaGuardar.comentario,
                estado = true
            };

            _elContexto.ComentarioBlog.Add(entidad); // <-- coincide con DbSet
            return await _elContexto.SaveChangesAsync();
        }
    }
}
