using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Categoria.EditarCategoria
{
    internal interface IEditarCategoriaAD
    {
        Task<int> Editar(CategoriasDto laCategoriaParaGuardar);
        Task<CategoriasDto> ObtenerPorId(int id);
    }
}
