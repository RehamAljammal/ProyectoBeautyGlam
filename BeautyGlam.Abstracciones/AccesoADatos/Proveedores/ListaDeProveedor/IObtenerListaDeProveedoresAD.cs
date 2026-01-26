using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Proveedores.ListaDeProveedor
{
    public interface IObtenerListaDeProveedoresAD
    {
        List<ProveedoresDto> Obtener();

    }
}
