using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Categoria.ActivarDesactivar
{
    public interface IActivarDesactivarCategoriaAD
    {
        Task<int> ActivarDesactivar(CategoriasDto categoria);
    }
}