using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EditarProveedores;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.EditarProveedores;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.EditarProveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Proveedores.EditarProveedores
{
    public class EditarProveedorLN : IEditarProveedorLN
    {
        private IEditarProveedorAD _editarProveedorAD;

        public EditarProveedorLN()
        {
            _editarProveedorAD = new EditarProveedorAD();

        }

        public async Task<int> Editar(ProveedoresDto elProveedorParaGuardar)
        {

            int cantidadDeFilasAfectas = await _editarProveedorAD.Editar(elProveedorParaGuardar);
            return cantidadDeFilasAfectas;
        }
    }


}

