using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.CrearComentario
{
    public interface ICrearComentarioAD
    {
        Task<int> Crear(ComentarioBlogDto comentarioParaGuardar);
    }
}