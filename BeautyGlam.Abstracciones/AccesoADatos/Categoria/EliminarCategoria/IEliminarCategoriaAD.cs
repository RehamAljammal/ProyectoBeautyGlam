using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Categoria.EliminarCategoria
{
    internal interface IEliminarCategoriaAD
    {
        Task<int> Eliminar(CategoriasDto laCategoriaParaGuardar);

    }
}
