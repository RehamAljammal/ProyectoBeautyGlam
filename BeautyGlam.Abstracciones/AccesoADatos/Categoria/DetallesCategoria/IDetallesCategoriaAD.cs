using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Categoria.DetallesCategoria
{
    public interface IDetallesCategoriaAD
    {
        Task<int> Detalles(CategoriasDto laCategoriaParaGuardar);

    }
}
