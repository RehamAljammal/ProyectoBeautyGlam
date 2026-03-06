using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Tono.DesactivarTono
{
    public interface IDesactivarTonoAD
    {
        Task<int> Desactivar(int idTono);
    }
}