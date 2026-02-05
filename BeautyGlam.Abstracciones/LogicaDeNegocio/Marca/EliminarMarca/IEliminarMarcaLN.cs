using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EliminarMarca
{
    public interface IEliminarMarcaLN
    {
        Task<int> Eliminar(MarcaDto laMarcaParaGuardar);

    }
}
