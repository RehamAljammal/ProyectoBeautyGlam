using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Proveedores.ObtenerProveedorPorID
{
    public class ObtenerProveedorPorIdAD
    {
        private Contexto _elContexto;
        public ObtenerProveedorPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public ProveedoresDto Obtener(int idDelProveedorABuscar)
        {
            ProveedoresDto elProveedorEnBaseDeDatos = (from Proveedor in _elContexto.Proveedor
                                                 where Proveedor.id == idDelProveedorABuscar
                                                 select new ProveedoresDto
                                                 {
                                                     id = Proveedor.id,
                                                     cedula = Proveedor.cedula,
                                                     nombre = Proveedor.nombre,
                                                     direccion = Proveedor.direccion,
                                                     telefono = Proveedor.telefono,
                                                     correo = Proveedor.correo,
                                                     estado = Proveedor.estado
 
                                                 }).FirstOrDefault();
            return elProveedorEnBaseDeDatos;
        }
    }
}
