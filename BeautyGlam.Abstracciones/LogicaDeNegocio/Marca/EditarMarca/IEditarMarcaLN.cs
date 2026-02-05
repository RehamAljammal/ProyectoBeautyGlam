using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EditarMarca
{
    public interface IEditarMarcaLN
    {
        Task<int> Editar(MarcaDto laMarcaParaGuardar);

        Task<MarcaDto> ObtenerPorId(int id);

    }
}
