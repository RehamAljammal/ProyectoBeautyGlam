using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.RegistrarCategoria
{
    public interface IRegistrarCategoriaLN
    {
        Task<int> Registrar(CategoriasDto laCategoriaParaGuardar);

    }
}
