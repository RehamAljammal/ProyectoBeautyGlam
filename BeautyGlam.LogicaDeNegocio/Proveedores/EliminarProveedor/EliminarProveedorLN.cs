using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.EliminarProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.EliminarProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.EliminarProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyGlam.LogicaDeNegocio.Proveedores.EliminarProveedor.EliminarProveedorLN;

namespace BeautyGlam.LogicaDeNegocio.Proveedores.EliminarProveedor
{

        public class EliminarProveedorLN : IEliminarProveedorLN
        {
            private IEliminarProveedorAD _eliminarProveedorAD;

            public EliminarProveedorLN()
            {
                _eliminarProveedorAD = new EliminarProveedorAD();
            }

            public async Task<int> Eliminar(ProveedoresDto elProveedorParaGuardar)
            {

                int cantidadDeFilasAfectas = await _eliminarProveedorAD.Eliminar(elProveedorParaGuardar);
                return cantidadDeFilasAfectas;
            }
        }
    }
