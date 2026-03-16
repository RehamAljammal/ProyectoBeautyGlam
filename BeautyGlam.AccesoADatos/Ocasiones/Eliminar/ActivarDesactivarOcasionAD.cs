using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.ActivarDesactivar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Ocasiones.ActivarDesactivar
{
    public class ActivarDesactivarOcasionAD : IActivarDesactivarOcasionAD
    {
        private Contexto _contexto;

        public ActivarDesactivarOcasionAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> ActivarDesactivar(OcasionDto dto)
        {
            OcasionAD ocasion = _contexto.Ocasiones
                .FirstOrDefault(x => x.idOcasion == dto.idOcasion);

            if (ocasion != null)
            {
                ocasion.estado = !ocasion.estado; 
                return await _contexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}