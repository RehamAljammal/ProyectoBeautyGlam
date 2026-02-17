using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EliminarGuiaRegalo
{
    public interface IEliminarGuiaRegaloLN
    {
        Task<int> Eliminar(GuiaRegaloDto laGuiaParaEliminar);
    }
}

