using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.RegistrarMarca
{
    public interface IRegistrarMarcaLN
    {
        Task<int> Registrar(MarcaDto laMarcaParaGuardar);

    }
}
