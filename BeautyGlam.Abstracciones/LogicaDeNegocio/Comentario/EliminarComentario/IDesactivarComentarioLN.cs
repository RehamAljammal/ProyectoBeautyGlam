using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.Comentarios.DesactivarComentario
{
    public interface IDesactivarComentarioLN
    {
        Task<int> Desactivar(int idComentario);
    }
}
