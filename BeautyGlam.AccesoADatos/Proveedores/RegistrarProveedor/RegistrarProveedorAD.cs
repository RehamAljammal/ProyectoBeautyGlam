using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.RegistrarProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Proveedores.RegistrarProveedor
{
    public class RegistrarProveedorAD : IRegistrarProveedorAD
    {
        private Contexto _elContexto;

        public RegistrarProveedorAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ProveedoresDto elProveedorParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;
            ProveedorAD elProveedorEnEntidad = ConvierteObjetoAEntidad(elProveedorParaGuardar);
            _elContexto.Proveedor.Add(elProveedorEnEntidad);
            cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;
        }
        private ProveedorAD ConvierteObjetoAEntidad(ProveedoresDto elProveedorParaGuardar)
        {
            return new ProveedorAD
            {
                id = elProveedorParaGuardar.id,
                cedula = elProveedorParaGuardar.cedula,
                nombre = elProveedorParaGuardar.nombre,
                direccion = elProveedorParaGuardar.direccion,
                telefono = elProveedorParaGuardar.telefono,
                correo = elProveedorParaGuardar.correo,
                estado = elProveedorParaGuardar.estado

            };

        }
    }
}
