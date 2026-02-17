using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.DetallesDeProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.DetallesDeProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.DetallesDeProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyGlam.LogicaDeNegocio.Proveedores.DetallesDeProveedor.DetallesProveedorLN;

namespace BeautyGlam.LogicaDeNegocio.Proveedores.DetallesDeProveedor
{
 
        public class DetallesProveedorLN : IDetallesProveedorLN
        {
            private IDetallesProveedorAD _detallesProveedorAD;
        

            public DetallesProveedorLN()
            {
                _detallesProveedorAD = new DetallesProveedorAD();
             

            }

            public async Task<int> Detalles(ProveedoresDto elProveedorParaGuardar)
            {
                int cantidadDeFilasAfectas = await _detallesProveedorAD.Detalles(elProveedorParaGuardar);
                return cantidadDeFilasAfectas;
            }
        }
    }


