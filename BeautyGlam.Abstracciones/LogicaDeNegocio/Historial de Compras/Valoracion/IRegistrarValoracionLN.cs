using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Valoracion
{
    public interface IRegistrarValoracionLN
    {
        Task<int> Registrar(ValoracionDto valoracion);
    }
}
