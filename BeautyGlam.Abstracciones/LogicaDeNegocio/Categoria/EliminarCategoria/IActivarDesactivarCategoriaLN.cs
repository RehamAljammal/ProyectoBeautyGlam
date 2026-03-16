using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.ActivarDesactivar
{
    public interface IActivarDesactivarCategoriaLN
    {
        Task<int> ActivarDesactivar(CategoriasDto categoria);
    }
}