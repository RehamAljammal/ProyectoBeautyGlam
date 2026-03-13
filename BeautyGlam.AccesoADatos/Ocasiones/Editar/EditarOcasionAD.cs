using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Editar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Ocasiones.Editar
{
    public class EditarOcasionAD : IEditarOcasionAD
    {
        private Contexto _contexto;

        public EditarOcasionAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> Editar(OcasionDto dto)
        {
            OcasionAD ocasion = _contexto.Ocasiones
                .FirstOrDefault(x => x.idOcasion == dto.idOcasion);

            if (ocasion != null)
            {
                ocasion.nombre = dto.nombre;
                ocasion.estado = dto.estado; 

                return await _contexto.SaveChangesAsync();
            }

            return 0; 
        }
    }
}