using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRegistrarVentaLN
{
    Task<int> Registrar(VentaDto venta);
    List<UsuarioDto> ObtenerClientesActivos();
    List<ProductosDTO> ObtenerProductosActivos();
}