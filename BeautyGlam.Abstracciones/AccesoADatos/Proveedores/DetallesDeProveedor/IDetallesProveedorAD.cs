using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Proveedores.DetallesDeProveedor
{
    public interface IDetallesProveedorAD
    {
        Task<int> Detalles(ProveedoresDto elProveedorParaGuardar);

    }
}
