namespace SPAKLY.Modelos
{
    public class Productos
    {
        public int ProductosId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}