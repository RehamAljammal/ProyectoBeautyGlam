using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EditarProveedores;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
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
            ProveedorAD elProveedorEnBaseDeDatos = _elContexto.Proveedor
                .Where(ProveedorABuscar =>
                ProveedorABuscar.id == elProveedorParaGuardar.id).FirstOrDefault();

            if (elProveedorEnBaseDeDatos != null)
            {
                elProveedorEnBaseDeDatos.nombre = elProveedorParaGuardar.nombre;
                elProveedorEnBaseDeDatos.cedula = elProveedorParaGuardar.cedula;
                elProveedorEnBaseDeDatos.direccion = elProveedorParaGuardar.direccion;
                elProveedorEnBaseDeDatos.correo = elProveedorParaGuardar.correo;
                elProveedorEnBaseDeDatos.telefono = elProveedorParaGuardar.telefono;
                elProveedorEnBaseDeDatos.estado = elProveedorParaGuardar.estado;

            }

            return cantidadDeFilasAfectadas;
        }

    }
}

