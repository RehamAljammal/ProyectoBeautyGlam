using BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Valoracion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.HistorialCompras.Valoración;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Historial_Compras.Valoracion
{
    public class RegistrarValoracionLN : IRegistrarValoracionLN
    {
        private readonly RegistrarValoracionAD _ad;

        public RegistrarValoracionLN()
        {
            _ad = new RegistrarValoracionAD();
        }

        public async Task<int> Registrar(ValoracionDto v)
        {
            return await _ad.Registrar(v);
        }
    }
}
