using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Marca.EliminarMarca
{
    public interface IEliminarMarcaAD
    {
        Task<int> Eliminar(MarcaDto laMarcaParaGuardar);

    }
}
