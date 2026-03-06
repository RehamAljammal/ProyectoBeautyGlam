using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Tono.EditarTono
{
    public interface IEditarTonoAD
    {
        Task<int> Editar(TonoDTO tonoParaEditar);
    }
}