using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Marca.ActivarDesactivar
{
    public interface IActivarDesactivarMarcaAD
    {
        Task<int> ActivarDesactivar(MarcaDto marca);
    }
}