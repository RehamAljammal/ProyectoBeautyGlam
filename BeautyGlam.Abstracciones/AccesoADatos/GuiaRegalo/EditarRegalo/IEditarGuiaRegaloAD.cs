using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EditarGuiaRegalo
{
    public interface IEditarGuiaRegaloAD
    {
        Task Editar(GuiaRegaloDto dto);
    }
}

