using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EliminarProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Proveedores.EliminarProveedor
{
    public class EliminarProveedorAD : IEliminarProveedorAD
    {
        private readonly Contexto _elContexto;

        public EliminarProveedorAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(ProveedoresDto elProveedorParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProveedorAD elProveedorEnBaseDeDatos = _elContexto.Proveedor
                .FirstOrDefault(ProveedorABuscar => ProveedorABuscar.id == elProveedorParaGuardar.id);

            if (elProveedorEnBaseDeDatos != null)
            {
                _elContexto.Proveedor.Remove(elProveedorEnBaseDeDatos);
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }
    }
}