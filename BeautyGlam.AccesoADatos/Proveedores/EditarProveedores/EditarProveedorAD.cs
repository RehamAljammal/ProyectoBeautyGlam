using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EditarProveedores;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeautyGlam.AccesoADatos.Proveedores.EditarProveedores
{
    public class EditarProveedorAD : IEditarProveedorAD
    {
        private Contexto _elContexto;


        public EditarProveedorAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(ProveedoresDto elProveedorParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProveedorAD elProveedorEnBaseDeDatos = await _elContexto.Proveedor
                .FirstOrDefaultAsync(p => p.id == elProveedorParaGuardar.id);

            if (elProveedorEnBaseDeDatos != null)
            {
                elProveedorEnBaseDeDatos.nombre = elProveedorParaGuardar.nombre;
                elProveedorEnBaseDeDatos.cedula = elProveedorParaGuardar.cedula;
                elProveedorEnBaseDeDatos.direccion = elProveedorParaGuardar.direccion;
                elProveedorEnBaseDeDatos.correo = elProveedorParaGuardar.correo;
                elProveedorEnBaseDeDatos.telefono = elProveedorParaGuardar.telefono;
                elProveedorEnBaseDeDatos.estado = elProveedorParaGuardar.estado;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<ProveedoresDto> ObtenerPorId(int id)
        {
            ProveedorAD entidad = await _elContexto.Proveedor.FindAsync(id);

            if (entidad == null)
                return null;

            return new ProveedoresDto
            {
                id = entidad.id,
                nombre = entidad.nombre,
                cedula = entidad.cedula,
                telefono = entidad.telefono,
                direccion = entidad.direccion,
                correo = entidad.correo,
                estado = entidad.estado,
            };
        }
    }
}

