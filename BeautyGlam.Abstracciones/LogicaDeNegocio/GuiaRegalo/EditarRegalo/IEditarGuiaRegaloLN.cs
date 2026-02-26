using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo
{
    public interface IEditarGuiaRegaloLN
    {
        Task Editar(GuiaRegaloDto dto);
    }
}

