using BeautyGlam.Abstracciones.AccesoADatos.Blog.CrearBlog;
using BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.CrearComentario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Blog;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class CrearComentarioLN : ICrearComentarioAD
    {
        private readonly CrearComentarioAD _crearComentarioAD;

        public CrearComentarioLN()
        {
            _crearComentarioAD = new CrearComentarioAD();
        }

        public async Task<int> Crear(ComentarioBlogDto comentarioParaGuardar)
        {
            return await _crearComentarioAD.Crear(comentarioParaGuardar);
        }
    }
}