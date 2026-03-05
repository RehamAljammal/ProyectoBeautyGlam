using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.DesactivarComentario
{
    public interface IDesactivarComentarioAD
    {
        Task<int> Desactivar(int idComentario);
    }
}