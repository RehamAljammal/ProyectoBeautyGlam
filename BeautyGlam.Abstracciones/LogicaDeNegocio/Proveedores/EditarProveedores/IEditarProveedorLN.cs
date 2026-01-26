using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.EditarProveedores
{
    public interface IEditarProveedorLN
    {
        Task<int> Editar(ProveedoresDto elProveedorParaGuardar);

        Task<ProveedoresDto> ObtenerPorId(int id);

    }
}
