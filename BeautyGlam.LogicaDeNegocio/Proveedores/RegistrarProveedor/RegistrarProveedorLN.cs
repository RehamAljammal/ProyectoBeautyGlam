using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.RegistrarProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.RegistrarProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.RegistrarProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Proveedores.RegistrarProveedor
{
    public class RegistrarProveedorLN : IRegistrarProveedorLN
    {
        private IRegistrarProveedorAD _registrarProveedorAD;

        public RegistrarProveedorLN()
        {
            _registrarProveedorAD = new RegistrarProveedorAD();
        }

        public async Task<int> Registrar(ProveedoresDto elProveedorParaGuardar)
        {
            int cantidadDeFilasAfectas = await _registrarProveedorAD.Registrar(elProveedorParaGuardar);
            return cantidadDeFilasAfectas;
        }

    }
}
