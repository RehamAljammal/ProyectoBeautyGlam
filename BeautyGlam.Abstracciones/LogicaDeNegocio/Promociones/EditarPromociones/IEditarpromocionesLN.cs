using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EditarPromociones
{
    public interface IEditarpromocionesLN
    {
        Task<int> Editar(PromocionesDTO laPromocionParaGuardar);
        Task<PromocionesDTO> ObtenerPorId(int id);
    }
}
