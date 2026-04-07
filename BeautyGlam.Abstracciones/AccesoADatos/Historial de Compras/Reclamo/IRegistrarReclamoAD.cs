using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Reclamo
{
    public interface IRegistrarReclamoAD
    {
        Task<int> Registrar(ReclamoDto reclamo);
    }
}
