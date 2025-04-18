using SPAKLY.Modelos;

namespace SPAKLY.API.Models
{
    public class DetallePedido
    {
        public int DetallePedidoId { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        public int ProductoId { get; set; }
        public Productos Producto { get; set; } = null!;

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
