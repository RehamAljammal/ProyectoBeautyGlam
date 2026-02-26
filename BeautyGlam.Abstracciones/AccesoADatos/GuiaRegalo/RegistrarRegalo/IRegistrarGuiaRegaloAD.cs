using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.RegistrarGuiaRegalo
{
    public interface IRegistrarGuiaRegaloAD
    {
        Task<int> Registrar(GuiaRegaloDto elRegaloParaGuardar);
    }
}
