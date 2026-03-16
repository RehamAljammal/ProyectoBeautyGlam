using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Tono.EditarTono
{
    public class EditarTonoAD
    {
        private Contexto _elContexto;

        public EditarTonoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(TonoDTO tonoParaEditar)
        {
            var tonoEnBD = _elContexto.Tono
                .FirstOrDefault(t => t.id_Tono == tonoParaEditar.id_Tono);

            if (tonoEnBD != null)
            {
                tonoEnBD.nombre = tonoParaEditar.nombre;
                tonoEnBD.descripcion = tonoParaEditar.descripcion;
            }

            return await _elContexto.SaveChangesAsync();
        }
    }
}