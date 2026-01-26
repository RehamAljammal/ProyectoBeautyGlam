using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.ListaDeProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Proveedores.ListaDeProveedor
{
    public class ObtenerListaDeProveedoresAD : IObtenerListaDeProveedoresAD
    {
        private Contexto _elContexto;

        public ObtenerListaDeProveedoresAD()
        {
            _elContexto = new Contexto();
        }

        public List<ProveedoresDto> Obtener()
        {
            List<ProveedoresDto> laListaDeProveedor =
                (from Proveedor in _elContexto.Proveedor
                 where Proveedor.estado == true
                 select new ProveedoresDto
                 {
                     id = Proveedor.id,
                     cedula = Proveedor.cedula,
                     nombre = Proveedor.nombre,
                     direccion = Proveedor.direccion,
                     telefono = Proveedor.telefono,
                     correo = Proveedor.correo,
                     estado = Proveedor.estado
                 }).ToList();

            return laListaDeProveedor;
        }


        public List<ProveedoresDto> ObtenerTodos()
        {
            List<ProveedoresDto> laListaDeProveedor =
                (from Proveedor in _elContexto.Proveedor
                 select new ProveedoresDto
                 {
                     id = Proveedor.id,
                     cedula = Proveedor.cedula,
                     nombre = Proveedor.nombre,
                     direccion = Proveedor.direccion,
                     telefono = Proveedor.telefono,
                     correo = Proveedor.correo,
                     estado = Proveedor.estado
                 }).ToList();

            return laListaDeProveedor;
        }

    }
}
