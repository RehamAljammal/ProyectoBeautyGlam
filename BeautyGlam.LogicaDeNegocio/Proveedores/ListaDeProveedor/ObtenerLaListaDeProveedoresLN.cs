using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.ListaDeProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.ListaDeProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Proveedores.ListaDeProveedor
{
    public class ObtenerLaListaDeProveedoresLN : IObtenerListaDeProveedoresAD
    {
        private readonly ObtenerListaDeProveedoresAD _obtenerListaDeProveedoresAD;

        public ObtenerLaListaDeProveedoresLN()
        {
            _obtenerListaDeProveedoresAD = new ObtenerListaDeProveedoresAD();
        }
        public List<ProveedoresDto> Obtener()
        {
            List<ProveedoresDto> laListaDeProveedors = _obtenerListaDeProveedoresAD.Obtener();
            return laListaDeProveedors;
        }


    }
}
