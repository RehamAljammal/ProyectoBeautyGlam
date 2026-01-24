using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EditarProveedores
{
    public interface IEditarProveedorAD
    {
        Task<int> Editar(ProveedoresDto elProveedorParaGuardar);

   
    }
}
