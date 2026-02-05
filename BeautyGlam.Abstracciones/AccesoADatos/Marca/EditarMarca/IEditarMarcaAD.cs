using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Marca.EditarMarca
{
    public interface IEditarMarcaAD
    {
        Task<int> Editar(MarcaDto laMarcaParaGuardar);
        Task<MarcaDto> ObtenerPorId(int id_Marca);

    }
}
