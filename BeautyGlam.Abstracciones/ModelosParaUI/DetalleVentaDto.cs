public class DetalleVentaDto
{
    public int id_Detalle { get; set; }

    public int id_Venta { get; set; }

    public int id_Producto { get; set; }

    public string nombreProducto { get; set; }

    public int cantidad { get; set; }

    public decimal precio { get; set; }
}