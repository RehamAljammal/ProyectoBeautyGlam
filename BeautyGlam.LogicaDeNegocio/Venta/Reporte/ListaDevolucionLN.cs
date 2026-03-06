using BeautyGlam.Abstracciones.AccesoADatos.Devolucion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

public class ListaDevolucionLN : IListaDevolucionLN
{
    private readonly IListaDevolucionAD _ad;

    public ListaDevolucionLN(IListaDevolucionAD ad)
    {
        _ad = ad;
    }

    public List<DevolucionListadoDto> Obtener()
    {
        return _ad.Obtener();
    }
}