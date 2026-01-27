using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Categoria.RegistrarCategoria
{
    internal interface IRegistrarCategoriaAD
    {
        Task<int> Registrar(CategoriasDto laCategoriaParaGuardar);

    }
}
