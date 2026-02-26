using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EliminarGuiaRegalo
{
    public interface IEliminarGuiaRegaloAD
    {
        Task<int> Eliminar(GuiaRegaloDto laGuiaParaEliminar);
    }
}
