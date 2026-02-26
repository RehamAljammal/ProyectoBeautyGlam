namespace BeautyGlam.AccesoADatos.Entidades
{
    public class PromocionProductoAD
    {
        public int id_Promocion { get; set; }
        public int id { get; set; }

        public virtual PromocionesAD Promocion { get; set; }
        public virtual ProductoAD Producto { get; set; }
    }
}