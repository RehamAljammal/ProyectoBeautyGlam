using BeautyGlam.Abstracciones.AccesoADatos.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Marcaes.EliminarMarca
{
    public class EliminarMarcaAD : IEliminarMarcaAD
    {
        private readonly Contexto _elContexto;

        public EliminarMarcaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(MarcaDto laMarcaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            MarcaAD laMarcaEnBaseDeDatos = _elContexto.Marca
                .FirstOrDefault(MarcaABuscar => MarcaABuscar.id_Marca == laMarcaParaGuardar.id_Marca);

            if (laMarcaEnBaseDeDatos != null)
            {
                _elContexto.Marca.Remove(laMarcaEnBaseDeDatos);
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }
    }
}