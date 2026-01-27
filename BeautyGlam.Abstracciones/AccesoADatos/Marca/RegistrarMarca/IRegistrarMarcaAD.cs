using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Marca.RegistrarMarca
{
    public interface IRegistrarPAD
    {
        Task<int> Registrar(MarcaDto laMarcaParaGuardar);

    }
}
