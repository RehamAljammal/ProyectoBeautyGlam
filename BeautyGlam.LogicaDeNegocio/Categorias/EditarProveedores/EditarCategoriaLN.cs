using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EditarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.EditarCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Categorias.EditarCategorias
{
     public class EditarCategoriaLN : IEditarCategoriaLN
    {
        private EditarCategoriaAD _editarCategoriaAD;

        public EditarCategoriaLN()
        {
            _editarCategoriaAD = new EditarCategoriaAD();

        }

        public async Task<int> Editar(CategoriasDto laCategoriaParaGuardar)
        {

            int cantidadDeFilasAfectas = await _editarCategoriaAD.Editar(laCategoriaParaGuardar);
            return cantidadDeFilasAfectas;
        }

        public async Task<CategoriasDto> ObtenerPorId(int id)
        {
            return await _editarCategoriaAD.ObtenerPorId(id);
        }
    }


}
