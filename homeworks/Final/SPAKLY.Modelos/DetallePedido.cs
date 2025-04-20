using SPAKLY.Modelos;

namespace SPAKLY.Modelos
{
    public class DetallePedido
    {
        public int DetallePedidoId { get; set; }

        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Ordenes Ordenes { get; set; } = null!;
        public Productos Producto { get; set; } = null!;
    }
}
