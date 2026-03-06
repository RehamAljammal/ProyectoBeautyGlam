using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.Comentarios.CrearComentario
{
    public interface ICrearComentarioLN
    {
        Task<int> Crear(ComentarioBlogDto comentarioParaGuardar);
    }
}
