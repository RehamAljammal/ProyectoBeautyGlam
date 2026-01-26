using BeautyGlam.Abstracciones.AccesoADatos.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marcaes.EliminarMarca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyGlam.LogicaDeNegocio.Marca.EliminarMarca.EliminarMarcaLN;

namespace BeautyGlam.LogicaDeNegocio.Marca.EliminarMarca
{
        public class EliminarMarcaLN : IEliminarMarcaLN
        {
            private IEliminarMarcaAD _eliminarMarcaAD;

            public EliminarMarcaLN()
            {
                _eliminarMarcaAD = new EliminarMarcaAD();
            }

            public async Task<int> Eliminar(MarcaDto elMarcaParaGuardar)
            {
                int cantidadDeFilasAfectas = await _eliminarMarcaAD.Eliminar(elMarcaParaGuardar);
                return cantidadDeFilasAfectas;
            }
        }
    }
