using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria
{
    public interface IEliminarCategoriaLN
    {
        Task<int> Eliminar(CategoriasDto laCtegoriaParaGuardar);

    }
}
