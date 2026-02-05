using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.DetallesDeProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Proveedores.DetallesDeProveedor
{
    public class DetallesProveedorAD : IDetallesProveedorAD
    {
        private readonly Contexto _elContexto;

        public DetallesProveedorAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Detalles(ProveedoresDto elProveedorParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProveedorAD elProveedorEnBaseDeDatos = _elContexto.Proveedor
                .FirstOrDefault(ProveedorABuscar => ProveedorABuscar.id == elProveedorParaGuardar.id);

            return cantidadDeFilasAfectadas;
        }
    }
}

